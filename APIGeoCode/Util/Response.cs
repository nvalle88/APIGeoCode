using System;
using System.Collections.Generic;
using System.Text;
using GeoCode.Model;

namespace GeoCode.Util
{
    public class Response
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public GeoCodeResult Geocode { get; set; }
    }
}
