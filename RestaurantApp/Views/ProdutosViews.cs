using RestaurantApp.Service;
using System;

namespace RestaurantApp.Views
{
    class ProdutoViews
    {
        //MOSTRAR MENU
        public static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("                   MENU:                  ");
            var produtos = ProdutoService.ListarMenu();

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