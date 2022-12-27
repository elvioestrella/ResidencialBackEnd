using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class Permiso
    {
        public int Id { get; set; }
        public bool Vista { get; set; }
        public bool Crear { get; set; }
        public bool Modificar { get; set; }
        public bool Eliminar { get; set; }
    }
}
