using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NBADataAccess
{
    public static class Utility
    {
        public static Uri baseAddress = new Uri("http://localhost:7557/api/");

        public static MediaTypeWithQualityHeaderValue acceptHeader =
            new MediaTypeWithQualityHeaderValue("application/json");

        public static string requestiUri = "Game";
    }
}
