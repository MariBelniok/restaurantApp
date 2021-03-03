using System;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados.Dados.IniciandoDados();
            /*----------------------------*/
            Console.WriteLine("Deseja iniciar uma nova comanda? (s/n)");
            char r = char.Parse(Console.ReadLine());

            bool respostaCorreta = VerificarResposta.VerificaResposta(r);

            while(respostaCorreta != true)
            {
                Console.WriteLine("Escolha 's' ou 'n', outra resposta não é valida!");
                Console.WriteLine("Deseja iniciar uma nova comanda? (s/n)");
                r = char.Parse(Console.ReadLine());

                respostaCorreta = VerificarResposta.VerificaResposta(r);
            }

            if (r == 's')
            {
                Console.Clear();
                ComandaViews.IniciarComanda();
            }else if(r == 'n')
            {
                Console.WriteLine("Informe o numero da comanda que deseja consultar: ");
                int comandaId = int.Parse(Console.ReadLine());
                ComandaViews.VisualizarComanda(comandaId);
            }           

        }
    }
}
