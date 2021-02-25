using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using RestaurantApp.Entities;


namespace RestaurantApp.Dados
{
    class DadosLocais
    {

        public static void LerProdutos()
        {
            string caminhoProdutos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\MenuProdutos.csv";
            
            List<Produto> produtos = new List<Produto>();

            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDoProduto = produto.Split(",");

                int produtoId = int.Parse(dadosDoProduto[0]);
                string nomeProduto = dadosDoProduto[1];
                float valorProduto = float.Parse(dadosDoProduto[2], CultureInfo.InvariantCulture);
                bool statusProduto = bool.Parse(dadosDoProduto[3]);

                produtos.Add(new Produto
                {
                    ProdutoId = produtoId,
                    NomeProduto = nomeProduto,
                    ValorProduto = valorProduto,
                    ProdutoDisponivel = statusProduto
                });
            }
        }
    }
}