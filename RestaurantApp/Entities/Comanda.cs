using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    public class Comanda
    {
        public int ComandaId { get; set; } //PK
        public int MesaId { get; set; } //FK
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public double Valor { get; set; }
        public bool ComandaPaga { get; set; }
        public int QtdePessoasMesa { get; set; }
    }
}
