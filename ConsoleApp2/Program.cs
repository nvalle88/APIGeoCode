using System;
using System.Threading.Tasks;
using APIGeoCode.Service;
using APIGeoCode.Util;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.ApiKey = "API KEY";

            example().GetAwaiter().GetResult();

        }

        private static async Task example()
        {
            var inicio= DateTime.Now;
            var geocode = await GeocodeService.GetGeocodeApiObject(40.670602, -73.937918);
            var total = (DateTime.Now - inicio).TotalMilliseconds;
            Console.WriteLine("Tiempo en consumir Api :" + Convert.ToString(total));
            inicio = DateTime.Now;
            var GeoObgetc = GeocodeService.GetGeoCodeObject(geocode);
            total = (DateTime.Now - inicio).TotalMilliseconds;
            Console.WriteLine("Tiempo en consultar método :" + Convert.ToString(total));

            Console.ReadLine();
            example().GetAwaiter().GetResult();
        }
    }
}
