using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Dados
{
    public class RestauranteContexto : DbContext
    {

        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=TECHER\\marianna.belniok;Initial Catalog=marianna.belniok;Data Source=SERVER");
        }
    }
}
