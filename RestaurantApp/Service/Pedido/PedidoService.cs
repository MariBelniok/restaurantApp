﻿using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Entities;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        public static float ValorTotalPedido = 0;

        public static List<string> produtoPedido = new List<string>();

        public static void AddProduto(AdicionarModel model)
        {
            DadosLocais.listaPedidos.Add(new Pedido()
            {
                PedidoId = DadosLocais.listaStatusPedidos.Count + 1,
                ComandaId = model.ComandaId,
                ProdutoId = model.ProdutoId,
                QuantidadePorProduto = model.QuantidadePorProduto,
                AndamentoDoPedido = model.AndamentoDoProduto
            });
        }

        public static void RemoveProduto(int pedidoId)
        {
            DadosLocais.listaPedidos.ForEach(p => 
            { 
                if(p.PedidoId == pedidoId)
                {
                    p.AndamentoDoPedido = 3;
                }
            });
        }

        public static void AtualizarProduto(int pedidoId, int quantidadeItem)
        {
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();
            List<Pedido> pedidos = Dados.DadosLocais.LerPedidos();

            var caminhoPedidos = Dados.DadosLocais.caminhoPedidos;

            File.WriteAllText(caminhoPedidos, string.Empty);

            pedidos.ForEach(x =>
            {
                if (x.PedidoId == pedidoId)
                {
                    produtos.ForEach(p =>
                    {
                        produtoPedido.Add(string.Join(',', pedidoId, ComandaViews.numeroComanda, p.ProdutoId, quantidadeItem, "1"));
                        SomarProdutos(p.ValorProduto, quantidadeItem);
                    });
                }

            });
        }

        public static float SomarProdutos(float valor, int quantidade)
        {
            return ValorTotalPedido += (valor * quantidade);
        }

        public static float DiminuirProduto(float valor, int quantidade)
        {
            return ValorTotalPedido -= (valor * quantidade);
        }
    }
}
