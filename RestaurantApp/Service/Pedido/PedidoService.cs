using System.IO;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        public static List<string> produtoPedido = new List<string>();
        public static void AddProduto(int produtoId)
        {
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();

            produtos.ForEach(p =>
            {
                if (p.ProdutoId == produtoId)
                {
                    produtoPedido.Add($"{p.ProdutoId},{p.NomeProduto},{p.ValorProduto:F2}");
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
            float sum = 0;
            sum += valor;

            return sum;
        }

        public static float DiminuirProduto(float valor)
        {
            float sum = 0;
            sum += valor;

            return sum;
        }

    }
}
