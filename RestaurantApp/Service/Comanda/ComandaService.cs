using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using RestaurantApp.Entities;


namespace RestaurantApp.Service
{
    class ComandaService
    {
        //ADICIONA COMANDA A UMA MODEL AUXILIAR
        public static void AdicionarComanda(AdicionarComandaModel model)
        {
            Dados.Dados.listaComandas.Add(new Comanda() { 
                ComandaId = model.ComandaId,
                MesaId = model.MesaId,
                DataHoraEntrada = model.DataHoraEntrada,
                DataHoraSaida = null,
                Valor = model.Valor,
                ComandaPaga = model.ComandaPaga,
                QtdePessoasMesa = model.QtdePessoasMesa
            });
        }
        //LISTA AS COMANDAS ADICIONADAS NA MODEL
        public static List<ComandaModel> BuscarComanda(int comandaId)
        {
            return Dados.Dados.listaComandas
                .Where(comanda => comanda.ComandaId == comandaId)
                .Select(c => new ComandaModel()
                { 
                    ComandaId = c.ComandaId,
                    MesaId = c.MesaId,
                    DataHoraEntrada = c.DataHoraEntrada,
                    DataHoraSaida = (DateTime)c.DataHoraSaida,
                    Valor = c.Valor,
                    ComandaPaga = c.ComandaPaga,
                    QtdePessoasMesa = c.QtdePessoasMesa
                }).ToList();
        }

        //CALCULA O VALOR TOTAL DA COMANDA
        public static double ValorTotalComanda(int comandaId)
        {
            return Dados.Dados.listaPedidos
                .Where(p => p.ComandaId == comandaId && p.AndamentoPedido == 1)
                .Select(p => p.ValorPedido)
                .Aggregate(0.0, (x, y) => x + y);
        }

        //CANCELA COMANDA
        public static void CancelarComanda(int comandaId)
        {
            Dados.Dados.listaComandas.ForEach(x => {
                if (x.ComandaId == comandaId)
                {
                    Dados.Dados.listaComandas.ForEach(c =>
                    {
                        c.DataHoraSaida = DateTime.Now;
                        c.Valor = (x.Valor) * 0;
                        c.ComandaPaga = true;
                        MesaService.AtualizarStatusMesa(c.MesaId);
                    });
                }
            });

            File.WriteAllText(Dados.Dados.caminhoComanda, string.Empty);
            Dados.Dados.SalvarComandas();
        }

        //ENCERRA E PAGA COMANDA
        public static void EncerrarComanda(int comandaId)
        {
            Dados.Dados.listaComandas.ForEach(x => { 
                if(x.ComandaId == comandaId)
                {
                    Dados.Dados.listaComandas.ForEach(c =>
                    {
                        c.DataHoraSaida = DateTime.Now;
                        c.Valor = x.Valor;
                        c.ComandaPaga = true;
                        MesaService.AtualizarStatusMesa(c.MesaId);
                    });
                }
            });

            File.WriteAllText(Dados.Dados.caminhoComanda, string.Empty);
            Dados.Dados.SalvarComandas();   
        }
    }
}
