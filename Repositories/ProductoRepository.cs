using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Repositories
{
    public class ProductoRepository
    {

        private readonly OrderManagementDbContext _context;

        public ProductoRepository(OrderManagementDbContext context)
        {
            _context = context;
        }


        public async Task<List<Producto>> ObtenerProductoAsync() 
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(int id) 
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto?> CrearProductoAsync(Producto producto) 
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        public async Task<string> Eliminar(int id) 
        {
            Producto? productoEliminar = await _context.Productos.FindAsync(id);
            if (productoEliminar == null)
                return "Producto no encontrado";
            else 
            {
                _context.Productos.Remove(productoEliminar);
                await _context.SaveChangesAsync();
                return "Producto Eliminado";
            }            
        }

        
    }
}
