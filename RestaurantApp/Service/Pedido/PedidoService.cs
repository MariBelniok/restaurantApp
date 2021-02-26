using System.IO;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        public static float ValorTotalPedido = 0;

        public static List<string> produtoPedido = new List<string>();

        public static void AddProduto(int produtoId, int quantidadeItem)
        {
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();

            produtos.ForEach(p =>
            {
                if (p.ProdutoId == produtoId)
                {
                    produtoPedido.Add($"{p.ProdutoId},{p.NomeProduto},{quantidadeItem},{p.ValorProduto:F2},1");
                    SomarProdutos(p.ValorProduto);
                }
            });

        }

        public static void RemoveProduto(int produtoId)
        {
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();

            produtos.ForEach(p =>
            {
                if (p.ProdutoId == produtoId)
                {
                    produtoPedido.Remove($"{p.ProdutoId},{p.NomeProduto},{p.ValorProduto:F2}");
                    DiminuirProduto(p.ValorProduto);
                }
            });
        }

        public static float SomarProdutos(float valor)
        {
            return ValorTotalPedido += valor;
        }

        public static float DiminuirProduto(float valor)
        {
            return ValorTotalPedido -= valor;
        }
    }
}
