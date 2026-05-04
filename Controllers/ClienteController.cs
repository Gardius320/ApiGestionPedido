using Microsoft.AspNetCore.Http;
using OrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Repositories;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;
        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Clientes")]
        public async Task<IActionResult> GetAll()
        {
            List<Cliente> clientes = await _repository.ObtenerTodosAsync();
            return Ok(clientes);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Create(Cliente itemCliente)
        {
            Cliente? clienteCreado = await _repository.CrearClienteAsync(itemCliente);
            return Ok(clienteCreado);
        }

        [HttpGet("ObtenerCliente")]
        public async Task<IActionResult> ObtenerCliente(int id)
        {
            Cliente? datoCliente = await _repository.ObtenerPorIdAsync(id);

            if (datoCliente == null)
            {
                return Ok("Cliente no encontrado");
            }
            return Ok(datoCliente);

        }
        [HttpDelete("EliminarCliente")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            string mensaje = await _repository.Eliminar(id);
            return Ok(mensaje);

        }


    }

}
