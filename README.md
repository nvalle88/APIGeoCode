# APIGeoCode
Easy to use, you just need to configure your api key

      Configuration.ApiKey = "your api key here";
Configuration also has the Uri address of the api which you can modify if necessary in

      Configuration.GeocodeApiUrl = "your api url here";
by default is used: https://maps.googleapis.com/maps/api/geocode/json?

Once the configuration is done we just have to execute the method

      await GeocodeService.GetGeoCode (Latitude, Longitude);
the method returns a Response Object structured as follows

     public class Response
     {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public GeoCodeResult Geocode { get; set; }
     }
in case the call to the api is satisfactory

ErrorMessage = ""

Geocode returns the following structure

      public class GeoCodeResult
      {
          public Route Route {get; set; }
          public AdministrativeAreaLevel_1 AdministrativeAreaLevel_1 {get; set; }
          public AdministrativeAreaLevel_2 AdministrativeAreaLevel_2 {get; set; }
          public Country Country {get; set; }
          public Locality Locality {get; set; }
          public Neighborhood Neighborhood {get; set; }
          public PostalCode PostalCode {get; set; }
          public SublocalityLevel_1 SublocalityLevel_1 {get; set; }
          public PlusCode PlusCode {get; set; }
          public Premise Premise {get; set; }
          public PointOfInterest PointOfInterest {get; set; }
          public StreetAddress StreetAddress {get; set; }
      }

    some of these properties may be null since the api does not always have enough information.
Status = "OK"

In the case of an error in the call to the GeocodeApi the Response Object

      public class Response
      {
       public string Status {get; set; }
       public string ErrorMessage {get; set; }
       public GeoCodeResult Geocode {get; set; }
      }
Return the following information

ErrorMessage returns the error message

Geocode = null

Status type of error
