using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppHuac.Models
{
    public class Response<T>
    {
        public string Mensaje { get; set; }
        public T Dato { get; set; }
        public string MensajeDev { get; set; }
        public bool Success { get; set; }
    }

}
