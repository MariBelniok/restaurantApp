using RestaurantApp.Dados;
using RestaurantApp.Service;
using System;


namespace RestaurantApp.Views
{
    class ComandaViews
    {
        //INICIA CALCULO COMANDA
        public static float ValorTotalRodizio(float valorTotal)
        {
            float valorTotalRodizio = 0;
            return valorTotalRodizio += valorTotal;
        }

        //ID DA COMANDA AO INICIAR ATENDIMENTO
        public static int comandaId;


        //PEDIR DADOS DA COMANDA
        public static void IniciarComanda()
        {
            Console.Write($"Numero da comanda: ");
            int comanda = int.Parse(Console.ReadLine());
            comandaId = comanda;
            Console.WriteLine();
            Console.WriteLine("Mesas disponiveis: ");
            var mesas = MesaService.BuscarMesasDisponiveis();
            foreach (MesaModel mesa in mesas)
            {
                Console.Write($"[ {mesa.MesaId} ] ");
            }
            Console.WriteLine();
            Console.Write("Numero da mesa: ");
            int numeroMesa = int.Parse(Console.ReadLine());

            bool mesaOcupada = MesaService.MesaDesocupada(numeroMesa);

            

            while(mesaOcupada == true)
            {
                Console.WriteLine("Mesa inexistente ou ocupada! ");
                Console.Write("Numero da mesa: ");
                numeroMesa = int.Parse(Console.ReadLine());
                mesaOcupada = MesaService.MesaDesocupada(numeroMesa);
            }

            Console.WriteLine("Quantidade de pessoas: ");
            int qtePessoas = int.Parse(Console.ReadLine());
            //EMITE AVISO DE CAPACIDADE MAXIMA POR MESA
            while (qtePessoas > 4)
            {
                Console.Clear();
                Console.WriteLine("Maximo de 4 pessoas por mesa! ");
                Console.WriteLine("Quantidade de pessoas: ");
                qtePessoas = int.Parse(Console.ReadLine());
            }
            float valorTotal = (float)qtePessoas * 70;

            Console.Clear();

            BemVindo(qtePessoas, valorTotal);

            var model = new AdicionarComandaModel()
            {
                ComandaId = comandaId,
                MesaId = numeroMesa,
                DataHoraEntrada = DateTime.Now,
                Valor = ValorTotalRodizio(valorTotal),
                ComandaPaga = false,
                QtdePessoasMesa = qtePessoas
            };
            ComandaService.AdicionarComanda(model);
            var modelPedido = new AdicionarPedidoModel()
            {
                StatusPedido = 1,
                ComandaId = comandaId,
                ProdutoId = 1,
                QtdeProduto = qtePessoas,
                ValorPedido = PedidoService.ValorPedido(1, qtePessoas)
            };
            PedidoService.AdicionarPedido(modelPedido);

            ContinuarComanda();
        }

        //BOAS VINDAS AO USUARIO
        public static void BemVindo(int qtePessoas, float valorTotal)
        {
            Console.WriteLine(" ------------------------------------------------------ ");
            Console.WriteLine("|     BEM VINDO AO RESTAURANTE SUTEKINA RANCHI!        |");
            Console.WriteLine();
            if (qtePessoas == 1)
            {
                Console.WriteLine($"|     SERA ADICIONADA {qtePessoas} PESSOA AO NOSSO RODIZIO        |");
            }
            else
            {
                Console.WriteLine($"|    SERAO ADICIONADAS {qtePessoas} PESSOA AO NOSSO RODIZIO       |");
            }
            Console.WriteLine();
            Console.WriteLine("|        VALOR DO RODIZIO INDIVIDUAL: R$70,00          |");
            Console.WriteLine();
            Console.WriteLine($"|  VALOR TOTAL INICIAL ADICIONADO A COMANDA: R${valorTotal:F2}  |");
            Console.WriteLine(" ------------------------------------------------------ ");
        }

        //VERIFICAR SE REALMENTE DESEJA INICIAR O RODIZIO
        public static void ContinuarComanda()
        {
            Console.WriteLine();
            Console.WriteLine("Deseja continuar para pedidos: (s/n)");
            char continuarComanda = char.Parse(Console.ReadLine());
            bool respostaCorreta = VerificarResposta.VerificaResposta(continuarComanda);

            while (respostaCorreta != true)
            {
                Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                Console.WriteLine();
                Console.WriteLine("Deseja continuar para pedidos: (s/n)");
                continuarComanda = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaResposta(continuarComanda);
            }

            if (continuarComanda == 's')
            {
                Console.Clear();
                ProdutoViews.MostrarMenu();
                PedidoViews.RealizarPedido();
                PedidoViews.MostrarPedido(comandaId);
            }
            else
            {
                Console.WriteLine("Cancelar rodizio? (s/n)");
                char cancelarComanda = char.Parse(Console.ReadLine());
                respostaCorreta = VerificarResposta.VerificaResposta(cancelarComanda);

                while (respostaCorreta != true)
                {
                    Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                    Console.WriteLine();
                    Console.WriteLine("Cancelar rodizio? (s/n)");
                    cancelarComanda = char.Parse(Console.ReadLine());
                    respostaCorreta = VerificarResposta.VerificaResposta(cancelarComanda);
                }
                if (cancelarComanda == 's')
                {
                    ComandaService.CancelarComanda(comandaId);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("|Comanda cancelada com sucesso!|");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine();
                    VisualizarComanda(comandaId);
                }
                else
                {
                    Console.WriteLine("Deseja continuar para pedidos: (s/n)");
                    continuarComanda = char.Parse(Console.ReadLine());

                    Console.Clear();
                    ProdutoViews.MostrarMenu();
                    PedidoViews.RealizarPedido();
                    PedidoViews.MostrarPedido(comandaId);
                }
            }
        }

        //TODAS INFORMAÇOES DA COMANDA SOLICITADA
        public static void VisualizarComanda(int comandaId)
        {
            var contexto = new RestauranteContexto();
            var listarComanda = ComandaService.BuscarComanda(comandaId);
            var listaPedidos = PedidoService.BuscarPedidos(comandaId);
            var listaProdutos = ProdutoService.BuscarProdutoDisponivel();
            double valorTotalComanda = ComandaService.ValorTotalComanda(comandaId);

            listarComanda.ForEach(x =>
            {
                if (x.ComandaId == comandaId)
                {

                    Console.WriteLine($"COMANDA: {x.ComandaId}");
                    Console.WriteLine($"ENTRADA: {x.DataHoraEntrada}");
                    Console.WriteLine($"SAIDA: {x.DataHoraSaida}");
                    Console.WriteLine($"MESA: {x.MesaId}");
                    if (x.ComandaPaga && valorTotalComanda > 0)
                    {
                        Console.Write("STATUS DA COMANDA: PAGA");
                    }
                    else if(valorTotalComanda == 0 && x.ComandaPaga)
                    {
                        Console.Write("STATUS DA COMANDA: CANCELADA");
                    }
                    else
                    {
                        Console.WriteLine("STATUS DA COMANDA: ABERTA");
                    }
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("PEDIDOS REALIZADOS: ");
                    Console.WriteLine();
                    //Adiciona rodizio como pedido na comanda
                    listaPedidos.ForEach(p =>
                    {
                        if (p.ComandaId == comandaId)
                        {
                            listaProdutos.ForEach(z =>
                            {
                                if (z.ProdutoId == p.ProdutoId)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"ITEM: {z.NomeProduto}");
                                    Console.WriteLine($"VALOR ITEM: R${z.ValorProduto:F2}");
                                    Console.WriteLine($"QUANTIDADE: {p.QtdeProduto}");
                                    Console.WriteLine($"VALOR TOTAL PEDIDO: R${p.ValorPedido:F2}");
                                    if (p.StatusPedido == 1)
                                    {
                                        Console.WriteLine($"STATUS PEDIDO: ENTREGUE");
                                    }
                                    if (p.StatusPedido == 2)
                                    {
                                        Console.WriteLine($"STATUS PEDIDO: CANCELADO");
                                    }
                                    Console.WriteLine();
                                }
                            });
                        }
                    });

                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"VALOR TOTAL DA COMANDA: {valorTotalComanda:F2}");
                }
            });
        }
    }
}
