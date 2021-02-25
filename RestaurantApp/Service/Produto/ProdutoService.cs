using System.Collections.Generic;
using System.Linq;


namespace RestaurantApp.Service
{
    class ProdutoService
    {
        //FILTRA PRODUTOS DISPONIVEIS
        public static List<ProdutoModel> BuscarProdutoDisponivel()
        {
            var todosProdutos = Dados.DadosLocais.LerProdutos();

            return todosProdutos
                .Where(p => p.ProdutoDisponivel)
                .Select(a => new ProdutoModel()
                {
                    NomeProduto = a.NomeProduto,
                    ProdutoId = a.ProdutoId,
                    ValorProduto = a.ValorProduto
                })
                .ToList();
        }
        //LISTA PRODUTOS FILTRADOS
        public static List<ProdutoModel> ListarProdutos()
        {
            var listaProdutosDisponiveis = new List<ProdutoModel>();

            BuscarProdutoDisponivel().ForEach(x =>
            {
                var prod = new ProdutoModel()
                {
                    ProdutoId = x.ProdutoId,
                    NomeProduto = x.NomeProduto,
                    ValorProduto = x.ValorProduto,
                };

                listaProdutosDisponiveis.Add(prod);
            });

            return listaProdutosDisponiveis;
        }
    }
}


        

