using System;
using System.IO;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminho = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\MenuProdutos.csv";
            try
            {
                string[] lerProdutos = File.ReadAllLines(caminho);
                foreach (string produto in lerProdutos)
                {
                    string[] dadosDoProduto = produto.Split(",");
                    int produtoId = int.Parse(dadosDoProduto[0]);
                    string nomeProduto = dadosDoProduto[1];
                    float valorProduto = float.Parse(dadosDoProduto[2]);
                    bool statusProduto = bool.Parse(dadosDoProduto[3]);
                    Console.WriteLine($"{produtoId}, {nomeProduto}, {valorProduto}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
