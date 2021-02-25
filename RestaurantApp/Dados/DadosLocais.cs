using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Service;

namespace RestaurantApp.Dados
{
    class DadosLocais
    {
        public static string caminhoProdutos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\MenuProdutos.csv";

        public static List<Produto> LerProdutos()
        {

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
            return produtos;
        }

        public static List<Mesa> LerMesas()
        {
            List<Mesa> mesas = new List<Mesa>();

            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDaMesa = produto.Split(",");

                int mesaId = int.Parse(dadosDaMesa[0]);
                int capacidadeMesa = int.Parse(dadosDaMesa[1]);
                bool mesaDisponivel = bool.Parse(dadosDaMesa[2]);

                mesas.Add(new Mesa
                {
                    MesaId = mesaId,
                    CapacidadePorMesa = capacidadeMesa,
                    MesaDisponivel = mesaDisponivel
                });
            }
            return mesas;
        }
    }
}