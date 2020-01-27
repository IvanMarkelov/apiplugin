using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;

namespace LEDEL_BIM
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class App : IExternalApplication
    {
        // OnStartup() - called when Revit starts.
        static string AddInPath = typeof(App).Assembly.Location;
        // Button icons directory
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);

        //MainWindow.MainWindow mainWindow;

        public Result OnStartup(UIControlledApplication app)
        {
            //TaskDialog.Show("My Dialog", "Testing attempt 1");
            CreateRibbonSamplePanel(app);

            return Result.Succeeded;
        }

        // OnShutdown() - called when Revit ends.

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }

        private void CreateRibbonSamplePanel(UIControlledApplication application)
        {
            string panelSampleName = "Подбор светильника";
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(panelSampleName);

            PushButtonData pushButtonData = new PushButtonData("nameButton", "LEDEL", AddInPath, "LEDEL_BIM.ShowMainWindow");
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
            pushButton.LargeImage = new BitmapImage(new Uri(Path.GetDirectoryName(AddInPath) + "\\" + "Ledel_logo.png"));
            pushButton.Image = new BitmapImage(new Uri(Path.GetDirectoryName(AddInPath) + "\\" + "Ledel_logoS.png"));
        //    pushButton.ToolTipImage = new BitmapImage(new Uri(Path.GetDirectoryName(AddInPath) + "\\" + "Ledel_logoS.png"));
            pushButton.ToolTip = "Вызвать меню подбора светильника.";

            //application.ControlledApplication.DocumentCreated += new EventHandler<Autodesk.Revit.DB.Events.DocumentCreatedEventArgs>(DocumentCreated);
            //CreateWindow();
            //ShowMainWindow(application, "Window", pb);
        }
    }

}
