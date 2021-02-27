using System;
using System.IO;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Views;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class ComandaService
    {   
        public static void AddComanda(AddComandaModel model)
        {
            DadosLocais.listaComandas.Add(new Comanda() { 
                ComandaId = model.ComandaId,
                MesaId = model.MesaId,
                DataHoraEntrada = model.DataHoraEntrada,
                DataHoraSaida = null,
                Valor = model.Valor,
                ComandaPaga = model.ComandaPaga,
                QuantidadePessoasNaMesa = model.QuantidadePessoasNaMesa
            });
        }
        public static List<ComandaModel> ListarComandas()
        {
            var comandas = new List<ComandaModel>();
            DadosLocais.listaComandas.ForEach(x => {
                var comanda = new ComandaModel()
                {
                    ComandaId = x.ComandaId,
                    MesaId = x.MesaId,
                    DataHoraEntrada = x.DataHoraEntrada,
                    DataHoraSaida = (DateTime)x.DataHoraSaida,
                    Valor = x.Valor,
                    ComandaPaga = x.ComandaPaga,
                    QuantidadePessoasNaMesa = x.QuantidadePessoasNaMesa
                };
                comandas.Add(comanda);
            });
            return comandas;
        }
        public static float ValorTotalComanda(float valor)
        {
            float sum = 0;
            sum += valor;
            return sum;
        }

        public static void EncerrarComanda(int comandaId)
        {
            DadosLocais.listaComandas.ForEach(x => { 
                if(x.ComandaId == comandaId)
                {
                    DadosLocais.listaComandas.ForEach(c =>
                    {
                        c.DataHoraSaida = DateTime.Now;
                        c.Valor = x.Valor;
                        c.ComandaPaga = true;
                    });
                }
            });

            File.WriteAllText(DadosLocais.caminhoComanda, string.Empty);
            DadosLocais.SalvarComandas();
        }
    }
}
