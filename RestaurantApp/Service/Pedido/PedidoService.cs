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
        public static List<PedidoModel> BuscarPedidos()
        {
            var pedidos = new List<PedidoModel>();
            Dados.Dados.listaPedidos.ForEach(x =>
            {
                var pedido = new PedidoModel()
                {
                    PedidoId = x.PedidoId,
                    ProdutoId = x.ProdutoId,
                    ComandaId = x.ComandaId,
                    QtdeProduto = x.QtdeProduto,
                    ValorPedido = x.ValorPedido,
                    AndamentoPedido = x.AndamentoPedido
                };
                pedidos.Add(pedido);
            });

            return pedidos;
        }
        //ADICIONA PEDIDOS EM MODEL AUXILIAR
        public static void AdicionarPedido(AdicionarPedidoModel model)
        {
            Dados.Dados.listaPedidos.Add(new Pedido()
            {
                PedidoId = Dados.Dados.listaPedidos.Count + 1,
                ComandaId = model.ComandaId,
                ProdutoId = model.ProdutoId,
                QtdeProduto = model.QtdeProduto,
                ValorPedido = model.ValorPedido,
                AndamentoPedido = model.AndamentoPedido
            }); ;
        }

        //REMOVE UM PRODUTO
        public static void RemoverPedido(int pedidoId)
        {
            Dados.Dados.listaPedidos.ForEach(x =>
            {
                if (x.PedidoId == pedidoId)
                {
                    x.AndamentoPedido = 2;
                }
            });
        }

        //ATUALIZA UM PRODUTO
        public static void AtualizarPedido(int pedidoId, int quantidadeItem)
        {
            Dados.Dados.listaPedidos.ForEach(p =>
            {
                if (p.PedidoId == pedidoId)
                {
                    p.QtdeProduto = quantidadeItem;
                    p.ValorPedido = ValorPedido(p.ProdutoId, quantidadeItem);
                }
            });
        }

        //CALCULA O VALOR TOTAL DO PEDIDO
        public static float ValorPedido(int prodId, int quantidade)
        {
            return Dados.Dados.listaProdutos
                    .Where(p => p.ProdutoId == prodId)
                    .Sum(p => p.ValorProduto * quantidade);
        }

        //VERFICA SE O PEDIDO ESCOLHIDO PODE SER CANCELADO OU EDITADO
        public static bool PedidoCorreto(int pedidoId)
        {
            bool pedidoCorreto = false;
            if(pedidoId == Dados.Dados.listaPedidos.Count)
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
