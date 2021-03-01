using System;
using System.IO;
using RestaurantApp.Dados;
using RestaurantApp.Service;

namespace RestaurantApp.Views
{
    class PedidoViews
    {
        //VERIFICAR AS INFORMAÇÕES DO PEDIDO COM USUARIO
        public static void RealizarPedido()
        {
            Console.WriteLine("Novo Pedido?(s/n) ");
            char resposta = char.Parse(Console.ReadLine());

            bool respostaCorreta = VerificarResposta.VerificaResposta(resposta);

            while (respostaCorreta != true)
            {
                Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                Console.WriteLine();
                Console.WriteLine("Novo Pedido?(s/n)");
                resposta = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaResposta(resposta);
            }
            if (resposta == 's')
            {

                Console.WriteLine($"PEDIDO: ");
                Console.WriteLine("Favor informar o número do item desejado: ");
                int produtoId = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantos desse produto você deseja? ");
                int quantidadeItem = int.Parse(Console.ReadLine());
                var model = new AdicionarModel()
                {
                    AndamentoDoProduto = 1,
                    ComandaId = ComandaViews.comandaId,
                    ProdutoId = produtoId,
                    QuantidadePorProduto = quantidadeItem,
                    ValorPedido = PedidoService.ValorProduto(produtoId, quantidadeItem)
                };
                PedidoService.AddPedido(model);

                Console.Clear();
            }
            else
            {
                Console.WriteLine("Deseja encerrar atendimento e pagar sua comanda? (s/n)");
                char r = char.Parse(Console.ReadLine());
                respostaCorreta = VerificarResposta.VerificaResposta(r);

                while (respostaCorreta != true)
                {
                    Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                    Console.WriteLine();
                    Console.WriteLine("Deseja encerrar atendimento e pagar sua comanda? (s/n)");
                    r = char.Parse(Console.ReadLine());

                    respostaCorreta = VerificarResposta.VerificaResposta(r);
                }
                if (r == 's')
                {
                    Console.Clear();
                    File.WriteAllText(DadosLocais.caminhoPedidos, string.Empty);
                    DadosLocais.SalvarPedidos();

                    ComandaService.EncerrarComanda(ComandaViews.comandaId);
                    ComandaViews.VisualizarComanda(ComandaViews.comandaId);

                    throw new Exception("COMANDA FINALIZADA E PAGA");
                }
                else
                {
                    MostrarPedido(ComandaViews.comandaId);
                }
            }
        }

        //CANCELA UM PEDIDO
        public static void CancelarPedido()
        {
            Console.WriteLine("Favor informar o número do pedido que deseja cancelar: ");
            int pedidoId = int.Parse(Console.ReadLine());
            bool pedidoCorreto = PedidoService.PedidoCorreto(pedidoId);

            while (pedidoCorreto != true)
            {
                Console.WriteLine("Somente possivel alterar o ultimo pedido realizado!");
                Console.WriteLine();
                Console.WriteLine("Favor informar o número do pedido que deseja editar: ");
                pedidoId = int.Parse(Console.ReadLine());
                pedidoCorreto = PedidoService.PedidoCorreto(pedidoId);
            }

            PedidoService.RemoveProduto(pedidoId);

            Console.Clear();
            Console.WriteLine("Pedido cancelado com sucesso!");
            Console.WriteLine();
            ProdutosViews.MostrarMenu();
            RealizarPedido();
        }

        //EDITA UM PEDIDO
        public static void EditarPedido()
        {

            Console.WriteLine("Favor informar o número do pedido que deseja editar: ");
            int pedidoId = int.Parse(Console.ReadLine());
            bool pedidoCorreto = PedidoService.PedidoCorreto(pedidoId);

            while (pedidoCorreto != true)
            {
                Console.WriteLine("Somente possivel alterar o ultimo pedido realizado!");
                Console.WriteLine();
                Console.WriteLine("Favor informar o número do pedido que deseja editar: ");
                pedidoId = int.Parse(Console.ReadLine());
                pedidoCorreto = PedidoService.PedidoCorreto(pedidoId);
            }

            Console.WriteLine("Quantos desse produto você deseja? ");
            int quantidadeItem = int.Parse(Console.ReadLine());

            PedidoService.AtualizarProduto(pedidoId, quantidadeItem);

            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("Pedido atualizado com sucesso! ");
            MostrarPedido(ComandaViews.comandaId);
        }

        //MOSTRA PEDIDO PARA USUARIO
        public static void MostrarPedido(int comandaId)
        {
            
            DadosLocais.listaPedidos.ForEach(p =>
            {
                if (p.ComandaId == comandaId)
                {
                    DadosLocais.listaProdutos.ForEach(x =>
                    {
                        if (p.ProdutoId == x.ProdutoId)
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"PEDIDO NUMERO:{p.PedidoId}");
                            Console.WriteLine("");
                            Console.WriteLine($"Item: {x.NomeProduto}");
                            Console.WriteLine($"Valor Item: {x.ValorProduto} ");
                            Console.WriteLine($"Quantidade:{p.QuantidadePorProduto}");
                            Console.WriteLine($"Valor Pedido: R${p.ValorPedido:F2}");
                            if(p.AndamentoDoPedido == 1)
                            {
                                Console.WriteLine("Pedido Realizado!");
                            }
                            if(p.AndamentoDoPedido == 2)
                            {
                                Console.WriteLine("Pedido Cancelado!");
                            }
                            Console.WriteLine("------------------------------------------");
                        }
                    });
                }
            });

            Console.WriteLine("Deseja editar ou cancelar seu pedido? (s/n) ");
            char resp = char.Parse(Console.ReadLine());
            bool respostaCorreta = VerificarResposta.VerificaResposta(resp);

            while (respostaCorreta != true)
            {
                Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                Console.WriteLine();
                Console.WriteLine("Deseja editar ou cancelar seu pedido? (s/n)");
                resp = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaResposta(resp);
            }
            if (resp == 's' || resp == 'S')
            {
                //PEDE PARA USUARIO ESCOLHER ENTRE CANCELAR OU EDITAR
                Console.WriteLine("Favor informar com (c) para cancelar ou (e) para editar");
                char res = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaEditarCancelar(res);

                while (respostaCorreta != true)
                {
                    Console.WriteLine("Escolha 'e' ou 'c', outra resposta não é valida!");
                    Console.WriteLine();
                    Console.WriteLine("Favor informar com (c) para cancelar ou (e) para editar");
                    res = char.Parse(Console.ReadLine());

                    respostaCorreta = VerificarResposta.VerificaEditarCancelar(res);
                }

                if (res == 'c' || resp == 'C')
                {
                    CancelarPedido();
                }
                if (res == 'e' || resp == 'E')
                {
                    
                    EditarPedido();
                }
                else
                {
                    Console.Clear();
                    ProdutosViews.MostrarMenu();
                    RealizarPedido();
                    MostrarPedido(ComandaViews.comandaId);
                }

            }

            Console.WriteLine("Pedido realizado com sucesso! ");


            Console.WriteLine();
            Console.WriteLine("Fazer novo pedido? (s/n)");
            char r = char.Parse(Console.ReadLine());

            respostaCorreta = VerificarResposta.VerificaResposta(r);

            while (respostaCorreta != true)
            {
                Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                Console.WriteLine();
                Console.WriteLine("Fazer novo pedido? (s/n)");
                r = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaResposta(r);
            }

            if (r == 's' || r == 'S')
            {
                Console.Clear();
                ProdutosViews.MostrarMenu();
                RealizarPedido();
                MostrarPedido(ComandaViews.comandaId);
            }
            else
            {
                Console.WriteLine("Finalizar atendimento e pagar comanda? (s/n)");
                char resposta = char.Parse(Console.ReadLine());
                respostaCorreta = VerificarResposta.VerificaResposta(resposta);

                while (respostaCorreta != true)
                {
                    Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                    Console.WriteLine();
                    Console.WriteLine("Finalizar atendimento e pagar comanda? (s/n)");
                    resposta = char.Parse(Console.ReadLine());

                    respostaCorreta = VerificarResposta.VerificaResposta(resposta);
                }
                if (resposta == 's' || resposta == 'S')
                {
                    Console.Clear();
                    File.WriteAllText(DadosLocais.caminhoPedidos, string.Empty);
                    DadosLocais.SalvarPedidos();

                    ComandaService.EncerrarComanda(ComandaViews.comandaId);
                    ComandaViews.VisualizarComanda(ComandaViews.comandaId);

                    throw new Exception("COMANDA FINALIZADA E PAGA");
                }
                else
                {
                    Console.Clear();
                    ProdutosViews.MostrarMenu();
                    RealizarPedido();
                    MostrarPedido(ComandaViews.comandaId);
                }
            }
        }
    }
}
