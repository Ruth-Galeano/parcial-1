using Microsoft.AspNetCore.Mvc;
using Parcial1.Models;
using Parcial1.Services;

namespace Parcial1.Controllers
{
    [ApiController]
    [Route("api/cliente/[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService clienteService;
        private IConfiguration configuration;

        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteService = new ClienteService(configuration.GetConnectionString("postgresDB"));
        }
        [HttpGet("ListarCliente")]
        public ActionResult<List<ClienteModel>> ListarCliente()
        {
            var resultado = clienteService.listarCliente();
            return Ok(resultado);
        }

        [HttpGet("ConsultarCliente/{id}")]
        public ActionResult<ClienteModel> ConsultarCliente(int id)
        {
            var resultado = this.clienteService.consultarCliente(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCliente")]
        public ActionResult<string> insertarCliente(ClienteModel modelo)
        {
            var resultado = this.clienteService.insertarCliente(new ClienteModel
            {
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Documento = modelo.Documento,
                FechaNacimiento = modelo.FechaNacimiento,
                IdCiudad = modelo.IdCiudad,
                Nacionalidad = modelo.Nacionalidad,

            }); 
            return Ok(resultado);
        }

        [HttpPut("modificarCliente/{id}")]
        public ActionResult<string> modificarCliente(ClienteModel modelo, int id)
        {
            var resultado = this.clienteService.modificarCliente(new ClienteModel
            {
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Documento = modelo.Documento,
                FechaNacimiento = modelo.FechaNacimiento,
                IdCiudad = modelo.IdCiudad,
                Nacionalidad = modelo.Nacionalidad,
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCliente/{id}")]
        public ActionResult<string> eliminarCliente(int id)
        {
            var resultado = this.clienteService.eliminarCliente(id);
            return Ok(resultado);
        }
    }
}

