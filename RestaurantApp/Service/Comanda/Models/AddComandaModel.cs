using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Service
{
    class AddComandaModel
    {
        public int ComandaId { get; set; }
        public int MesaId { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public float Valor { get; set; }
        public bool ComandaPaga { get; set; }
        public int QuantidadePessoasNaMesa { get; set; }
    }
}
