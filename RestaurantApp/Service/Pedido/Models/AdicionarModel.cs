using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Service
{
    public class AdicionarModel
    {
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadePorProduto { get; set; }
        public int AndamentoDoProduto { get; set; }
    }
}
