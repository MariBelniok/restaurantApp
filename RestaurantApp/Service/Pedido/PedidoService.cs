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
        public static List<PedidoModel> BuscarPedidos(int comandaId)
        {
            var contexto = new RestauranteContexto();
            var pedidos = 
                contexto.Pedido
                .Where(ped => ped.ComandaId == comandaId)
                .Select(p =>  new PedidoModel()
                {
                    PedidoId = p.PedidoId,
                    ProdutoId = p.ProdutoId,
                    ComandaId = p.ComandaId,
                    QtdeProduto = p.QtdeProduto,
                    ValorPedido = p.ValorPedido,
                    StatusPedido = p.StatusPedido
                }).ToList();

            return pedidos;
        }
        //ADICIONA PEDIDOS EM MODEL AUXILIAR
        public static void AdicionarPedido(AdicionarPedidoModel model)
        {
            var contexto = new RestauranteContexto();
            var pedido = (new Pedido()
            {
                PedidoId = contexto.Pedido.Count() + 1,
                ComandaId = model.ComandaId,
                ProdutoId = model.ProdutoId,
                QtdeProduto = model.QtdeProduto,
                ValorPedido = model.ValorPedido,
                StatusPedido = model.StatusPedido
            });
            contexto.Add(pedido);
            contexto.SaveChanges();
        }

        //REMOVE UM PRODUTO
        public static void RemoverPedido(int pedidoId)
        {
            var contexto = new RestauranteContexto();
            var pedido = contexto.Pedido
                .Where(ped => ped.PedidoId == pedidoId)
                .FirstOrDefault();

            pedido.StatusPedido = 2;
            contexto.SaveChanges();
        }

        //ATUALIZA UM PRODUTO
        public static void AtualizarPedido(int pedidoId, int quantidadeItem)
        {
            var contexto = new RestauranteContexto();
            if(contexto.Pedido.Count() == pedidoId)
            {
                var pedido = contexto.Pedido
                            .Where(ped => ped.PedidoId == pedidoId)
                            .FirstOrDefault();

                pedido.QtdeProduto = quantidadeItem;
                pedido.ValorPedido = ValorPedido(pedido.ProdutoId, quantidadeItem);
                contexto.SaveChanges();
            }
            
        }

        //CALCULA O VALOR TOTAL DO PEDIDO
        public static double ValorPedido(int prodId, int quantidade)
        {
            var contexto = new RestauranteContexto();
            return contexto.Produto
                    .Where(p => p.ProdutoId == prodId)
                    .Sum(p => p.ValorProduto * quantidade);
        }

        //VERFICA SE O PEDIDO ESCOLHIDO PODE SER CANCELADO OU EDITADO
        public static bool PedidoCorreto(int pedidoId)
        {
            var contexto = new RestauranteContexto();
            bool pedidoCorreto = false;
            if (pedidoId == contexto.Pedido.Count())
            {
                pedidoCorreto = true;
            }

            return pedidoCorreto;
        }
    }
}