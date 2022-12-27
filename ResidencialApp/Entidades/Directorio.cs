using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class Directorio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Icono { get; set; }
        public string RedirectTo { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Extension { get; set; }
        public string Whatsapp { get; set; }
        public string Correo { get; set; }
        public int Ordenar { get; set; }
        public bool Estado { get; set; }
        public int ResidencialId { get; set; }
    }
}
