using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Entities;
using RestaurantApp.Service.Comanda;

namespace RestaurantApp.Service
{
    class ProdutoService
    {
        public List<ProdutoModel> BuscarProduto()
        {
            var listaProdutos = new List<Produto>();

            return listaProdutos
                .Where(p => p.ProdutoDisponivel)
                .Select(a => new ProdutoModel()
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();
        }
    }
}
