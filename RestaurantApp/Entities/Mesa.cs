namespace RestaurantApp.Entities
{
    public class Mesa
    {
        public int MesaId { get; set; } //PK
        public int CapacidadeMesa { get; set; }
        public bool MesaDisponivel { get; set; }
    }
}
