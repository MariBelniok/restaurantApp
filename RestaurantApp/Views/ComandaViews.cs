using RestaurantApp.Entities;
using RestaurantApp.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Views
{
    class ComandaViews
    {
        //PEDIR DADOS DA COMANDA
        public static void IniciarComanda()
        {
            Console.Write($"Numero da comanda: {Dados.DadosLocais.listaComandas.Count + 1}");
            Console.WriteLine();
            Console.WriteLine("Mesas disponiveis: ");
            var mesas = MesaService.ListarMesasDisponiveis();
            foreach (MesaModel mesa in mesas)
            {
                Console.WriteLine($"{mesa.MesaId}");
            }
            Console.Write("Numero da mesa: ");
            int numeroMesa = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantidade de pessoas: ");
            int qtePessoas = int.Parse(Console.ReadLine());

            float valorTotal = (float)qtePessoas * 70;

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
            var valorComanda = ComandaService.ValorTotalComanda(valorTotal);
            Console.WriteLine($"VALOR TOTAL INICIAL ADICIONADO A COMANDA: R${valorComanda:F2}");

            ComandaService.AddComanda(numeroMesa);
            
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

        /*public static void VisualizarComanda()
        {
            Console.WriteLine(ComandaService.TrazerComanda());
        }*/
    }
}
