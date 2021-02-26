using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Views
{
    class ComandaViews
    {
        public static void ContinuarComanda(char continuarComanda)
        {
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
    }
}
