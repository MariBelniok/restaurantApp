using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Entities
{
    class Mesa
    {
        public int MesaId { get; set; }
        public int CapacidadePorMesa { get; set; }
        public bool MesaDisponivel { get; set; }
    }
}
