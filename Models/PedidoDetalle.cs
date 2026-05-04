namespace OrderManagement.Models
{
    public class PedidoDetalle
    {

        public int Id { get; set; }
        public int PedidoOld { get; set; }
        public int PedidoId { get; set; }
        
        public int ProductoOld { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Pedido? Pedido { get; set; }

        public int ProductoId { get; set; }     
        public Producto? Producto { get; set; }


    }
}
