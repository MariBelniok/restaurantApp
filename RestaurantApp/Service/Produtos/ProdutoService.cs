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
        /*public static List<ProdutoModel> BuscarProdutoDisponivel()
        {
            var todosProdutos = Dados.DadosLocais.produtos;
            var listaProdutosDisponiveis = new List<Produto>();

            return todosProdutos
                .Where(p => p.ProdutoDisponivel)
                .Select(a => new ProdutoModel()
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();
        }*/

        public static List<ProdutoModel> BuscarProdutos()
        {
            var listaProdutosDisponiveis = new List<ProdutoModel>();

            Dados.DadosLocais.produtos.ForEach(x =>
            {
                var prod = new ProdutoModel()
                {
                    ProdutoId = x.ProdutoId,
                    NomeProduto = x.NomeProduto,
                    ValorProduto = x.ValorProduto
                };

                listaProdutosDisponiveis.Add(prod);
            });

            return listaProdutosDisponiveis;
        }
    }
}

/*

 */