using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.IO;

namespace LEDEL_BIM.APIUtility
{
//    class FamilyRFAParser : IExternalCommand
//    {
//        //Application m_rvtApp;
//        //Document m_rvtDoc;
//        //public Result Execute(ExternalCommandData commandData,
//        //    ref string message,
//        //    ElementSet elements)
//        //{
//        //    UIApplication rvtUIApp = commandData.Application;
//        //    UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
//        //    m_rvtApp = rvtUIApp.Application;
//        //    m_rvtDoc = rvtUIDoc.Document;


//        //    string[] filePaths = Directory.GetFiles(@"C:\Users\Admin\Desktop\REVIT_BIM\Revit Family Types", "*.rfa");
//        //    List<LightingFixtureFamily> families = new List<LightingFixtureFamily>();
//        //    LightingFixtureFamily family;
//        //    foreach (string path in filePaths)
//        //    {
//        //        string fileName = FamilyParser.GetFamilyName(path);
                
//        //        TaskDialog.Show("The path: ", path);
//        //        Document doc = m_rvtApp.OpenDocumentFile(path);
//        //        family = new LightingFixtureFamily(fileName, path, GetListOfFamilyTypes(doc));
//        //        StringBuilder sb = new StringBuilder();
//        //        foreach (LightingFixtureType type in family.FamilyTypes)
//        //        {
//        //            sb.Append(type.ToString() + "\n");
//        //        }
//        //        TaskDialog.Show("List of Family Types", sb.ToString());
//        //        families.Add(family);
//        //    }
//        //    MainWindow.MainWindow.listOfFamilies = families;
//        //    return Result.Succeeded;
//        //}
//        //internal List<LightingFixtureType> GetListOfFamilyTypes(Document familyDoc)
//        //{
//        //    if (familyDoc.IsFamilyDocument)
//        //    {
//        //        FamilyManager familyManager = familyDoc.FamilyManager;

//        //        List<LightingFixtureType> types = new List<LightingFixtureType>();

//        //        FamilyParameter categoryParameter = familyManager.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
//        //        FamilyParameter fluxParameter = familyManager.get_Parameter("Световой поток светильника");
//        //        FamilyParameter loadParameter = familyManager.get_Parameter(BuiltInParameter.RBS_ELEC_APPARENT_LOAD);
//        //        FamilyParameter colorParameter = familyManager.get_Parameter("Цветовая температура");
//        //        FamilyParameter photometricWebParameter = familyManager.get_Parameter("Кривая сил света");
//        //        FamilyParameter descriptionParameter = familyManager.get_Parameter("Описание");

//        //        FamilyTypeSet familyTypes = familyManager.Types;
//        //        FamilyTypeSetIterator familyTypesItor = familyTypes.ForwardIterator();
//        //        familyTypesItor.Reset();
//        //        while (familyTypesItor.MoveNext())
//        //        {
//        //            FamilyType familyType = familyTypesItor.Current as FamilyType;
//        //            string typeName = familyType.Name;
//        //            string category = familyType.AsString(categoryParameter);
//        //            double flux = (double)familyType.AsDouble(fluxParameter);
//        //            double loadToConvert = (double)familyType.AsDouble(loadParameter);
//        //            double load = UnitUtils.ConvertFromInternalUnits(loadToConvert, DisplayUnitType.DUT_VOLT_AMPERES);
//        //            double colorTemperature = (double)familyType.AsDouble(colorParameter);
//        //            string photometricWeb = familyType.AsString(photometricWebParameter);
//        //            string typeDescription = familyType.AsString(descriptionParameter);
//        //            LightingFixtureType fixture = new LightingFixtureType(typeName, category, load, flux, colorTemperature, photometricWeb, typeDescription);
//        //            types.Add(fixture);
//        //        }
//        //        return types;
//        //    }
//        //    return null;
//        //}
//    }
}
