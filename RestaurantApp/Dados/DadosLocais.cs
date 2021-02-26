using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Service;

namespace RestaurantApp.Dados
{
    class DadosLocais
    {
        public static string caminhoPedidos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\Pedidos.csv";
        public static string caminhoComanda = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\Pedidos.csv";
        public static string caminhoProdutos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\MenuProdutos.csv";

        public static List<Produto> LerProdutos()
        {

            List<Produto> produtos = new List<Produto>();

            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDoProduto = produto.Split(",");

                int produtoId = int.Parse(dadosDoProduto[0]);
                string nomeProduto = dadosDoProduto[1];
                float valorProduto = float.Parse(dadosDoProduto[2], CultureInfo.InvariantCulture);
                bool statusProduto = bool.Parse(dadosDoProduto[3]);

                produtos.Add(new Produto
                {
                    ProdutoId = produtoId,
                    NomeProduto = nomeProduto,
                    ValorProduto = valorProduto,
                    ProdutoDisponivel = statusProduto
                });
            }
            return produtos;
        }

        public static List<Mesa> LerMesas()
        {
            List<Mesa> mesas = new List<Mesa>();

            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDaMesa = produto.Split(",");

                int mesaId = int.Parse(dadosDaMesa[0]);
                int capacidadeMesa = int.Parse(dadosDaMesa[1]);
                bool mesaDisponivel = bool.Parse(dadosDaMesa[2]);

                mesas.Add(new Mesa
                {
                    MesaId = mesaId,
                    CapacidadePorMesa = capacidadeMesa,
                    MesaDisponivel = mesaDisponivel
                });
            }
            return mesas;
        }

        public static void AdicionarPedidos()
        {
            
            var pedidos = new List<Pedido>();

            var pedidosRealizados = PedidoService.produtoPedido;

            using(StreamWriter sw = File.AppendText(caminhoPedidos))
            {
                pedidosRealizados.ForEach(p =>
                {
                    sw.WriteLine(p);
                });
            }
        }
        public static List<Pedido> LerPedidos()
        {

            List<Pedido> pedidos = new List<Pedido>();

            string[] lerPedidos = File.ReadAllLines(caminhoPedidos);
            foreach (string pedido in lerPedidos)
            {
                string[] dadosDoPedido = pedido.Split(",");

                int pedidoId = int.Parse(dadosDoPedido[0]);
                int comandaId = int.Parse(dadosDoPedido[1]);
                int produtoId = int.Parse(dadosDoPedido[2]);
                int quantidade = int.Parse(dadosDoPedido[3]);

                pedidos.Add(new Pedido
                {
                    PedidoId = pedidoId,
                    ComandaId = comandaId,
                    ProdutoId = produtoId,
                    QuantidadePorProduto = quantidade
                });
            }
            return pedidos;
        }

        public static void AdicionarComanda()
        {
            using(StreamWriter sw = File.AppendText(caminhoComanda))
            {
                //var novaComanda = ComandaService.NovaComanda();
                sw.WriteLine();
            }
        }

        public static List<Comanda> LerComanda()
        {

            List<Comanda> comanda = new List<Comanda>();

            string[] lerComandas = File.ReadAllLines(caminhoComanda);
            foreach (string c in lerComandas)
            {
                string[] dadosDaComanda = c.Split(",");

                int comandaId = int.Parse(dadosDaComanda[0]);
                int mesaId = int.Parse(dadosDaComanda[1]);
                DateTime dataHoraEntrada = DateTime.Parse(dadosDaComanda[2]);
                DateTime dataHoraSaida = DateTime.Parse(dadosDaComanda[3]);
                float valor = float.Parse(dadosDaComanda[4]);
                bool comandaPaga = bool.Parse(dadosDaComanda[5]);
                int quantidadePessoasMesa = int.Parse(dadosDaComanda[6]);

                comanda.Add(new Comanda
                {
                    ComandaId = comandaId,
                    MesaId = mesaId,
                    DataHoraEntrada = dataHoraEntrada,
                    DataHoraSaida = dataHoraSaida,
                    Valor = valor,
                    ComandaPaga = comandaPaga,
                    QuantidadePessoasNaMesa = quantidadePessoasMesa
                });
            }
            return comanda;
        }

        public static List<StatusPedido> LerStatusPedido()
        {

            List<StatusPedido> status = new List<StatusPedido>();

            string[] lerStatus = File.ReadAllLines(caminhoComanda);
            foreach (string s in lerStatus)
            {
                string[] dadosDoStatus = s.Split(",");

                int statusId = int.Parse(dadosDoStatus[0]);
                string descricao = dadosDoStatus[1];

                status.Add(new StatusPedido
                {
                    StatusId = statusId,
                    Descricao = descricao
                });

            }
            return status;
        }

    }
}