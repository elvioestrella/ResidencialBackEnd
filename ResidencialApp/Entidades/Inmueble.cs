using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class Inmueble
    {
        public int Id { get; set; }
        public int TipoInmuebleId { get; set; }
        public string NumeroInmueble { get; set; }
        public string Apartamento { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ResidencialId { get; set; }
        public int PropietarioId { get; set; }
    }
}
