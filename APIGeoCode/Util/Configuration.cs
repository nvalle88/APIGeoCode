namespace GeoCode.Util
{
    public static class Configuration
    {
        public static string GeocodeApiUrl { get { return "https://maps.googleapis.com/maps/api/geocode/json?"; } set {; } }
        public static string ApiKey { get; set; }
    }
}
