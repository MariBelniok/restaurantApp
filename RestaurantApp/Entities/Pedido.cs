using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Entities
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; } 

        public int ComandaId { get; set; } 
        [ForeignKey("ComandaId")]
        public Comanda Comanda { get; set; }

        public int ProdutoId { get; set; } 
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public int QtdeProduto { get; set; }
        public double ValorPedido { get; set; }

        public int StatusPedido { get; set; } 
        [ForeignKey("StatusPedido")]
        public StatusPedido Status { get; set; }


    }
}
