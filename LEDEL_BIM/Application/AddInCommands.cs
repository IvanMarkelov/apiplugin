using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using System.Diagnostics;
using System.IO;
using System.Collections;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;

namespace LEDEL_BIM
{
    [Transaction(TransactionMode.Manual)]
    public class ShowMainWindow : IExternalCommand
    {
        Application m_rvtApp;
        Document m_rvtDoc;
        internal static List<LightingFixtureFamily> families;
        public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            {
                UIApplication rvtUIApp = revit.Application;
                UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
                m_rvtApp = rvtUIApp.Application;
                m_rvtDoc = rvtUIDoc.Document;


                string[] filePaths = Directory.GetFiles(@"C:\Users\Admin\Desktop\REVIT_BIM\Revit Family Types", "*.rfa");
                families = new List<LightingFixtureFamily>();
                LightingFixtureFamily family;
                foreach (string path in filePaths)
                {
                    //TaskDialog.Show("The path: ", path);
                    Document doc = m_rvtApp.OpenDocumentFile(path);
                    family = new LightingFixtureFamily(APIUtility.FamilyParser.GetFamilyName(path), path, GetListOfFamilyTypes(doc));
                    StringBuilder sb = new StringBuilder();
                    foreach (LightingFixtureType type in family.FamilyTypes)
                    {
                        sb.Append(type.ToString() + "\n");
                    }
                    //TaskDialog.Show("List of Family Types", sb.ToString());
                    families.Add(family);
                    doc.Close(false);
                }
                MainWindow.MainWindow mainWindow = new MainWindow.MainWindow();
                MainWindow.MainWindow.listOfFamilies = families;
                mainWindow.ShowDialog();
                return Result.Succeeded;
            }
        }
        internal List<LightingFixtureType> GetListOfFamilyTypes(Document familyDoc)
        {
            if (familyDoc.IsFamilyDocument)
            {
                FamilyManager familyManager = familyDoc.FamilyManager;

                List<LightingFixtureType> types = new List<LightingFixtureType>();

                FamilyParameter categoryParameter = familyManager.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
                FamilyParameter fluxParameter = familyManager.get_Parameter("Световой поток светильника");
                FamilyParameter loadParameter = familyManager.get_Parameter(BuiltInParameter.RBS_ELEC_APPARENT_LOAD);
                FamilyParameter colorParameter = familyManager.get_Parameter("Цветовая температура");
                FamilyParameter photometricWebParameter = familyManager.get_Parameter("Кривая сил света");
                FamilyParameter descriptionParameter = familyManager.get_Parameter("Описание");

                FamilyTypeSet familyTypes = familyManager.Types;
                FamilyTypeSetIterator familyTypesItor = familyTypes.ForwardIterator();
                familyTypesItor.Reset();
                while (familyTypesItor.MoveNext())
                {
                    FamilyType familyType = familyTypesItor.Current as FamilyType;
                    string typeName = familyType.Name;
                    string category = familyType.AsString(categoryParameter);
                    double flux = (double)familyType.AsDouble(fluxParameter);
                    double loadToConvert = (double)familyType.AsDouble(loadParameter);
                    double load = UnitUtils.ConvertFromInternalUnits(loadToConvert, DisplayUnitType.DUT_VOLT_AMPERES);
                    double colorTemperature = (double)familyType.AsDouble(colorParameter);
                    string photometricWeb = familyType.AsString(photometricWebParameter);
                    string typeDescription = familyType.AsString(descriptionParameter);
                    LightingFixtureType fixture = new LightingFixtureType(typeName, category, load, flux, colorTemperature, photometricWeb, typeDescription);
                    types.Add(fixture);
                }
                return types;
            }
            return null;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class InsertFamilyType : IExternalEventHandler
    {
        Application m_rvtApp;
        Document m_rvtDoc;
    /*    public Result Execute(ExternalCommandData commandData,
            ref string message,
            ElementSet elements)*/
            public string GetName()
        {
            return "Insert Family Type";
        }
        public void Execute(UIApplication rvtUIApp)
        {
            //  Get the access to the top most objects.

            UIDocument uidoc = rvtUIApp.ActiveUIDocument;
            Document m_rvtDoc = uidoc.Document;
            string familyFilePath = MainWindow.MainWindow.lft.Family.FamilyPath;
            string typeName = MainWindow.MainWindow.lft.FamilyTypeName;

            //  UIApplication rvtUIApp = commandData.Application;
            //     UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            //    m_rvtApp = rvtUIApp.Application;
            //     m_rvtDoc = rvtUIDoc.Document;

            FamilySymbol family = null;

            Transaction trans = new Transaction(m_rvtDoc);
            trans.Start("Loading and Inserting the Luminaire");
            //   m_rvtDoc.LoadFamily("C:\\Users\\Admin\\Desktop\\REVIT_BIM\\Revit Family Types\\L-banner 600.rfa");
            //  m_rvtDoc.LoadFamilySymbol("C:\\Users\\Admin\\Desktop\\REVIT_BIM\\Revit Family Types\\L-banner 600.rfa", "L-banner 600-К8-4.0K", out family);

            m_rvtDoc.LoadFamily(familyFilePath);
            m_rvtDoc.LoadFamilySymbol(familyFilePath, typeName, out family);

            trans.Commit();

          //  MainWindow.SecondaryWindow main = new MainWindow.SecondaryWindow(familyFilePath);
          //  main.ShowDialog();

            rvtUIApp.ActiveUIDocument.PromptForFamilyInstancePlacement(family);
           // return Result.Succeeded;
        }

    }

}
