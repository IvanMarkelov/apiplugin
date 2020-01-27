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
    public class InsertFamilyType : IExternalCommand
    {
        Application m_rvtApp;
        Document m_rvtDoc;
        public Result Execute(ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            //  Get the access to the top most objects. 
            UIApplication rvtUIApp = commandData.Application;
            UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            m_rvtApp = rvtUIApp.Application;
            m_rvtDoc = rvtUIDoc.Document;

            FamilySymbol family = null;

            Transaction trans = new Transaction(m_rvtDoc);
            trans.Start("Loading and Inserting the Luminaire");
            m_rvtDoc.LoadFamily("C:\\Users\\Admin\\Desktop\\REVIT_BIM\\Revit Family Types\\L-banner 600.rfa");
            m_rvtDoc.LoadFamilySymbol("C:\\Users\\Admin\\Desktop\\REVIT_BIM\\Revit Family Types\\L-banner 600.rfa", "L-banner 600-К8-4.0K", out family);
            trans.Commit();

            rvtUIApp.ActiveUIDocument.PromptForFamilyInstancePlacement(family);

            return Result.Succeeded;
        }

    }

}
