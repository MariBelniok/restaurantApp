using System;
using System.IO;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class ComandaService
    {
        //ADICIONA COMANDA A UMA MODEL AUXILIAR
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
        //LISTA AS COMANDAS ADICIONADAS NA MODEL
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

        //CALCULA O VALOR TOTAL DA COMANDA
        public static float ValorTotalComanda(int comandaId)
        {
            var listarComanda = ListarComandas();
            float valorTotalComanda = 0;

            listarComanda.ForEach(x =>
            {
                if (x.ComandaId == comandaId)
                {
                    DadosLocais.listaPedidos.ForEach(p =>
                    {
                        if (p.ComandaId == comandaId)
                        {
                            DadosLocais.listaProdutos.ForEach(z =>
                            {
                                if (z.ProdutoId == p.ProdutoId)
                                {
                                    
                                    if (p.AndamentoDoPedido == 1)
                                    {
                                        valorTotalComanda += p.ValorPedido;
                                    }
                                }
                            });
                        }
                    });
                    valorTotalComanda += x.Valor;
                }
            });
            return valorTotalComanda;
        }

        //CANCELA COMANDA
        public static void CancelarComanda(int comandaId)
        {
            DadosLocais.listaComandas.ForEach(x => {
                if (x.ComandaId == comandaId)
                {
                    DadosLocais.listaComandas.ForEach(c =>
                    {
                        c.DataHoraSaida = DateTime.Now;
                        c.Valor = (x.Valor) * 0;
                        c.ComandaPaga = true;
                        MesaService.AtualizarStatusMesa(c.MesaId);
                    });
                }
            });

            File.WriteAllText(DadosLocais.caminhoComanda, string.Empty);
            DadosLocais.SalvarComandas();
        }

        //ENCERRA E PAGA COMANDA
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
                        MesaService.AtualizarStatusMesa(c.MesaId);
                    });
                }
            });

            File.WriteAllText(DadosLocais.caminhoComanda, string.Empty);
            DadosLocais.SalvarComandas();

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|Comanda paga com sucesso!|");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }
    }
}
