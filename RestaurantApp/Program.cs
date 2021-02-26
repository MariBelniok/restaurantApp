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

            ComandaViews.IniciarComanda();
            ComandaViews.ContinuarComanda();

            ProdutosViews.MostrarMenu();

            
    

            //PEDIDO CLIENTE
            Console.WriteLine("Favor realizar seu pedido. Máximo de 2 pedidos por cliente.");
            Console.WriteLine("Quantos items do menu deseja pedir? ");
            int numeroItems = int.Parse(Console.ReadLine());

            List<string> produtoPedido = PedidoService.produtoPedido;
            for (int i = 1; i <= numeroItems; i++)
            {
                Console.WriteLine("Favor informar o número do item desejado: ");
                int produtoId = int.Parse(Console.ReadLine());
                PedidoService.AddProduto(produtoId);
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
