using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Entities;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        //LISTA OS PEDIDOS REALIZADOS
        public static List<PedidoModel> ListarPedidos()
        {
            var pedidos = new List<PedidoModel>();
            DadosLocais.listaPedidos.ForEach(x =>
            {
                var pedido = new PedidoModel()
                {
                    PedidoId = x.PedidoId,
                    ProdutoId = x.ProdutoId,
                    ComandaId = x.ComandaId,
                    QuantidadePorProduto = x.AndamentoDoPedido,
                    ValorPedido = x.ValorPedido,
                    AndamentoDoProduto = x.AndamentoDoPedido
                };
                pedidos.Add(pedido);
            });

            return pedidos;
        }
        //ADICIONA PEDIDOS EM MODEL AUXILIAR
        public static void AddPedido(AdicionarModel model)
        {
            DadosLocais.listaPedidos.Add(new Pedido()
            {
                PedidoId = DadosLocais.listaPedidos.Count + 1,
                ComandaId = model.ComandaId,
                ProdutoId = model.ProdutoId,
                QuantidadePorProduto = model.QuantidadePorProduto,
                ValorPedido = model.ValorPedido,
                AndamentoDoPedido = model.AndamentoDoProduto
            }); ;
        }

        //REMOVE UM PRODUTO
        public static void RemoveProduto(int pedidoId)
        {
            DadosLocais.listaPedidos.ForEach(x =>
            {
                if (x.PedidoId == pedidoId)
                {
                    x.AndamentoDoPedido = 2;
                }
            });
        }

        //ATUALIZA UM PRODUTO
        public static void AtualizarProduto(int pedidoId, int quantidadeItem)
        {
            DadosLocais.listaPedidos.ForEach(x =>
            {
                if (x.PedidoId == pedidoId)
                {
                    DadosLocais.listaPedidos.ForEach(p =>
                    {
                        p.QuantidadePorProduto = quantidadeItem;
                        p.ValorPedido = ValorProduto(p.ProdutoId, quantidadeItem);
                    });
                }
            });
        }

        //CALCULA O VALOR TOTAL DO PEDIDO
        public static float ValorProduto(int prodId, int quantidade)
        {
            float sum = 0;
            DadosLocais.listaProdutos.ForEach(x =>
            {
                if (x.ProdutoId == prodId)
                {
                    sum += (x.ValorProduto * (float)quantidade);
                }
            });

            return sum;

        }

        //VERFICA SE O PEDIDO ESCOLHIDO PODE SER CANCELADO OU EDITADO
        public static bool PedidoCorreto(int pedidoId)
        {
            bool pedidoCorreto = false;
            if(pedidoId == DadosLocais.listaPedidos.Count)
            {
                pedidoCorreto = true;
            }
            else
            {
                pedidoCorreto = false;
            }

            return pedidoCorreto;
        }
    }
}
