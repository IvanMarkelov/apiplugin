using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;

namespace LEDEL_BIM.APIUtility
{
    public static class FamilyParser
    {
        static void Main()
        {
            string[] filePaths = Directory.GetFiles(@"D:\CS plugin for Revit\Revit Family Types", "*.txt");
            foreach (string filePath in filePaths)
            {
                List<string> listOfLines = GetListOfLines(filePath);
                int[] paramIndices = GetParameterIndices(StringToArray(GetParametersAsString(listOfLines)));
                string[] str = StringToArray(GetParametersAsString(listOfLines));
                List<string> listOfFamilyTypes = GetListOfFamilyTypes(listOfLines);

                List<LightingFixtureType> familyTypes = new List<LightingFixtureType>();

                foreach (string familyType in listOfFamilyTypes)
                {
                    LightingFixtureType lft = GetFamilyType(paramIndices, familyType);
                    familyTypes.Add(lft);
                    Console.WriteLine(lft);
                }
                LightingFixtureFamily lff = new LightingFixtureFamily(GetFamilyName(filePath), GetRfaPath(filePath), familyTypes);
                Console.WriteLine(lff);
            }
        }

        public static string GetRfaPath(string filePath)
        {
            string RfaPath = filePath.Replace("txt", "rfa");
            return RfaPath;
        }
        public static string[] StringToArray(string line)
        {
            char separator = ',';
            string[] parameterNames = line.Split(separator);
            return parameterNames;
        }

        public static string GetParametersAsString(List<string> listOfLines)
        {
            string parameterLine = listOfLines[0];
            return parameterLine;
        }

        public static List<string> GetListOfFamilyTypes(List<string> listOfLines)
        {
            List<string> listOfFamilies = listOfLines;
            listOfFamilies.RemoveAt(0);
            listOfFamilies.RemoveAll(string.IsNullOrEmpty);
            return listOfFamilies;
        }

        public static string RemoveQuotes(string line)
        {
            line.Trim('\"');
            return line;

        }

        public static List<string> GetListOfLines(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            List<string> listOfLines = new List<string>();
            string line = reader.ReadLine();
            listOfLines.Add(line);
            while (line != null)
            {
                line = reader.ReadLine();
                listOfLines.Add(line);
            }
            reader.Close();
            return listOfLines;
        }

        public static int[] GetParameterIndices(string[] firstLine)
        {
            int indexOfFamilyTypeName = 0;
            int indexOfLoad = 0;
            int indexOfLumFlux = 0;
            int indexOfType = 0;
            int indexOfColor = 0;

            for (int index = 1; index < firstLine.Length; index++)
            {
                if (indexOfType == 0 && firstLine[index].Equals("Комментарии к типоразмеру##OTHER##"))
                {
                    indexOfType = index;
                }
                else if (indexOfLumFlux == 0 && firstLine[index].Equals("Световой поток##ELECTRICAL_LUMINOUS_FLUX##LUMENS"))
                {
                    indexOfLumFlux = index;
                }
                else if (indexOfLoad == 0 && firstLine[index].Equals("Полная установленная мощность##ELECTRICAL_APPARENT_POWER##VOLT_AMPERES"))
                {
                    indexOfLoad = index;
                }
                else if (indexOfColor == 0 && firstLine[index].Equals("Исходная цветовая температура##COLOR_TEMPERATURE##KELVIN"))
                {
                    indexOfColor = index;
                }
                else if (indexOfType != 0 && indexOfLumFlux != 0 && indexOfLoad != 0 && indexOfColor != 0)
                { break; }
            }

            int[] array = new int[5];
            array[0] = indexOfFamilyTypeName;
            array[1] = indexOfType;
            array[2] = indexOfLoad;
            array[3] = indexOfColor;
            array[4] = indexOfLumFlux;
            return array;
        }

        public static LightingFixtureType GetFamilyType(int[] parameterIndices, string line)
        {
            line.Trim('\"');
            string[] ln = StringToArray(line);

            string familyTypeName = ln[parameterIndices[0]];
            string familyType = ln[parameterIndices[1]];
            string apparentLoad = ln[parameterIndices[2]];
            string fluxL = ln[parameterIndices[3]];
            string colorT = ln[parameterIndices[4]];

            double load = Double.Parse(apparentLoad, CultureInfo.InvariantCulture);
            double color = Double.Parse(colorT, CultureInfo.InvariantCulture);
            double flux = Double.Parse(fluxL, CultureInfo.InvariantCulture);

            LightingFixtureType lft = new LightingFixtureType(familyTypeName, familyType, load, color, flux);
            return lft;
        }

        public static List<LightingFixtureFamily> RetriveAllFamiliesFromFolder(string[] filePaths)
        {
            List<LightingFixtureFamily> listOfFamilies = new List<LightingFixtureFamily>();

            foreach (string filePath in filePaths)
            {
                List<string> listOfLines = GetListOfLines(filePath);
                int[] paramIndices = GetParameterIndices(StringToArray(GetParametersAsString(listOfLines)));
                string[] str = StringToArray(GetParametersAsString(listOfLines));
                List<string> listOfFamilyTypes = GetListOfFamilyTypes(listOfLines);

                List<LightingFixtureType> familyTypes = new List<LightingFixtureType>();

                foreach (string familyType in listOfFamilyTypes)
                {
                    LightingFixtureType lft = GetFamilyType(paramIndices, familyType);
                    familyTypes.Add(lft);
                    //Console.WriteLine(lft);
                }
                LightingFixtureFamily lff = new LightingFixtureFamily(GetFamilyName(filePath), GetRfaPath(filePath), familyTypes);
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
    }
}
