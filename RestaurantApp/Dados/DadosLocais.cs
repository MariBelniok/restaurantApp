using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using RestaurantApp.Entities;
using RestaurantApp.Service;

namespace RestaurantApp.Dados
{
    public class DadosLocais
    {
        public static string caminhoPedidos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\Pedidos.csv";
        public static string caminhoComanda = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\Comandas.csv";
        public static string caminhoProdutos = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\MenuProdutos.csv";
        public static string caminhoMesas = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\DadosMesa.csv";
        public static string caminhoStatus = @"C:\Users\marianna.belniok\source\repos\RestaurantApp\RestaurantApp\Dados\StatusPedido.csv";

        public static List<Comanda> listaComandas = new List<Comanda>();
        public static List<Produto> listaProdutos = new List<Produto>();
        public static List<Pedido> listaPedidos = new List<Pedido>();
        public static List<Mesa> listaMesas = new List<Mesa>();
        public static List<StatusPedido> listaStatusPedidos = new List<StatusPedido>();

        public static void BuscarComandas()
        {
            string[] comandas = File.ReadAllLines(caminhoComanda);
            foreach (string comanda in comandas)
            {
                string[] dadosComanda = comanda.Split(",");


                listaComandas.Add(new Comanda()
                {
                    ComandaId = int.Parse(dadosComanda[0]),
                    MesaId = int.Parse(dadosComanda[1]),
                    DataHoraEntrada = DateTime.Parse(dadosComanda[2]),
                    DataHoraSaida = DateTime.Parse(dadosComanda[3]),
                    Valor = float.Parse(dadosComanda[4]),
                    ComandaPaga = bool.Parse(dadosComanda[5]),
                    QuantidadePessoasNaMesa = int.Parse(dadosComanda[6]),
                });
            }
        }
        public static void BuscarProdutos()
        {
            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDoProduto = produto.Split(",");

                listaProdutos.Add(new Produto
                {
                    ProdutoId = int.Parse(dadosDoProduto[0]),
                    NomeProduto = dadosDoProduto[1],
                    ValorProduto = float.Parse(dadosDoProduto[2]),
                    ProdutoDisponivel = bool.Parse(dadosDoProduto[3]),
                });
            }
        }

        public static void BuscarMesas()
        {
            string[] mesas = File.ReadAllLines(caminhoMesas);
            foreach (string mesa in mesas)
            {
                string[] dadosDaMesa = mesa.Split(",");

                listaMesas.Add(new Mesa
                {
                    MesaId = int.Parse(dadosDaMesa[0]),
                    CapacidadePorMesa = int.Parse(dadosDaMesa[1]),
                    MesaDisponivel = bool.Parse(dadosDaMesa[2])
                });
            }
        }


        public static void BuscarPedidos()
        {
            string[] lerPedidos = File.ReadAllLines(caminhoPedidos);
            foreach (string pedido in lerPedidos)
            {
                string[] dadosDoPedido = pedido.Split(",");

                listaPedidos.Add(new Pedido
                {
                    PedidoId = int.Parse(dadosDoPedido[0]),
                    ComandaId = int.Parse(dadosDoPedido[1]),
                    ProdutoId = int.Parse(dadosDoPedido[2]),
                    QuantidadePorProduto = int.Parse(dadosDoPedido[3]),
                    AndamentoDoPedido = int.Parse(dadosDoPedido[4])
                });
            }
        }

        public static void BuscarComanda()
        {
            string[] lerComandas = File.ReadAllLines(caminhoComanda);
            foreach (string c in lerComandas)
            {
                string[] dadosDaComanda = c.Split(",");
                listaComandas.Add(new Comanda
                {
                    ComandaId = int.Parse(dadosDaComanda[0]),
                    MesaId = int.Parse(dadosDaComanda[1]),
                    DataHoraEntrada = DateTime.Parse(dadosDaComanda[2]),
                    DataHoraSaida = DateTime.Parse(dadosDaComanda[3]),
                    Valor = float.Parse(dadosDaComanda[4]),
                    ComandaPaga = bool.Parse(dadosDaComanda[5]),
                    QuantidadePessoasNaMesa = int.Parse(dadosDaComanda[6])
                });
            }
        }

        public static void BuscarStatusPedido()
        {
            string[] lerStatus = File.ReadAllLines(caminhoStatus);
            foreach (string s in lerStatus)
            {
                string[] dadosDoStatus = s.Split(",");

                listaStatusPedidos.Add(new StatusPedido
                {
                    StatusId = int.Parse(dadosDoStatus[0]),
                    Descricao = dadosDoStatus[1]
                });

            }
        }

        public static void SalvarComandas()
        {
            using (StreamWriter sw = File.AppendText(caminhoComanda))
            {
                listaComandas.ForEach(c =>
                {
                    var comanda = string.Join(',', c.ComandaId, c.MesaId, c.DataHoraEntrada, c.DataHoraSaida, c.Valor, c.ComandaPaga, c.QuantidadePessoasNaMesa);
                    sw.WriteLine(comanda);
                });
            }
        }

        public static void SalvarPedidos()
        {
            using (StreamWriter sw = File.AppendText(caminhoPedidos))
            {
                listaPedidos.ForEach(p =>
                {
                    var pedidos = (string.Join(',', p.PedidoId, p.ComandaId, p.ProdutoId, p.QuantidadePorProduto, p.AndamentoDoPedido));
                    sw.WriteLine(p);
                });
            }
        }

        public static void SalvarMesa()
        {
            using (StreamWriter sw = File.AppendText(caminhoPedidos))
            {
                listaMesas.ForEach(m =>
                {
                    var pedidos = (string.Join(',', m.MesaId, m.CapacidadePorMesa, m.MesaDisponivel));
                    sw.WriteLine(pedidos);
                });
            }
        }
    }
}