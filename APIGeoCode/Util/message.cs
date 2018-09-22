using System;
using System.Collections.Generic;
using System.Text;

namespace GeoCode.Util
{
    public static class Message
    {
        public static string NotConnection { get { return "NOT CONNECTION"; } }
        public static string MennsageNotConnection { get { return "Check the 'GeocodeApiUrl' settings, or check if you are connected to the internet"; } }
    }
}
