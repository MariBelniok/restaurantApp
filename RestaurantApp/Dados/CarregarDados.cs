using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Dados
{
    class CarregarDados
    {
        public static void IniciandoDados()
        {
            DadosLocais.BuscarComandas();
            DadosLocais.BuscarMesas();
            DadosLocais.BuscarPedidos();
            DadosLocais.BuscarProdutos();
            DadosLocais.BuscarStatusPedido();
        }
    }
}
