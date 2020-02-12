using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;


namespace LEDEL_BIM.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        internal static double defaultLoadFromValue = 0;
        internal static double defaultLoadToValue = 5000;
        internal static double defaultFluxFromValue = 0;
        internal static double defaultFluxToValue = 1000000;
        internal static string defaultFamilyName = "Наименование светильника";
        internal static string defaultCategoryName = "Категория светильника";
        internal static string defaultLoadFrom = "Мощность Вт, от";
        internal static string defaultLoadTo = "Мощность Вт, до";
        internal static string defaultFluxFrom = "Световой поток лм, от";
        internal static string defaultFluxTo = "Световой поток лм, до";
        internal static string defaultTemperature = "Цветовая температура";
        internal static string defaultPhotometricWeb = "Тип КСС";
        List<LightingFixtureFamily> families;

        public static LightingFixtureType lft;
        // double loadFromValue;
        // double loadToValue;
        string familyName = defaultFamilyName;
        InsertFamilyType ift;
        ExternalEvent TypeInserting;

        public MainWindow()
        {
            InitializeComponent();
            ShowTree();
        }
        private void ShowTree()
        {
            families = ListGetter();
            namesList.ItemsSource = families;
            treeViewLFF.ItemsSource = families;
        }
        private List<string> AllPhotometricWebTitles(List<LightingFixtureFamily> families)
        {
            List<string> webList = new List<string>();
            foreach (LightingFixtureFamily family in families)
            {
                foreach (LightingFixtureType type in family.FamilyTypes)
                {
                    if (webList.Contains(type.PhotometricWeb) == false)
                    {
                        webList.Add(type.PhotometricWeb);
                    }
                }
            }
            return webList;
        }
        private void ShowUpdatedTree()
        {
            List<LightingFixtureFamily> filteredFamilies = new List<LightingFixtureFamily>();
            foreach (LightingFixtureFamily family in families)
            {
                List<LightingFixtureType> temporaryTypeList = Utility.Filters.SearchList(family.FamilyTypes,
                    namesList.Text,
                    typeList.Text,
                    GetDoubleValue(this.loadFrom.Text, defaultLoadFromValue),
                    GetDoubleValue(this.loadTo.Text, defaultLoadToValue),
                    GetDoubleValue(this.fluxFrom.Text, defaultFluxFromValue),
                    GetDoubleValue(this.fluxTo.Text, defaultFluxToValue),
                    colorTemperatureList.Text,
                    photometricWebList.Text);

                if (temporaryTypeList.Count > 0)
                {
                    filteredFamilies.Add(new LightingFixtureFamily(family.FamilyName, family.FamilyPath, temporaryTypeList, family.FamilyImage, family.Description));
                }
            }
            treeViewLFF.ItemsSource = filteredFamilies;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowUpdatedTree();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            lft = (LightingFixtureType)treeViewLFF.SelectedItem;
            ift = new InsertFamilyType();
            //MessageBox.Show($"Светильник {lft.FamilyTypeName}, находящийся в {lft.Family.FamilyPath} будет вставлен в проект.");
            //MessageBox.Show(File.Exists(lft.Family.FamilyPath).ToString());
            TypeInserting = ExternalEvent.Create(ift);
            Close();
            TypeInserting.Raise();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private double GetDoubleValue(string valueAsString, double defaultValue)
        {
            double result;
            if (Double.TryParse(valueAsString, out result) == true)
            {
                result = Double.Parse(valueAsString);
            }
            else
            {
                result = defaultValue;
            }
            return result;
        }
        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ComboBox cb = (System.Windows.Controls.ComboBox)sender;
            cb.Text = string.Empty;
            //  cb.GotFocus -= ComboBox_GotFocus;
        }

        private List<LightingFixtureFamily> ListGetter()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\Admin\Desktop\REVIT_BIM\Revit Family Types", "*.txt");
            List<LightingFixtureFamily> families = APIUtility.FamilyParser.RetriveAllFamiliesFromFolder(filePaths);

            return families;
        }

        private List<string> TypeNameGetter(List<LightingFixtureType> types)
        {
            List<string> typeNames = new List<string>();
            foreach (LightingFixtureType type in types)
            {
                typeNames.Add(type.FamilyTypeName);
            }
            return typeNames;
        }
        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ComboBox cb = (System.Windows.Controls.ComboBox)sender;
            if (cb.Text == "")
            {
                switch (cb.Name)
                {
                    case "namesList":
                        cb.Text = defaultFamilyName;
                        NameTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "typeList":
                        cb.Text = defaultCategoryName;
                        CategoryTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "colorTemperatureList":
                        cb.Text = defaultTemperature;
                        colorTemperatureTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "photometricWebList":
                        cb.Text = defaultPhotometricWeb;
                        photoWebTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    default:
                        cb.Text = "Непредвиденная ошибка";
                        break;
                }
            }
            else if (cb.Text != "")
            {
                switch (cb.Name)
                {
                    case "namesList":
                        NameTextBlock.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case "typeList":
                        CategoryTextBlock.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case "colorTemperatureList":
                        colorTemperatureTextBlock.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case "photometricWebList":
                        photoWebTextBlock.Visibility = System.Windows.Visibility.Visible;
                        break;
                    default:
                        cb.Text = "Непредвиденная ошибка";
                        break;
                }
            }
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            if (tb.Text == defaultLoadFrom || tb.Text == defaultFluxTo || tb.Text == defaultFluxFrom || tb.Text == defaultLoadTo)
                tb.Text = string.Empty;
            switch (tb.Name)
            {
                case "loadFrom":
                    loadFromTextBlock.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "loadTo":
                    loadToTextBlock.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "fluxFrom":
                    fluxFromTextBlock.Visibility = System.Windows.Visibility.Visible;
                    break;
                case "fluxTo":
                    fluxToTextBlock.Visibility = System.Windows.Visibility.Visible;
                    break;
                default:
                    tb.Text = "Непредвиденная ошибка";
                    break;
            }
            if (tb.Text == "" || tb.Text == defaultLoadFrom || tb.Text == defaultFluxTo || tb.Text == defaultFluxFrom || tb.Text == defaultLoadTo)
            { tb.GotFocus += TextBox_GotFocus; }
            else
            { tb.GotFocus -= TextBox_GotFocus; }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            // if (tb.Text == "")
            //{
            //switch (tb.Name)
            //{
            //    case "loadFrom":
            //        tb.Text = defaultLoadFrom;
            //        loadFromTextBlock.Visibility = Visibility.Hidden;
            //        break;
            //    case "loadTo":
            //        tb.Text = defaultLoadTo;
            //        loadToTextBlock.Visibility = Visibility.Hidden;
            //        break;
            //    case "fluxFrom":
            //        tb.Text = defaultFluxFrom;
            //        fluxFromTextBlock.Visibility = Visibility.Hidden;
            //        break;
            //    case "fluxTo":
            //        tb.Text = defaultFluxTo;
            //        fluxToTextBlock.Visibility = Visibility.Hidden;
            //        break;
            //    default:
            //        tb.Text = "Непредвиденная ошибка";
            //        break;
            //}
            //}
            if (tb.Text == "")
            {
                switch (tb.Name)
                {
                    case "loadFrom":
                        tb.Text = defaultLoadFrom;
                        loadFromTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "loadTo":
                        tb.Text = defaultLoadTo;
                        loadToTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "fluxFrom":
                        tb.Text = defaultFluxFrom;
                        fluxFromTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case "fluxTo":
                        tb.Text = defaultFluxTo;
                        fluxToTextBlock.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    default:
                        tb.Text = "Непредвиденная ошибка";
                        break;
                }
            }
        }

        private void treeViewLFF_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            object obj = (object)treeViewLFF.SelectedItem;
            if (obj is LightingFixtureType)
            {
                insertButton.IsEnabled = true;
            }
            else
            {
                insertButton.IsEnabled = false;
            }
        }
        private void defaultFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            namesList.Text = defaultFamilyName;
            typeList.Text = defaultCategoryName;
            loadFrom.Text = defaultLoadFrom;
            loadTo.Text = defaultLoadTo;
            fluxFrom.Text = defaultFluxFrom;
            fluxTo.Text = defaultFluxTo;
            colorTemperatureList.Text = defaultTemperature;
            photometricWebList.Text = defaultPhotometricWeb;
            ShowUpdatedTree();
        }

        private void FamilyDescription_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel sp = (StackPanel)sender;
            TextBlock tb = (TextBlock)sp.FindName("FamilyDescription");
            // TextBlock spaceBlock = (TextBlock)sp.FindName("SpaceBlock");
            tb.Visibility = System.Windows.Visibility.Visible;
            //spaceBlock.Visibility = Visibility.Visible;
            // MessageBox.Show(childCount.ToString());
        }
        private void FamilyDescription_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel sp = (StackPanel)sender;
            TextBlock tb = (TextBlock)sp.FindName("FamilyDescription");
            //TextBlock spaceBlock = (TextBlock)sp.FindName("SpaceBlock");
            tb.Visibility = System.Windows.Visibility.Collapsed;
            //spaceBlock.Visibility = Visibility.Collapsed;
            // MessageBox.Show(childCount.ToString());
        }
    }
}