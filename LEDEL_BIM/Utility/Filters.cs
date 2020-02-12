using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LEDEL_BIM.Utility
{
    class Filters
    {
        private static List<LightingFixtureType> FilterByFamilyName(List<LightingFixtureType> types, string familyNameFilter)
        {
            if (familyNameFilter != null)
            {
                if (familyNameFilter == "Наименование светильника" || familyNameFilter == "")
                {
                }
                else
                {
                    types = types.FindAll(x => x.FamilyTypeName.StartsWith(familyNameFilter, true, CultureInfo.InvariantCulture));
                }
            }
            return types;
        }

        private static List<LightingFixtureType> FilterByFamilyCategory(List<LightingFixtureType> types, string familyCategoryFilter)
        {
            if (familyCategoryFilter != null)
            {
                if (familyCategoryFilter == "Категория светильника" || familyCategoryFilter == "")
                {
                }
                else
                {
                    types = types.FindAll(x => x.FamilyCategory == familyCategoryFilter);
                }
            }
            return types;
        }
        private static List<LightingFixtureType> FilterByPhotometricWeb(List<LightingFixtureType> types, string photometricWebFilter)
        {
            if (photometricWebFilter != null)
            {
                if (photometricWebFilter == "Тип КСС" || photometricWebFilter == "")
                {
                }
                else
                {
                    types = types.FindAll(x => x.PhotometricWeb == photometricWebFilter);
                }
            }
            return types;
        }

        private static List<LightingFixtureType> FilterByApparentLoad(List<LightingFixtureType> filtered, double loadFilterFrom, double loadFilterTo)
        {
            if (loadFilterFrom >= 0)
            {
                filtered = filtered.FindAll(x => x.ApparentLoad >= loadFilterFrom);
            }
            else
            {
                filtered = filtered.FindAll(x => x.ApparentLoad >= MainWindow.MainWindow.defaultLoadFromValue);
            }
            if (loadFilterTo >= loadFilterFrom)
            {
                filtered = filtered.FindAll(x => x.ApparentLoad <= loadFilterTo);
            }
            else
            {
                filtered = filtered.FindAll(x => x.ApparentLoad <= MainWindow.MainWindow.defaultLoadToValue);
            }
            return filtered;
        }

        private static List<LightingFixtureType> FilterByLumFlux(List<LightingFixtureType> filtered, double fluxFilterFrom, double fluxFilterTo)
        {
            if (fluxFilterFrom >= 0)
            {
                filtered = filtered.FindAll(x => x.LightFlux >= fluxFilterFrom);
            }
            else
            {
                filtered = filtered.FindAll(x => x.LightFlux >= MainWindow.MainWindow.defaultFluxFromValue);
            }
            if (fluxFilterTo >= fluxFilterFrom)
            {
                filtered = filtered.FindAll(x => x.LightFlux <= fluxFilterTo);
            }
            else
            {
                filtered = filtered.FindAll(x => x.LightFlux <= MainWindow.MainWindow.defaultFluxToValue);
            }
            return filtered;
        }

        private static List<LightingFixtureType> FilterByTemperatureColor(List<LightingFixtureType> filtered, string temperatureColor)
        {
            if (temperatureColor != null)
            {
                switch (temperatureColor)
                {
                    case "3000K":
                        filtered = filtered.FindAll(x => x.TemperatureColor == 3000);
                        break;
                    case "4000K":
                        filtered = filtered.FindAll(x => x.TemperatureColor == 4000);
                        break;
                    case "5000K":
                        filtered = filtered.FindAll(x => x.TemperatureColor == 5000);
                        break;
                    case "5700K":
                        filtered = filtered.FindAll(x => x.TemperatureColor == 5700);
                        break;
                }
            }
            return filtered;
        }

        public static List<LightingFixtureType> SearchList(List<LightingFixtureType> types, string familyFilter, string categoryFilter,
        double loadFilterFrom, double loadFilterTo,
        double fluxFilterFrom, double fluxFilterTo,
        string temperatureColor, string photometricWeb)
        {
            List<LightingFixtureType> filtered = types;

            filtered = FilterByFamilyName(filtered, familyFilter);
            filtered = FilterByFamilyCategory(filtered, categoryFilter);
            filtered = FilterByApparentLoad(filtered, loadFilterFrom, loadFilterTo);
            filtered = FilterByLumFlux(filtered, fluxFilterFrom, fluxFilterTo);
            filtered = FilterByTemperatureColor(filtered, temperatureColor);
            filtered = FilterByPhotometricWeb(filtered, photometricWeb);
            return filtered;
        }
    }
}
