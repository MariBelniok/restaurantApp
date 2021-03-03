using System.Collections.Generic;
using System.Linq;


namespace RestaurantApp.Service
{
    class ProdutoService
    {
        
        //FILTRA PRODUTOS DISPONIVEIS
        public static List<ProdutoModel> BuscarProdutoDisponivel()
        {
            return Dados.Dados.listaProdutos
                .Where(p => p.ProdutoDisponivel)
                .Select(a => new ProdutoModel()
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();
        }

        //LISTA TODOS OS PRODUTOS QUE ESTAO DISPONIVEIS
        public static List<ProdutoModel> ListarProdutos()
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();
            BuscarProdutoDisponivel().ForEach(x =>
            {
                var prod = new ProdutoModel()
                {
                    ProdutoId = x.ProdutoId,
                    NomeProduto = x.NomeProduto,
                    ValorProduto = x.ValorProduto,
                };
                produtos.Add(prod);
            });

            return produtos;
        }
    }
}


        

