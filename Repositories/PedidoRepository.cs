using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Repositories
{
    public class PedidoRepository
    {
        private readonly OrderManagementDbContext _context;
        public PedidoRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido?> CrearPedidoAsync(int clienteId, List<PedidoDetalle> detalles) 
        {
            Pedido pedido = new Pedido();
            pedido.ClienteId = clienteId;
            pedido.Fecha = DateTime.Now;

            decimal total = 0;

            foreach (PedidoDetalle detalle in detalles)
            {
                Producto? producto = await _context.Productos.FindAsync(detalle.ProductoId);

                if (producto == null)
                    return null;
                detalle.PrecioUnitario = producto.Precio;
                total += detalle.Cantidad * detalle.PrecioUnitario;

                
            }
            pedido.Total = total;

            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;

        }
       

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id) 
        {
           return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.PedidoDetalles)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        internal async Task<string> Eliminar(int id)
        {
            Pedido? pedidoEliminar = await _context.Pedidos.FindAsync(id);

            if (pedidoEliminar == null)
                return "Pedido no encontrado";

            else
            {
                _context.Pedidos.Remove(pedidoEliminar);
                await _context.SaveChangesAsync();
                return "Pedido eliminado";
            }
        }
    }

        
}
