using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum PhoneType
{
    Home,
    Mobile,
    Business
}


namespace CodeTest.Models
{
    public class PhoneNumber
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }

        public PhoneNumber(PhoneType type)
        {
            Type = type;
        }
    }
}
