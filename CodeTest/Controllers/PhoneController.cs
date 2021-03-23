using CodeTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Controllers
{
    // Simple controller used to accept the ajax request, call the relevant data model and return a json result.
    // NOTE: For this particular endpoint we simply return json.
    public class PhoneController : Controller
    {
        [Route("/Phone/GetCountry/{input}")]
        public JsonResult GetCountry(string input)
        {
            if (input == null)
            {
                return new JsonResult("");
            }

            // We need to add the "+" here because of issues with double escaping when including the plus sign in the URI when calling the controller. 
            // I'm sure there must be a better solution than this but it was the best I could find on short notice. 
            CountryCode countryCode = DataModel.LookupNumber("+" + input);

            return new JsonResult(countryCode);
        }
    }
}
