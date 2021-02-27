using System;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarDados.IniciandoDados();
            /*----------------------------*/

            ComandaViews.IniciarComanda();
            ComandaViews.ContinuarComanda();

            ProdutosViews.MostrarMenu();

            PedidoViews.RealizarPedido();
            PedidoViews.MostrarPedido(ComandaViews.comandaId);
        }
    }
}
