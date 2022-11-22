using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ibm_Test_Backend.Class
{
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geolocation geo { get; set; }
    }
}