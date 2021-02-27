using System;
using RestaurantApp.Dados;
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
            if (numeroItems > 0)
            {
                for (int i = 1; i <= numeroItems; i++)
                {
                    Console.WriteLine($"{i}º PEDIDO: ");
                    Console.WriteLine("Favor informar o número do item desejado: ");
                    int produtoId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Quantos desse produto você deseja? ");
                    int quantidadeItem = int.Parse(Console.ReadLine());
                    var model = new AdicionarModel()
                    {
                        AndamentoDoProduto = 1,
                        ComandaId = DadosLocais.listaComandas.Count + 1,
                        ProdutoId = produtoId,
                        QuantidadePorProduto = quantidadeItem,
                        ValorPedido = PedidoService.ValorProduto(produtoId, quantidadeItem)
                    };
                    PedidoService.AddPedido(model);
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Deseja encerrar atendimento e pagar sua comanda? (s/n)");
                char r = char.Parse(Console.ReadLine());
                if(r == 's')
                {
                    ComandaViews.VisualizarComanda(); 
                    throw new Exception ("Comanda encerrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Favor realizar seu pedido.");
                    Console.WriteLine("Quantos items do menu deseja pedir? ");
                    numeroItems = int.Parse(Console.ReadLine());
                }
            }
        }

        public static void MostrarPedido()
        {
            DadosLocais.listaPedidos.ForEach(p =>
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"PEDIDO NUMERO:{p.PedidoId} ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Numero Produto: {p.ProdutoId} - Quantidade:{p.QuantidadePorProduto}");
                Console.WriteLine($"ValorTotal: R${p.ValorPedido:F2}");
                Console.WriteLine("------------------------------------------");
            });

            Console.WriteLine("Deseja editar ou cancelar seu pedido? (s/n) ");
            char resp = char.Parse(Console.ReadLine());
            if(resp == 's' || resp == 'S')
            {
                Console.WriteLine("Favor informar com (c) para cancelar ou (e) para editar");
                char res = char.Parse(Console.ReadLine());
                if(res == 'c' || resp == 'C')
                {
                    Console.WriteLine("Favor informar o número do pedido que deseja cancelar: ");
                    int pedidoId = int.Parse(Console.ReadLine());
                    PedidoService.RemoveProduto(pedidoId);
                    Console.WriteLine();
                    Console.WriteLine("Pedido cancelado com sucesso!");
                    Console.WriteLine();
                    ComandaViews.ContinuarComanda();
                    ProdutosViews.MostrarMenu();
                    RealizarPedido();
                }
                else
                {
                    Console.WriteLine("Favor informar o número do pedido que deseja editar: ");
                    int pedidoId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Quantos desse produto você deseja? ");
                    int quantidadeItem = int.Parse(Console.ReadLine());
                    PedidoService.AtualizarProduto(pedidoId, quantidadeItem);
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Pedido atualizado com sucesso! ");
                    MostrarPedido();
                }
            }
            Console.WriteLine("Pedido realizado com sucesso! ");
            Console.WriteLine();
            Console.WriteLine("Fazer novo pedido? (s/n)");
            char r = char.Parse(Console.ReadLine());
            if(r == 's' || r == 'S')
            {
                Console.Clear();
                ProdutosViews.MostrarMenu();
                RealizarPedido();
            }
            else
            {
                Console.WriteLine("Finalizar atendimento e pagar comanda? (s/n)");
                char resposta = char.Parse(Console.ReadLine());
                if(resposta == 's' || resposta == 'S')
                {
                    //ComandaViews.VisualizarComanda();
                }
            }
        }
    }
}
