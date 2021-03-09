using System.ComponentModel.DataAnnotations;


namespace RestaurantApp.Entities
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; } //PK
        public int CapacidadePessoasMesa { get; set; }
        public bool MesaOcupada { get; set; }
    }
}
