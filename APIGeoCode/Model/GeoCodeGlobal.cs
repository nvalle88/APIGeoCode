using System.Collections.Generic;
namespace APIGeoCode.Model
{

    public class PlusCode
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Globalattribute
    {
        public string formatted_address { get; set; }
        public string long_name { get; set; }
        public string short_name { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public PlusCode2 plusCode { get; set; }
        public List<AddressComponent> addressComponents { get; set; }
        public List<string> types { get; set; }
    }

    public class AdministrativeAreaLevel_1 : Globalattribute
    {

    }

    public class Locality : Globalattribute
    {

    }
    public class Neighborhood : Globalattribute
    {

    }

    public class PointOfInterest : Globalattribute
    {
    }

    public class StreetAddress : Globalattribute
    {
       
    }

    public class Premise:Globalattribute
    {
    }

    public class PostalCode : Globalattribute
    {

    }
    public class SublocalityLevel_1 : Globalattribute
    {

    }
    public class AdministrativeAreaLevel_2 : Globalattribute
    {

    }

    public class Country : Globalattribute
    {

    }


    public class Route:Globalattribute
    {
       
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast2 northeast { get; set; }
        public Southwest2 southwest { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
        public Bounds bounds { get; set; }
    }

    public class PlusCode2
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public PlusCode2 plus_code { get; set; }
        public List<string> types { get; set; }
    }

    public class GeoCodeObject
    {
        public PlusCode plus_code { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}