using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    class Pedido
    {
        public int PedidoId { get; set; }
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadePorProduto { get; set; }
        public StatusPedido AndamentoDoPedido { get; set; }
    }
}
