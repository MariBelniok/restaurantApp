namespace RestaurantApp.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; } //PK
        public string NomeProduto { get; set; }
        public float ValorProduto { get; set; }
        public bool ProdutoDisponivel { get; set; }
    }
}
