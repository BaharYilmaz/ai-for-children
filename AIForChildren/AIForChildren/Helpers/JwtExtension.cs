using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriPaneli.WebApi.Helpers
{
    //static olması gerekir
    public static class JwtExtension
    {
        public static void AddAplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Aplication-Error",message);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Expose-Header", "Aplication-Error");
        }
    }
}
