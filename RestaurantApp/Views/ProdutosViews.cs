using RestaurantApp.Service;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RestaurantApp.Views
{
    class ProdutosViews
    {
        public static void MostrarMenu()
        {
            //MOSTRAR MENU
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("MENU: ");
            var produtos = ProdutoService.ListarProdutos();

            foreach (ProdutoModel p in produtos)
            {
                if (p.ValorProduto == 0.00)
                {
                    Console.WriteLine($"{p.ProdutoId} - {p.NomeProduto} - INCLUSO NO RODIZIO");
                }
                else
                {
                    Console.WriteLine($"{p.ProdutoId} - {p.NomeProduto} - R${p.ValorProduto:F2}");
                }
                
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
        }
    }
}
