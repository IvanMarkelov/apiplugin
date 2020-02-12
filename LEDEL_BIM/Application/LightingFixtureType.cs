using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using System.Windows.Media.Imaging;

namespace LEDEL_BIM
{
    public class LightingFixtureType
    {
        public string FamilyTypeName
        {
            get; set;
        }
        public string FamilyCategory
        {
            get; set;
        }
        public double ApparentLoad
        {
            get; set;
        }
        public double LightFlux
        {
            get; set;
        }
        public double TemperatureColor
        {
            get; set;
        }
        public string PhotometricWeb
        {
            get; set;
        }
        public string FamilyDescription
        {
            get; set;
        }
        public LightingFixtureFamily Family
        {
            get; set;
        }
        public LightingFixtureType()
        {
            this.FamilyTypeName = null;
            this.FamilyCategory = null;
            this.ApparentLoad = 0;
            this.LightFlux = 0;
            this.TemperatureColor = 0;
            this.PhotometricWeb = null;
            this.FamilyDescription = null;
            this.Family = null;
        }
        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
        }
        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color, string photometricWeb)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
            this.PhotometricWeb = photometricWeb;
        }
        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color, LightingFixtureFamily family)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
            this.Family = family;
        }

        public override string ToString()
        {
            return $"Светильник {this.FamilyTypeName} категории {this.FamilyCategory} мощностью {this.ApparentLoad} В, световым потоком {this.LightFlux} лк, цветовой температурой {this.TemperatureColor} К";
        }
    }
    public class LightingFixtureTypeMap : ClassMap<LightingFixtureType>
    {
        public LightingFixtureTypeMap()
        {
            Map(m => m.FamilyTypeName).Index(0);
            Map(m => m.FamilyCategory).Name("Комментарии к типоразмеру##OTHER##");
            Map(m => m.ApparentLoad).Name("Полная установленная мощность##ELECTRICAL_APPARENT_POWER##VOLT_AMPERES");
            Map(m => m.LightFlux).Name("Световой поток светильника##ELECTRICAL_LUMINOUS_FLUX##LUMENS");
            Map(m => m.TemperatureColor).Name("Цветовая температура##COLOR_TEMPERATURE##KELVIN");
            Map(m => m.PhotometricWeb).Name("Кривая сил света##OTHER##");
            Map(m => m.FamilyDescription).Name("Описание##OTHER##");
        }
    }
    public class LightingFixtureFamily
    {
        public List<LightingFixtureType> FamilyTypes
        { get; set; }
        public string FamilyName
        { get; set; }
        public string FamilyPath
        { get; set; }
        public BitmapImage FamilyImage
        { get; set; }
        public string Description
        {
            get; set;
        }
        public LightingFixtureFamily(string familyName, string familyPath, List<LightingFixtureType> familyTypes)
        {
            this.FamilyName = familyName;
            this.FamilyTypes = familyTypes;
            this.FamilyPath = familyPath;
        }
        public LightingFixtureFamily(string familyName, string familyPath, List<LightingFixtureType> familyTypes, BitmapImage familyImage)
        {
            this.FamilyName = familyName;
            this.FamilyTypes = familyTypes;
            this.FamilyPath = familyPath;
            this.FamilyImage = familyImage;
        }
        public LightingFixtureFamily(string familyName, string familyPath, List<LightingFixtureType> familyTypes, BitmapImage familyImage, string description)
        {
            this.FamilyName = familyName;
            this.FamilyTypes = familyTypes;
            this.FamilyPath = familyPath;
            this.FamilyImage = familyImage;
            this.Description = description;
        }
        public override string ToString()
        {
            return $"Светодиодный светильник {this.FamilyName} \nРасположен в {this.FamilyPath}";
        }
        public string TypesCheck(List<LightingFixtureType> types)
        {
            StringBuilder sb = new StringBuilder();
            foreach (LightingFixtureType type in types)
            {
                sb.Append(type.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}

