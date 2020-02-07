using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string TypeDescription
        {
            get; set;
        }
        public string PhotometricWeb
        {
            get; set;
        }
        public LightingFixtureFamily Family
        {
            get; set;
        }

        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
        }
        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color, string photometricWeb, string typeDescription)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
            this.PhotometricWeb = photometricWeb;
            this.TypeDescription = typeDescription;
        }
        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color, string photometricWeb, string typeDescription, LightingFixtureFamily family)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
            this.PhotometricWeb = photometricWeb;
            this.TypeDescription = typeDescription;
            this.Family = family;
        }

        public override string ToString()
        {
            return $"Светильник {this.FamilyTypeName} категории {this.FamilyCategory} мощностью {this.ApparentLoad} В, световым потоком {this.LightFlux} лк, цветовой температурой {this.TemperatureColor} К";
        }
    }

    public class LightingFixtureFamily
    {
        public List<LightingFixtureType> FamilyTypes
        { get; set; }
        public string FamilyName
        { get; set; }
        public string FamilyDescription
        { get; set; }
        public string FamilyPath
        { get; set; }

        public LightingFixtureFamily(string familyName, string familyPath, List<LightingFixtureType> familyTypes)
        {
            this.FamilyName = familyName;
            this.FamilyTypes = familyTypes;
            this.FamilyPath = familyPath;
            this.FamilyDescription = this.FamilyTypes[0].TypeDescription;
        }

        public override string ToString()
        {
            return $"{this.FamilyDescription} \nРасположен в {this.FamilyPath}.";
        }
    }
}

