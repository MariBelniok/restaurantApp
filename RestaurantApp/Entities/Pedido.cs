using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadePorProduto { get; set; }
        public float ValorPedido { get; set; }
        public int AndamentoDoPedido { get; set; }
    }
}
