using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Service
{
    public class AdicionarPedidoModel
    {
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public int QtdeProduto { get; set; }
        public double ValorPedido { get; set; }
        public int StatusPedido { get; set; }
    }
}
