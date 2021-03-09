using RestaurantApp.Dados;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantApp.Service
{
    class ProdutoService
    {
        
        //FILTRA PRODUTOS DISPONIVEIS
        public static List<ProdutoModel> BuscarProdutoDisponivel()
        {
            var contexto = new RestauranteContexto();
            var produtos = contexto.Produto
                .Where(p => p.Disponivel)
                .Select(a => new ProdutoModel
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();

            return produtos;
        }
        public static List<ProdutoModel> ListarMenu()
        {
            var contexto = new RestauranteContexto();
            var produtos = contexto.Produto
                .Where(p => p.Disponivel && p.ProdutoId > 1)
                .Select(a => new ProdutoModel
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();

            return produtos;
        }
    }
}