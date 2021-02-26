using System.Linq;
using System.Collections.Generic;
using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class ComandaService
    {
        public static List<ComandaModel> ListarComandas()
        {
            var comandas = new List<ComandaModel>();
            var todasComandas = Dados.DadosLocais.LerComanda();

            todasComandas.ForEach(x =>
            {
                var com = new ComandaModel()
                {
                    ComandaId = x.ComandaId,
                    MesaId = x.MesaId,
                    DataHoraEntrada = x.DataHoraEntrada,
                    DataHoraSaida = x.DataHoraSaida,
                    Valor = x.Valor,
                    ComandaPaga = x.ComandaPaga,
                    QuantidadePessoasNaMesa = x.QuantidadePessoasNaMesa
                };

                comandas.Add(com);
            });

            return comandas;
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
    }
}
