using System.ComponentModel.DataAnnotations;


namespace RestaurantApp.Entities
{
    public class StatusPedido
    {
        [Key]
        public int StatusId { get; set; } //PK
        public string Descricao { get; set; }
    }
}
