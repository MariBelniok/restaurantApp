using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using RestaurantApp.Service;
using RestaurantApp.Entities;
using RestaurantApp.Views;



namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ComandaViews.IniciarComanda();
            ComandaViews.ContinuarComanda();

            ProdutosViews.MostrarMenu();

            PedidoViews.RealizarPedido();
            PedidoViews.MostrarPedido();
 
        }
    }
}
