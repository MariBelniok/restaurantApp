using RestaurantApp.Entities;

namespace RestaurantApp.Service.Pedidos.Models
{
    class PedidoModel
    {
        public int PedidoId { get; private set; }
        public int ComandaId { get; private set; }
        public int ProdutoId { get; set; }
        public int QuantidadePorProduto { get; set; }
        public StatusPedido AndamentoDoProduto { get; set; }
    }
}
