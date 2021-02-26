﻿using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class PedidoModel
    {
        public int PedidoId { get; private set; }
        public int ComandaId { get; private set; }
        public int ProdutoId { get; set; }
        public int QuantidadePorProduto { get; set; }
        public int AndamentoDoProduto { get; set; }
    }
}
