using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Repositories
{
    public class PedidoDetalleRepository
    {

        private readonly OrderManagementDbContext _context;

        public PedidoDetalleRepository(OrderManagementDbContext context)
        {
            _context = context;
        }
        public async Task<PedidoDetalle?> CrearDetalleAsync(PedidoDetalle detalle) 
        {
            try 
            {
                _context.PedidoDetalles.Add(detalle);
                await _context.SaveChangesAsync();
                return detalle;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
