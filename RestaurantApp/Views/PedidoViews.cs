using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Service;

namespace RestaurantApp.Views
{
    class PedidoViews
    {
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
                var model = new AdicionarModel()
                {
                    AndamentoDoProduto = 1,
                    ComandaId = Dados.DadosLocais.listaComandas.Count+1,
                    ProdutoId = produtoId,
                    QuantidadePorProduto = quantidadeItem
                };

                PedidoService.AddPedido(model);
            }
        }

        public static void MostrarPedido()
        {
            Console.WriteLine("PEDIDO: ");
            Dados.DadosLocais.listaPedidos.ForEach(p => {
                Console.WriteLine( $"{p.PedidoId}, {p.QuantidadePorProduto}");
            });
            
            ComandaService.TrazerComanda(Dados.DadosLocais.listaComandas.Count + 1);
        }
    }
}
