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
        public DateTime DataHoraSaida;
        public float Valor { get; set; }
        public bool ComandaPaga;
        public int QuantidadePessoasNaMesa { get; set; }

        public DateTime dataHoraSaida
        {
            get { return DataHoraSaida; }
            set {
                if (comandaPaga)
                {
                    DataHoraSaida = DateTime.Now;
                }
            }
        }

        public bool comandaPaga
        {
            get { return ComandaPaga; }
            set
            {
                if (comandaPaga)
                {
                    ComandaPaga = true;
                }
                else
                {
                    ComandaPaga = false;
                }
            }
        }
    }
}
