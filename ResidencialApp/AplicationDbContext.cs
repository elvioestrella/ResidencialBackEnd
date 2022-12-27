using Microsoft.EntityFrameworkCore;
using ResidencialApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidencialApp
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Residencial> Residencial { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Directorio> Directorio { get; set; }
        public DbSet<Inmueble> Inmueble { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilPermiso> PerfilPermiso { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoInmueble> TipoInmueble { get; set; }
        public DbSet<Visitantes> Visitantes { get; set; }


    }
}
