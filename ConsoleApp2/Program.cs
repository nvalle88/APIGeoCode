using System;
using System.Threading.Tasks;
using GeoCode.Service;
using GeoCode.Util;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.ApiKey = "";

            example().GetAwaiter().GetResult();

        }

        private static async Task example()
        {
            var inicio= DateTime.Now;
            var geocode = await GeocodeService.GetGeoCode(40.670602, -73.937918);
            var total = (DateTime.Now - inicio).TotalMilliseconds;
            Console.WriteLine("Tiempo total consumir :" + Convert.ToString(total));
            Console.ReadLine();
            example().GetAwaiter().GetResult();
        }
    }
}
