using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResidencialApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResidencialApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidencialController : ControllerBase
    {
        private readonly ILogger<ResidencialController> _logger;
        private readonly AplicationDbContext _context;

        public ResidencialController(ILogger<ResidencialController> logger, AplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        // GET: api/<ResidencialController>
        [HttpGet]
        public IEnumerable<Residencial> Get()
        {
            return _context.Residencial.ToList();
        }

        // GET api/<ResidencialController>/5
        [HttpGet("{id}")]
        public Residencial Get(int id)
        {
            return _context.Residencial.Where(x => x.Id == id).SingleOrDefault();
        }

        // POST api/<ResidencialController>
        [HttpPost]
        public bool Post([FromBody] Residencial residencial)
        {
            try
            {
                _context.Add(residencial);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // PUT api/<ResidencialController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Residencial residencial)
        {
            try
            {
                var res = _context.Residencial.Where(x => x.Id == id).SingleOrDefault();
                res.Nombre = residencial.Nombre;
                res.Telefono = residencial.Telefono;
                res.Extension = residencial.Extension;
                res.Whapsapp = residencial.Whapsapp;
                res.Correo = residencial.Correo;
                res.Instagram = residencial.Instagram;
                res.Facebook = residencial.Facebook;
                res.Web = residencial.Web;
                res.Logo = residencial.Logo;
                res.Direccion = residencial.Direccion;
                res.Direccion2 = residencial.Direccion2;
                res.PaisId = residencial.PaisId;
                res.ProvinciaId = residencial.ProvinciaId;
                res.MunicipioId = residencial.MunicipioId;
                res.DistritoMunicipalId = residencial.DistritoMunicipalId;
                res.Estado = residencial.Estado;
                res.FechaCreacion = residencial.FechaCreacion;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // DELETE api/<ResidencialController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                var res = _context.Residencial.Where(x => x.Id == id).SingleOrDefault();
                _context.Residencial.Remove(res);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
