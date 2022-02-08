using System;
using System.Collections.Generic;
using System.Text;

namespace AppHuac.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public int? AreaId { get; set; }
        public List<int> ListaIdRoles { get; set; }
        public List<int> ListaIdPermisos { get; set; }
        public List<string> ListaRoles { get; set; }
    }
}
