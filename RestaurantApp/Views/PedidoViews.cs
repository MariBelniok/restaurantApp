using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Service;

namespace RestaurantApp.Views
{
    class PedidoViews
    {
        public static List<string> produtoPedido = PedidoService.produtoPedido;
        public static void RealizarPedido()
        {
            Console.WriteLine("Favor realizar seu pedido.");
            Console.WriteLine("Quantos items do menu deseja pedir? ");
            int numeroItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numeroItems; i++)
            {
                Console.WriteLine("Favor informar o número do item desejado: ");
                int produtoId = int.Parse(Console.ReadLine());
                Console.WriteLine("Quantos desse produto você deseja? ");
                int quantidadeItem = int.Parse(Console.ReadLine());
                Dados.DadosLocais.SalvarPedidos();
            }
        }

        public static void MostrarPedido()
        {
            Console.WriteLine("PEDIDO: ");
            foreach (string obj in produtoPedido)
            {
                Console.WriteLine(obj);
            }
            ComandaService.TrazerComanda(ComandaViews.numeroComanda);
        }
    }
}
