﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            //Captura error
            response.Headers.Add("Application-Error", message);
            //Permite el funcionamiento de la captura del error.-
            response.Headers.Add("Access-Control-Expose-Headers",  "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin",  "*");
        }
    }
}
