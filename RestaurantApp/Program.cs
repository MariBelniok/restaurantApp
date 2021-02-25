using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using RestaurantApp.Service;
using RestaurantApp.Entities;



namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Favor informar o numero da comanda: ");
            int numeroComanda = int.Parse(Console.ReadLine());

            Console.WriteLine("Favor informar o numero da mesa: ");
            int numeroMesa = int.Parse(Console.ReadLine());


            //MOSTRAR MENU
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("MENU: ");
            List<ProdutoModel> produtos = ProdutoService.ListarProdutos();

            foreach (ProdutoModel p in produtos)
            {
                Console.WriteLine($"{p.ProdutoId} - {p.NomeProduto} - R${p.ValorProduto:F2}");
            }
            Console.WriteLine("------------------------------------------");

            //PEDIDO CLIENTE
            Console.WriteLine("Favor realizar seu pedido. Máximo de 2 pedidos por cliente.");
            Console.WriteLine("Quantos items do menu deseja pedir? ");
            int numeroItems = int.Parse(Console.ReadLine());

            List<string> produtoPedido = new List<string>();
            for (int i = 1; i <= numeroItems; i++)
            {
                Console.WriteLine("Favor informar o número do item desejado: ");
                int produtoId = int.Parse(Console.ReadLine());

                //produtoPedido = PedidoService.AddProdutoMenu();
            }

            //MOSTRAR PEDIDO
            Console.WriteLine("PEDIDO: ");
            foreach(string obj in produtoPedido)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
