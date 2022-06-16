using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM022PP0122.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }
        public String edad { get; set; }

        public String genero { get; set; }

        public DateTime fechaIngreso { get; set; }

        public Byte[] foto { get; set; }
    }
}
