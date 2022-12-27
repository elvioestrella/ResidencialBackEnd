using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class Visitantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CedulaPasaporte { get; set; }
        public int Hora { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Carro { get; set; }
        public string ColorCarro { get; set; }
        public string Placa { get; set; }
        public int PropietarioId { get; set; }
    }
}
