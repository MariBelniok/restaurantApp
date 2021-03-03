using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; } //PK
        public int ComandaId { get; set; } //FK
        public int ProdutoId { get; set; } //FK
        public int QtdeProduto { get; set; }
        public float ValorPedido { get; set; }
        public int AndamentoPedido { get; set; }
    }
}
