using System.Linq;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class ComandaService
    {
        public static List<Comanda> novaComanda = new List<Comanda>();
        public static List<ComandaModel> comandas = new List<ComandaModel>();
        
        public static void AddComanda(int mesa)
        {
            
        }
        public static void ListarComandas()
        {
            
        }

        public static string TrazerComanda(int comandaId)
        {
            var todasComandas = ListarComandas();
            string dadosComanda = "";

            todasComandas
                .ForEach(x =>
                {
                    if (x.ComandaId == comandaId)
                    {
                        dadosComanda = $"Comanda: {x.ComandaId}," +
                               $"Mesa: {x.MesaId}" +
                               $"Horario do inicio da comanda: {x.MesaId}" +
                               $"Horario do fechamento da comanda: {x.MesaId}" +
                               $"Valor total da comanda: {x.Valor}" +
                               $"";
                    }
                });

            return dadosComanda;
        }

        public static float ValorTotalComanda(float valor)
        {
            float sum = 0;
            sum += valor;
            return sum;
        }
    }
}
