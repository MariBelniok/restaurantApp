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
            });;
        }

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
        public static float ValorProduto(int prodId, int quantidade)
        {
            float sum = 0;
            DadosLocais.listaProdutos.ForEach(x => {
                if (x.ProdutoId == prodId)
                {
                    sum += (x.ValorProduto * (float)quantidade);
                }
            });

            return sum;

        }
    }
}
