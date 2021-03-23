using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    //Simple datamodel to handle interaction with the dataset - in this case the ./Data/CountryCodes.json file.
    public static class DataModel
    {
        // Public member to return all country codes
        public static List<CountryCode> CountryCodes { get
            {
                return GetAllCountryCodes();
            } 
        }

        // Private method used to read the CountryCodes.Json file. Could be any data source.
        // Returns a list of CountryCode
        private static List<CountryCode> GetAllCountryCodes()
        {
            string countryCodesJson = System.IO.File.ReadAllText("./Data/CountryCodes.json");
            return JsonConvert.DeserializeObject<List<CountryCode>>(countryCodesJson);
        }

        // Match CountryCode.DialCode for all CountryCodes with the user input. 
        // We do it this way to make sure we only get results for complete country codes (I.e. "+4" won't return a result for Denmark, but "+45" will. 
        // Returns a CountryCode if a match was found, otherwise null. 
        internal static CountryCode LookupNumber(string input)
        {
            List<CountryCode> countryCodes = GetAllCountryCodes();

            foreach(var countryCode in countryCodes)
            {
                if (input.Contains(countryCode.DialCode))
                {
                    return countryCode;
                }
            }

            return null;
        }
    }
}
