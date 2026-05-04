using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Repositories
{
    public class ClienteRepository
    {

        private readonly OrderManagementDbContext _context;

        public ClienteRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<Cliente?> CrearClienteAsync(Cliente cliente)
        { 
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception)
            {
                // Manejar la excepción según sea necesario
                return null; // O lanzar una excepción personalizada
            }   
        }

        public async Task<string> Eliminar(int id) 
        {
           Cliente? clienteEliminar = await _context.Clientes.FindAsync(id);

            if (clienteEliminar == null)
                return "Cliente no encontrado";
            else 
            {
                _context.Clientes.Remove(clienteEliminar);
                await _context.SaveChangesAsync();
                return "Cliente eliminado";
            }
        }


      
    }
}
