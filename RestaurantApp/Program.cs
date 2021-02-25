using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using RestaurantApp.Service;
using RestaurantApp.Entities;


namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<ProdutoModel> produtos = ProdutoService.BuscarProdutos();
                foreach(ProdutoModel prod in produtos)
                {
                    Console.WriteLine(prod);
                }
                
            }
            catch { }
        }
    }
}
