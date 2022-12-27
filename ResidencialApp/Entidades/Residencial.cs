using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class Residencial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public string Whapsapp { get; set; }
        public string Correo { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Web { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public int PaisId { get; set; }
        public int ProvinciaId { get; set; }
        public int MunicipioId { get; set; }
        public int? DistritoMunicipalId { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
