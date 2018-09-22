using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIGeoCode.Constant;
using APIGeoCode.Model;
using APIGeoCode.Util;
using Newtonsoft.Json;

namespace APIGeoCode.Service
{
    public static class GeocodeService
    {


        public static async Task<GeoCodeObject> GetGeocodeApiObject(double latitud, double longitud)
        {
            using (HttpClient client = new HttpClient())
            {
                var a = Configuration.GeocodeApiUrl + GeoCodeConstant.latlng + Convert.ToString(latitud).Replace(",", ".") + "," + Convert.ToString(longitud).Replace(",", ".") + GeoCodeConstant.key + Configuration.ApiKey;
                var response = await client.GetAsync(a);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return  JsonConvert.DeserializeObject<GeoCodeObject>(result);
                }
                return new GeoCodeObject();
            }
        }

        public static GeoCodeCompact GetGeoCodeObject(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                var geocodeResult = new GeoCodeCompact();
                geocodeResult.plusCode = geoCodeObject.plus_code;
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        switch (item_1)
                        {
                            case SearchPattern.administrative_area_level_1:
                                {
                                    geocodeResult.AdministrativeAreaLevel_1 = new AdministrativeAreaLevel_1 { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.administrative_area_level_2:
                                {
                                    geocodeResult.AdministrativeAreaLevel_2 = new AdministrativeAreaLevel_2 { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.country:
                                {
                                    geocodeResult.Country = new Country { place_id=item.place_id,geometry=item.geometry,   formatted_address=item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.locality:
                                {
                                    geocodeResult.Locality = new Locality { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.neighborhood:
                                {
                                    geocodeResult.Neighborhood = new Neighborhood { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.postal_code:
                                {
                                    geocodeResult.PostalCode = new PostalCode { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.route:
                                {
                                    geocodeResult.Route=new Route { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.sublocality_level_1:
                                {
                                    geocodeResult.SublocalityLevel_1 = new SublocalityLevel_1 { place_id = item.place_id, geometry = item.geometry,   formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                        }
                    }
                }
                return geocodeResult;
            }
            return new GeoCodeCompact();
        }


        public static List<List<AddressComponent>> GetCompletListAddressComponent(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                var listResult= new List<List<AddressComponent>>();
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        switch (item_1)
                        {
                            case SearchPattern.administrative_area_level_1:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.administrative_area_level_2:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.country:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.locality:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.neighborhood:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.postal_code:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.route:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                            case SearchPattern.sublocality_level_1:
                                {
                                    listResult.Add(item.address_components);
                                    break;
                                }
                        }
                    }
                }
                return listResult;
            }
            return new List<List<AddressComponent>>();
        }

        public static IDictionary<string,string> GetComplectDictionaryFormattedAddress(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                var listResult = new Dictionary<string,string>();
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        switch (item_1)
                        {
                            case SearchPattern.administrative_area_level_1:
                                {
                                    listResult.Add(item_1,item.formatted_address);
                                    break;
                                }
                            case SearchPattern.administrative_area_level_2:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.country:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.locality:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.neighborhood:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.postal_code:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.route:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                            case SearchPattern.sublocality_level_1:
                                {
                                    listResult.Add(item_1, item.formatted_address);
                                    break;
                                }
                        }
                    }
                }
                return listResult;
            }
            return new Dictionary<string,string>();
        }

        public static List<AddressComponent> GetCompactListAddressComponent(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                var listResult = new List<AddressComponent>();
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        switch (item_1)
                        {
                            case SearchPattern.administrative_area_level_1:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.administrative_area_level_2:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.country:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.locality:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.neighborhood:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.postal_code:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.route:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                            case SearchPattern.sublocality_level_1:
                                {
                                    listResult.Add(item.address_components[0]);
                                    break;
                                }
                        }
                    }
                }
                return listResult;
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressAdministrativeAreaLevel_2(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                string localidad = "";
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_2)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return localidad == "" ? Results.Undefined : localidad;
            }
            return Results.Undefined;
        }
        public static AddressComponent GetAdministrativeAreaLevel_2(GeoCodeObject geoCodeObject)
        {
            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_2)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }
        public static List<AddressComponent> GetListAdministrativeAreaLevel_2(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_2)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressAdministrativeAreaLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_1)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return Results.Undefined;
            }
            return Results.Undefined;
        }
        public static AddressComponent GetAdministrativeAreaLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_1)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }
        public static List<AddressComponent> GetListAdministrativeAreaLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.administrative_area_level_1)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressCountry(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.country)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return Results.Undefined;
            }
            return Results.Undefined;
        }

        public static AddressComponent GetCountry(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.country)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }

        public static List<AddressComponent> GetListCountry(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.country)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new  List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressPostalCode(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                string localidad = "";
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.postal_code)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return localidad == "" ? Results.Undefined : localidad;
            }
            return Results.Undefined;
        }
        public static AddressComponent GetPostalCode(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.postal_code)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }
        public static List<AddressComponent> GetListPostalCode(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.postal_code)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressLocality(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                string localidad = "";
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.locality)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return localidad == "" ? Results.Undefined : localidad;
            }
            return Results.Undefined;
        }

        public static AddressComponent GetLocality(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.locality)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }

        public static List<AddressComponent> GetListLocality(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.locality)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAddressSublocalityLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.sublocality_level_1)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return Results.Undefined;
            }
            return Results.Undefined;
        }

        public static  AddressComponent GetSublocalityLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.sublocality_level_1)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent(); 
            }
            return new AddressComponent();
        }

        public static List<AddressComponent> GetListSublocalityLevel_1(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.sublocality_level_1)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static string GetFormattedAaddressRoute(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                string localidad = "";
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.route)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return localidad == "" ? Results.Undefined : localidad;
            }
            return Results.Undefined;
        }

        public static AddressComponent GetRoute(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.route)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent();
            }
            return new AddressComponent();
        }

        public static List<AddressComponent> GetListRoute(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.route)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();
        }

        public static AddressComponent GetNeighborhood(GeoCodeObject geoCodeObject)
        {
            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.neighborhood)
                        {
                            return item.address_components[0];
                        }
                    }
                }
                return new AddressComponent(); 
            }
            return new AddressComponent();

        }
        public static string GetFormattedAddressNeighborhood(GeoCodeObject geoCodeObject)
        {
            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.neighborhood)
                        {
                            return item.formatted_address;
                        }
                    }
                }
                return Results.Undefined;
            }
            return Results.Undefined;

        }
        public static List<AddressComponent> GetListNeighborhood(GeoCodeObject geoCodeObject)
        {
            if (geoCodeObject != null)
            {
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        if (item_1 == SearchPattern.neighborhood)
                        {
                            return item.address_components;
                        }
                    }
                }
                return new List<AddressComponent>();
            }
            return new List<AddressComponent>();

        }
    }
}