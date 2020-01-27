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

        public LightingFixtureType(string familyTypeName, string familyCategory, double load, double flux, double color)
        {
            this.FamilyTypeName = familyTypeName;
            this.FamilyCategory = familyCategory;
            this.ApparentLoad = load;
            this.LightFlux = flux;
            this.TemperatureColor = color;
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
        public string FamilyPath
        { get; set; }

        public LightingFixtureFamily(string familyName, string familyPath, List<LightingFixtureType> familyTypes)
        {
            this.FamilyName = familyName;
            this.FamilyTypes = familyTypes;
            this.FamilyPath = familyPath;
        }

        public override string ToString()
        {
            return $"Светодиодный светильник {this.FamilyName} \nРасположен в {this.FamilyPath}";
        }
    }
}

