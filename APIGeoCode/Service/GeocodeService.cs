using System;
using System.Net.Http;
using System.Threading.Tasks;
using GeoCode.Constant;
using GeoCode.Model;
using GeoCode.Util;
using Newtonsoft.Json;

namespace GeoCode.Service
{
    public static class GeocodeService
    {
        public static async Task<Response> GetGeoCode(double latitud, double longitud)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var a = Configuration.GeocodeApiUrl + GeoCodeConstant.latlng + Convert.ToString(latitud).Replace(",", ".") + "," + Convert.ToString(longitud).Replace(",", ".") + GeoCodeConstant.key + Configuration.ApiKey;
                    var response = await client.GetAsync(a);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var geocodeApi = JsonConvert.DeserializeObject<GeoCodeObject>(result);
                        if (geocodeApi.status==GeoCodeConstant.OK)
                        {
                            var geoCode = GetGeoCodeObject(geocodeApi);
                            return new Response { ErrorMessage = "", Geocode = geoCode, Status = geocodeApi.status };
                        }
                        var error = await response.Content.ReadAsStringAsync();
                        var geocodeError = JsonConvert.DeserializeObject<Error>(error);
                        return new Response { ErrorMessage = geocodeError.error_message, Geocode = null, Status = geocodeError.status };
                    }
                    return new Response { ErrorMessage = Message.MennsageNotConnection, Geocode = null, Status = Message.NotConnection};
                }
            }
            catch (Exception ex)
            {
                return new Response { ErrorMessage = ex.Message, Geocode = null, Status = ex.InnerException.Message };
                throw;
            }
        }

        private static GeoCodeResult GetGeoCodeObject(GeoCodeObject geoCodeObject)
        {

            if (geoCodeObject != null)
            {
                var geocodeResult = new GeoCodeResult();
                geocodeResult.PlusCode = geoCodeObject.plus_code;
                foreach (var item in geoCodeObject.results)
                {
                    foreach (var item_1 in item.types)
                    {
                        switch (item_1)
                        {
                            case SearchPattern.administrative_area_level_1:
                                {
                                    geocodeResult.AdministrativeAreaLevel_1 = new AdministrativeAreaLevel_1 { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.administrative_area_level_2:
                                {
                                    geocodeResult.AdministrativeAreaLevel_2 = new AdministrativeAreaLevel_2 { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.country:
                                {
                                    geocodeResult.Country = new Country { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.locality:
                                {
                                    geocodeResult.Locality = new Locality { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.neighborhood:
                                {
                                    geocodeResult.Neighborhood = new Neighborhood { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.postal_code:
                                {
                                    geocodeResult.PostalCode = new PostalCode { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.route:
                                {
                                    geocodeResult.Route = new Route { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }
                            case SearchPattern.sublocality_level_1:
                                {
                                    geocodeResult.SublocalityLevel_1 = new SublocalityLevel_1 { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address, long_name = item.address_components[0].long_name, short_name = item.address_components[0].short_name };
                                    break;
                                }

                            case SearchPattern.premise:
                                {
                                    geocodeResult.Premise = new Premise { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address };
                                    break;
                                }
                            case SearchPattern.point_of_interest:
                                {
                                    geocodeResult.PointOfInterest = new PointOfInterest { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address };
                                    break;
                                }
                            case SearchPattern.street_address:
                                {
                                    geocodeResult.StreetAddress = new StreetAddress { types = item.types, addressComponents = item.address_components, plusCode = item.plus_code, place_id = item.place_id, geometry = item.geometry, formatted_address = item.formatted_address };
                                    break;
                                }
                        }
                    }
                }
                return geocodeResult;
            }
            return new GeoCodeResult();
        }
    }
}