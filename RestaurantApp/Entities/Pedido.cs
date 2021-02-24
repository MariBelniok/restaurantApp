using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    class Pedido
    {
        public int PedidoId { get; private set; }
        public int ComandaId { get; private set; }
        public int ProdutoId { get; set; }

        public int QuantidadePorProduto { get; set; }
        public StatusPedido AndamentoDoProduto { get; set; }
    }
}
