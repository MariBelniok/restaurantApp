using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public int QtdeProduto { get; set; }
        public float ValorPedido { get; set; }
        public int AndamentoPedido { get; set; }
    }
}
