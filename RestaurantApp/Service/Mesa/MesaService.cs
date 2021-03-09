﻿using System.Collections.Generic;
using System.Linq;
using System.IO;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    public class MesaService
    {
        //MUDA STATUS DA MESA QUANDO ABRE OU FECHA COMANDA
        public static void AtualizarStatusMesa(int mesaId)
        {
            var contexto = new RestauranteContexto();
            var mesa = contexto.Mesa
                        .Where(m => m.MesaId == mesaId)
                        .FirstOrDefault();
            if (mesa.MesaOcupada)
            {
                mesa.MesaOcupada = false;
            }
            else
            {
                mesa.MesaOcupada = true;
            }
            contexto.SaveChanges();
        }

        //VERIFICA SE A MESA ESTA DESOCUPADA
        public static bool MesaDesocupada(int mesaId)
        {
            var contexto = new RestauranteContexto();
            bool mesaOcupada = true;
            if(contexto.Mesa.Any(x => x.MesaOcupada == false && mesaId == x.MesaId))
            {
                mesaOcupada = false;
            }
            return mesaOcupada;
        }
        
        //VERIFICA QUAIS MESAS ESTAO DISPONIVEIS
        public static List<MesaModel> BuscarMesasDisponiveis()
        {
            var contexto = new RestauranteContexto();
            return contexto.Mesa
                .Where(p => p.MesaOcupada != true)
                .Select(a => new MesaModel()
                {
                    MesaId = a.MesaId
                })
                .ToList();
        }
    }
}
