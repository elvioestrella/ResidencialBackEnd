using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp.Entidades
{
    public class PerfilPermiso
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public int PerfilId { get; set; }
    }
}
