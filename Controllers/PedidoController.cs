using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using OrderManagement.Repositories;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
       
        private readonly PedidoRepository _repository;
        private readonly ProductoRepository _productoRepository;

        
        public PedidoController(PedidoRepository repository, ProductoRepository productoRepository)
        {
            _repository = repository;
            _productoRepository = productoRepository;
        }

        [HttpGet("Pedido")]
        public async Task<IActionResult> GettAll()
        {
            List<Pedido> pedidos = await _repository.ObtenerTodosAsync();
            return Ok(pedidos);
        }

        [HttpGet("Pedido/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Pedido? pedido = await _repository.ObtenerPorIdAsync(id);
            return Ok(pedido);
        }

        [HttpPost("Pedidos")]
        public async Task<IActionResult> Create([FromBody] Pedido itemPedido)
        {
            Pedido? pedido = await _repository.CrearPedidoAsync(itemPedido.ClienteId, itemPedido.PedidoDetalles);
            return Ok(pedido);
        }

        [HttpGet("Productos")]
        public async Task<IActionResult> GetAllProductos()
        {
            List<Producto> productos = await _productoRepository.ObtenerProductoAsync();
            return Ok(productos);
        }

        [HttpPost("Productos")]
        public async Task<IActionResult> CreateProducto([FromBody] Producto itemProducto)
        {
            Producto? producto = await _productoRepository.CrearProductoAsync(itemProducto);
            return Ok(producto);
        }

        [HttpDelete("Eliminar Pedido")]
        public async Task<IActionResult> EliminarPedido(int id) 
        {
            string mensaje = await _repository.Eliminar(id);
            return Ok(mensaje);
        }
    }
}