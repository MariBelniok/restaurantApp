using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Service
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get;  set; }
        public float ValorProduto { get;  set; }


        public override string ToString()
        {
            return $"{ProdutoId}, {NomeProduto}, {ValorProduto}";
        }
    }
}
