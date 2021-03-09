using System.ComponentModel.DataAnnotations;


namespace RestaurantApp.Entities
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public double ValorProduto { get; set; }
        public bool Disponivel { get; set; }
    }
}
