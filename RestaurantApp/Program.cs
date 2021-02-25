using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using RestaurantApp.Service;


namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(BuscarProduto());
            }
            catch { }
        }
    }
}
