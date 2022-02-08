using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppHuac.Models
{
    [Table("User")]
    public class UserDb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Solo insertar de TypeLocalStorage
        [MaxLength(255)]
        public string Codigo { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Correo { get; set; }
        [MaxLength(255)]
        public string Area { get; set; }

        public UserDb() { }
        public UserDb(string Codigo, string Nombre, string Correo)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Correo = Correo;
        }
    }
}
