using RestaurantApp.Service;
using System;


namespace RestaurantApp.Views
{
    class ComandaViews
    {
        public static int comandaId = Dados.DadosLocais.listaComandas.Count + 1;
        //PEDIR DADOS DA COMANDA
        public static void IniciarComanda()
        {
            Console.Write($"Numero da comanda: {comandaId}");
            Console.WriteLine();
            Console.WriteLine("Mesas disponiveis: ");
            var mesas = MesaService.ListarMesasDisponiveis();
            foreach (MesaModel mesa in mesas)
            {
                Console.Write($"[ {mesa.MesaId} ] ");
            }
            Console.WriteLine();
            Console.Write("Numero da mesa: ");
            int numeroMesa = int.Parse(Console.ReadLine());
            bool mesaDesocupada = MesaService.MesaDesocupada(numeroMesa);
            if (numeroMesa > 16 || numeroMesa < 1 || !mesaDesocupada){
                Console.WriteLine("Mesa inexistente ou ocupada! ");
                Console.Write("Numero da mesa: ");
                numeroMesa = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Quantidade de pessoas: ");
            int qtePessoas = int.Parse(Console.ReadLine());
            if(qtePessoas > 4)
            {
                Console.Clear();
                Console.WriteLine("Maximo de 4 pessoas por mesa! ");
                Console.WriteLine("Quantidade de pessoas: ");
                qtePessoas = int.Parse(Console.ReadLine());
            }
            float valorTotal = (float)qtePessoas * 70;
            var valorComanda = ComandaService.ValorTotalComanda(valorTotal);

            Console.WriteLine("BEM VINDO AO RESTAURANTE SUTEKINA RANCHI");
            if(qtePessoas == 1)
            {
            Console.WriteLine($"SERA ADICIONADA {qtePessoas} PESSOA AO NOSSO RODIZIO");
            }
            else
            {
                Console.WriteLine($"SERAO ADICIONADAS {qtePessoas} PESSOAS AO RODIZIO");
            }
            Console.WriteLine("VALOR DO RODIZIO INDIVIDUAL: R$70,00");
            Console.WriteLine($"VALOR TOTAL INICIAL ADICIONADO A COMANDA: R${valorComanda:F2}");

            var model = new AddComandaModel()
            {
                ComandaId = comandaId,
                MesaId = numeroMesa,
                DataHoraEntrada = DateTime.Now,
                Valor = valorComanda,
                ComandaPaga = false,
                QuantidadePessoasNaMesa = qtePessoas
            };
            ComandaService.AddComanda(model);
        }

        //VERIFICAR SE REALMENTE DESEJA INICIAR O RODIZIO
        public static void ContinuarComanda()
        {
            Console.WriteLine("Deseja continuar para pedidos: (s/n)");
            char continuarComanda = char.Parse(Console.ReadLine());
            if (continuarComanda == 's')
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Cancelar rodizio? (s/n)");
                char cancelarComanda = char.Parse(Console.ReadLine());
                if (cancelarComanda == 's')
                {
                    ComandaService.EncerrarComanda(comandaId);
                    VisualizarComanda(comandaId);
                    throw new Exception("COMANDA CANCELADA COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("Deseja continuar para pedidos: (s/n)");
                    continuarComanda = char.Parse(Console.ReadLine());

                    Console.Clear();
                }
            }
        }

        public static void VisualizarComanda(int comandaId)
        {
            var listarComanda = ComandaService.ListarComandas();

            listarComanda.ForEach(x => { 
                if(x.ComandaId == comandaId)
                {
                    Console.WriteLine($"COMANDA: {x.ComandaId}");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("PEDIDOS REALIZADOS: ");
                        Dados.DadosLocais.listaPedidos.ForEach(p => {
                        if(p.ComandaId == comandaId)
                        {
                            Console.WriteLine($"PEDIDO: " +
                                $"{p.PedidoId}, " +
                                $"PRODUTO: {p.ProdutoId}, " +
                                $"QUANTIDADE: {p.QuantidadePorProduto}, " +
                                $"VALOR TOTAL PEDIDO: R${p.ValorPedido:F2}, " +
                                $"STATUS PEDIDO: {p.AndamentoDoPedido}");
                        }
                    });
                    Console.WriteLine("-------------------------");
                }
            });
        }
    }
}
