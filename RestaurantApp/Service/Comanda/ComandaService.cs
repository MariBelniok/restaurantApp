﻿using System;
using System.Linq;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Dados;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Service
{
    class ComandaService
    {
        //ADICIONA COMANDA A UMA MODEL AUXILIAR
        public static void AdicionarComanda(AdicionarComandaModel model)
        {
            var contexto = new RestauranteContexto();
            var comanda = new Comanda() { 
                ComandaId = model.ComandaId,
                MesaId = model.MesaId,
                DataHoraEntrada = model.DataHoraEntrada,
                Valor = model.Valor,
                ComandaPaga = model.ComandaPaga,
                QtdePessoasMesa = model.QtdePessoasMesa
            };
            MesaService.AtualizarStatusMesa(model.ComandaId);
            contexto.Add(comanda);
            contexto.SaveChanges();
        }
        //BUSCA A COMANDAS ADICIONADAS NA MODEL
        public static List<ComandaModel> BuscarComanda(int comandaId)
        {
            var contexto = new RestauranteContexto();
            var comanda = contexto.Comanda
                        .Where(c => c.ComandaId == comandaId)
                        .Select(comanda => new ComandaModel
                        {
                            ComandaId = comanda.ComandaId,
                            MesaId = comanda.MesaId,
                            DataHoraEntrada = comanda.DataHoraEntrada,
                            DataHoraSaida = (DateTime)comanda.DataHoraSaida,
                            Valor = comanda.Valor,
                            ComandaPaga = comanda.ComandaPaga,
                            QtdePessoasMesa = comanda.QtdePessoasMesa
                        });
            comanda.Include(c => c.Pedidos);
            return comanda.ToList();
        }

        //CALCULA O VALOR TOTAL DA COMANDA
        public static double ValorTotalComanda(int comandaId)
        {
            var contexto = new RestauranteContexto();

            var valorTotalComanda = contexto.Pedido
                .Where(p => p.ComandaId == comandaId && p.StatusPedido == 1)
                .Select(p => p.ValorPedido)
                .Sum();

            return valorTotalComanda;
        }

        //CANCELA COMANDA
        public static void CancelarComanda(int comandaId)
        {
            var contexto = new RestauranteContexto();
            var comanda = contexto.Comanda
                        .Where(c => c.ComandaId == comandaId)
                        .FirstOrDefault();
            comanda.DataHoraSaida = DateTime.Now;
            comanda.Valor = ValorTotalComanda(comandaId) * 0;
            comanda.ComandaPaga = true;
            MesaService.AtualizarStatusMesa(comanda.MesaId);
            contexto.SaveChanges();

        }

        //ENCERRA E PAGA COMANDA
        public static void EncerrarComanda(int comandaId)
        {
            var contexto = new RestauranteContexto();
            var comanda = contexto.Comanda
                        .Where(c => c.ComandaId == comandaId)
                        .FirstOrDefault();
            comanda.DataHoraSaida = DateTime.Now;
            comanda.Valor = ValorTotalComanda(comandaId);
            comanda.ComandaPaga = true;
            MesaService.AtualizarStatusMesa(comanda.MesaId);
            contexto.SaveChanges();
        }
    }
}
