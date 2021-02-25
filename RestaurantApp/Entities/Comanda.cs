using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    class Comanda
    {
        public int ComandaId { get; set; }
        public int MesaId { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public float Valor { get; set; }
        public bool ComandaPaga { get; set; }
        public int QuantidadePessoasNaMesa { get; set; }

        public Comanda(int comandaId, int mesaId, float valor, bool comandaPaga, int quantidadePessoasNaMesa)
        {
            ComandaId = comandaId;
            MesaId = mesaId;
            DataHoraEntrada = DateTime.Now;
            DataHoraSaida = DateTime.Now;
            Valor = valor;
            ComandaPaga = comandaPaga;
            QuantidadePessoasNaMesa = quantidadePessoasNaMesa;
        }
    }
}
