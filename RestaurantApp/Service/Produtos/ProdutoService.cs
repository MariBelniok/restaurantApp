using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using RestaurantApp.Entities;
using RestaurantApp.Service;

namespace RestaurantApp.Service
{
    class ProdutoService
    {
        //RETORNA APENAS PRODUTOS DISPONIVEIS
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

/*

 */