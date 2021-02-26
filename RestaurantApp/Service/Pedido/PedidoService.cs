using System.IO;
using System.Collections.Generic;
using System.Globalization;
using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        /*public static List<Pedido> NovoPedido()
        {
            List<Pedido> pedidos = new List<Pedido>();

            pedidos.Add(new Pedido {
                PedidoId = pedidoId,
                ComandaId = comandaId,
                ProdutoId = produtoId,
                QuantidadePorProduto = Quantidade,
            });

            return pedidos;
        }*/
        public static List<string> produtoPedido = new List<string>();
        public static List<string> AddProdutoMenu(int produtoId)
        {
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();

            foreach (ProdutoModel p in produtos)
            {
                if (p.ProdutoId == produtoId)
                {
                    produtoPedido.Add($"{p.ProdutoId},{p.NomeProduto},{p.ValorProduto}.00");
                }
            }

            return produtoPedido;
        }
    }
}
