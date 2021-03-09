﻿using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Service
{
    class ComandaModel
    {
        public int ComandaId { get; set; }
        public int MesaId { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public double Valor { get; set; }
        public bool ComandaPaga { get; set; }
        public int QtdePessoasMesa { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
