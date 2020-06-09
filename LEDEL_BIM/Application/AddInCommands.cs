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
        public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            MainWindow.MainWindow mainWindow = new MainWindow.MainWindow();
            mainWindow.ShowDialog();

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class InsertFamilyType : IExternalEventHandler
    {
        Application m_rvtApp;
        Document m_rvtDoc;
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

            FamilySymbol family = null;

            Transaction trans = new Transaction(m_rvtDoc);
            trans.Start("Loading and Inserting the Luminaire");

            m_rvtDoc.LoadFamily(familyFilePath);
            m_rvtDoc.LoadFamilySymbol(familyFilePath, typeName, out family);

            trans.Commit();

            rvtUIApp.ActiveUIDocument.PromptForFamilyInstancePlacement(family);
        }
    }
}
