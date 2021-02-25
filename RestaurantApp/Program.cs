using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using RestaurantApp.Service;
using RestaurantApp.Entities;



namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = Dados.DadosLocais.LerProdutos();

            foreach(Produto p in produtos)
            {
                Console.WriteLine(p.NomeProduto);
                Console.WriteLine(p.ValorProduto);
            }
        }
    }   
}
