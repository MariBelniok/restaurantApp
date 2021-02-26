using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using RestaurantApp.Service;
using RestaurantApp.Entities;
using RestaurantApp.Views;



namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Numero da comanda: ");
            int numeroComanda = int.Parse(Console.ReadLine());

            Console.Write("Numero da mesa: ");
            int numeroMesa = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantidade de pessoas: ");
            int qtePessoas = int.Parse(Console.ReadLine());

            float valorTotal = (float)qtePessoas * 70;

            Console.WriteLine("BEM VINDO AO RESTAURANTE SUTEKINA RANCHI");
            Console.WriteLine($"SERa ADICIONADO {qtePessoas} AO RODIZIO");
            Console.WriteLine("VALOR DO RODIZIO INDIVIDUAL: R$70,00");
            Console.WriteLine($"VALOR TOTAL ADICIONADO A COMANDA: {valorTotal:F2}");

            Console.WriteLine("Deseja continuar para pedidos: (s/n)");
            char continuarComanda = char.Parse(Console.ReadLine());
            ComandaViews.ContinuarComanda(continuarComanda);
            

            
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

            List<string> produtoPedido = PedidoService.produtoPedido;
            for (int i = 1; i <= numeroItems; i++)
            {
                Console.WriteLine("Favor informar o número do item desejado: ");
                int produtoId = int.Parse(Console.ReadLine());
                PedidoService.AddProdutoMenu(produtoId);
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
