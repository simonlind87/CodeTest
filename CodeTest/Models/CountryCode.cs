using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class CountryCode
    {
        public string Name { get; set; }
        [JsonProperty("dial_code")]
        public string DialCode { get; set; }
        public string Code { get; set; }
    }
}
