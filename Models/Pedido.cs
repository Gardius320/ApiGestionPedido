namespace OrderManagement.Models
{
    public class Pedido
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public Cliente? Cliente { get; set; }

        public List<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

        

    }
}
