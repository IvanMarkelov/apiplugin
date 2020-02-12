using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using System.Windows.Media.Imaging;

namespace LEDEL_BIM.APIUtility
{
    public static class FamilyParser
    {
        public static List<LightingFixtureType> ParseDataFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<LightingFixtureTypeMap>();
                csv.Configuration.IgnoreBlankLines = true;
                csv.Configuration.BadDataFound = null;
                List<LightingFixtureType> types = csv.GetRecords<LightingFixtureType>().ToList();
                return types;
            }
        }
        public static string GetRfaPath(string filePath)
        {
            string RfaPath = filePath.Replace("txt", "rfa");
            return RfaPath;
        }
        public static string ReturnFamilyImageFilePath(string filePath)
        {
            string temp = filePath.Replace("txt", "png");
            string imagePath = temp.Replace("Revit Family Types", "Resources");
            return imagePath;
        }
        public static BitmapImage GetFamilyImage(string filePath)
        {
            BitmapImage familyImage = new BitmapImage(new Uri(filePath));
            return familyImage;
        }
        public static string RemoveQuotes(string line)
        {
            line.Trim('\"');
            return line;
        }
        public static List<LightingFixtureFamily> RetriveAllFamiliesFromFolder(string[] filePaths)
        {
            List<LightingFixtureFamily> listOfFamilies = new List<LightingFixtureFamily>();

            foreach (string filePath in filePaths)
            {
                List<LightingFixtureType> familyTypes = ParseDataFromFile(filePath);
                string description = GetDescription(familyTypes);

                LightingFixtureFamily lff = new LightingFixtureFamily(GetFamilyName(filePath), GetRfaPath(filePath),
                    familyTypes, GetFamilyImage(ReturnFamilyImageFilePath(filePath)), familyTypes[0].FamilyDescription);
                foreach (LightingFixtureType type in lff.FamilyTypes)
                {
                    type.Family = lff;
                }
                //Console.WriteLine(lff);
                listOfFamilies.Add(lff);
            }
            return listOfFamilies;
        }
        public static string GetFamilyName(string filePath)
        {
            int indexOfSlash = filePath.LastIndexOf("\\");
            int indexOfDot = filePath.LastIndexOf('.');
            string familyName = filePath.Substring(indexOfSlash + 1, indexOfDot - indexOfSlash - 1);
            return familyName;
        }
        public static string GetDescription(List<LightingFixtureType> types)
        {
            string description = null;//types[0].FamilyDescription;
            return description;
        }
    }
}
