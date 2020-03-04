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
        static string addInPath = typeof(App).Assembly.Location;
        // Contents directory
        static string contentsFolder = Path.GetDirectoryName(addInPath);
        // Resources directory
        internal static string resourcesFolder = contentsFolder + "\\Resources\\";

        public Result OnStartup(UIControlledApplication app)
        {
            CreateRibbonSamplePanel(app);
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
        private void CreateRibbonSamplePanel(UIControlledApplication application)
        {
            string panelSampleName = "Подбор светильника";
            string helpPath = resourcesFolder + "Help.txt";
            string toolTip = "Вызвать меню подбора светильника.";
            string longDescription = "Открывает каталог, в котором можно подобрать светильники LEDEL.";
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(panelSampleName);

            PushButtonData pushButtonData = new PushButtonData("nameButton", "Подбор\n светильника", addInPath, "LEDEL_BIM.ShowMainWindow");
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
            pushButton.LargeImage = new BitmapImage(new Uri(resourcesFolder + "logo_96.png"));
            pushButton.Image = new BitmapImage(new Uri(resourcesFolder + "logo_48.png"));
            pushButton.ToolTipImage = new BitmapImage(new Uri(resourcesFolder + "logo_48.png"));
            pushButton.ToolTip = toolTip;
            pushButton.LongDescription = longDescription;
            ContextualHelp help = new ContextualHelp(ContextualHelpType.ChmFile, helpPath);
            pushButton.SetContextualHelp(help);
        }
    }
}
