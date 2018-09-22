﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APIGeoCode.Model
{
   public class GeoCodeCompact
    {
        public Route Route { get; set; }
        public AdministrativeAreaLevel_1 AdministrativeAreaLevel_1 { get; set; }
        public AdministrativeAreaLevel_2 AdministrativeAreaLevel_2 { get;set; }
        public Country Country { get; set; }
        public Locality Locality { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public PostalCode PostalCode { get; set; }
        public SublocalityLevel_1 SublocalityLevel_1 { get; set; }
        public PlusCode plusCode { get; set; }
    }
}