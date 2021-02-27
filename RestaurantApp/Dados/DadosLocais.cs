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
        public static string caminhoPedidos = @"C:\Users\Dell\Desktop\restaurantApp\RestaurantApp\Dados\Pedidos.csv";
        public static string caminhoComanda = @"C:\Users\Dell\Desktop\restaurantApp\RestaurantApp\Dados\Comandas.csv";
        public static string caminhoProdutos = @"C:\Users\Dell\Desktop\restaurantApp\RestaurantApp\Dados\MenuProdutos.csv";
        public static string caminhoMesas = @"C:\Users\Dell\Desktop\restaurantApp\RestaurantApp\Dados\DadosMesa.csv";
        public static string caminhoStatus = @"C:\Users\Dell\Desktop\restaurantApp\RestaurantApp\Dados\StatusPedido.csv";

        public static List<Comanda> listaComandas = new List<Comanda>();
        public static List<Produto> listaProdutos = new List<Produto>();
        public static List<Pedido> listaPedidos = new List<Pedido>();
        public static List<Mesa> listaMesas = new List<Mesa>();
        public static List<StatusPedido> listaStatusPedidos = new List<StatusPedido>();

        public static List<Comanda> BuscarComandas()
        {
            string[] comandas = File.ReadAllLines(caminhoComanda);
            foreach (string comanda in comandas)
            {
                string[] dadosComanda = comanda.Split(",");
                int comandaId = int.Parse(dadosComanda[0]);
                int mesaId = int.Parse(dadosComanda[1]);
                DateTime dataHoraEntrada = DateTime.Parse(dadosComanda[2]);
                DateTime dataHoraSaida = DateTime.Parse(dadosComanda[3]);
                float valor = float.Parse(dadosComanda[4]);
                bool comandaPaga = bool.Parse(dadosComanda[5]);
                int quantidadePessoasNaMesa = int.Parse(dadosComanda[6]);


                listaComandas.Add(new Comanda()
                {
                    ComandaId = comandaId,
                    MesaId = mesaId,
                    DataHoraEntrada = dataHoraEntrada,
                    DataHoraSaida = dataHoraSaida,
                    Valor = valor,
                    ComandaPaga = comandaPaga,
                    QuantidadePessoasNaMesa = quantidadePessoasNaMesa
                });
            }
            return listaComandas;
        }
        public static List<Produto> BuscarProdutos()
        {
            string[] lerProdutos = File.ReadAllLines(caminhoProdutos);
            foreach (string produto in lerProdutos)
            {
                string[] dadosDoProduto = produto.Split(",");
                var produtoId = int.Parse(dadosDoProduto[0]);
                string nomeProduto = dadosDoProduto[1];
                float valorProduto = float.Parse(dadosDoProduto[2], CultureInfo.InvariantCulture);
                bool produtoDisponivel = bool.Parse(dadosDoProduto[3]);

                listaProdutos.Add(new Produto
                {
                    ProdutoId = produtoId,
                    NomeProduto = nomeProduto,
                    ValorProduto = valorProduto,
                    ProdutoDisponivel = produtoDisponivel
                });
            }
            return listaProdutos;
        }

        public static List<Mesa> BuscarMesas()
        {
            string[] mesas = File.ReadAllLines(caminhoMesas);
            foreach (string mesa in mesas)
            {
                string[] dadosDaMesa = mesa.Split(",");
                int mesaId = int.Parse(dadosDaMesa[0]);
                int capacidadePorMesa = int.Parse(dadosDaMesa[1]);
                bool mesaDisponivel = bool.Parse(dadosDaMesa[2]);

                listaMesas.Add(new Mesa
                {
                    MesaId = mesaId,
                    CapacidadePorMesa = capacidadePorMesa,
                    MesaDisponivel = mesaDisponivel
                });
            }
            return listaMesas;
        }


        public static List<Pedido> BuscarPedidos()
        {
            string[] lerPedidos = File.ReadAllLines(caminhoPedidos);
            foreach (string pedido in lerPedidos)
            {
                string[] dadosDoPedido = pedido.Split(",");
                int pedidoId = int.Parse(dadosDoPedido[0]);
                int comandaId = int.Parse(dadosDoPedido[1]);
                int produtoId = int.Parse(dadosDoPedido[2]);
                int quantidadePorProduto = int.Parse(dadosDoPedido[3]);
                float valorPedido = float.Parse(dadosDoPedido[4], CultureInfo.InvariantCulture);
                int andamentoDoPedido = int.Parse(dadosDoPedido[5]);

                listaPedidos.Add(new Pedido
                {
                    PedidoId = pedidoId,
                    ComandaId = comandaId,
                    ProdutoId = produtoId,
                    QuantidadePorProduto = quantidadePorProduto,
                    ValorPedido = valorPedido,
                    AndamentoDoPedido = andamentoDoPedido
                });
            }
            return listaPedidos;
        }

        public static List<StatusPedido> BuscarStatusPedido()
        {
            string[] lerStatus = File.ReadAllLines(caminhoStatus);
            foreach (string s in lerStatus)
            {
                string[] dadosDoStatus = s.Split(",");
                int statusId = int.Parse(dadosDoStatus[0]);
                string descricao = dadosDoStatus[1];

                listaStatusPedidos.Add(new StatusPedido
                {
                    StatusId = statusId,
                    Descricao = descricao
                });

            }
            return listaStatusPedidos;
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
                    var pedidos = (string.Join(',', p.PedidoId, p.ComandaId, p.ProdutoId, p.QuantidadePorProduto, p.ValorPedido, p.AndamentoDoPedido));
                    sw.WriteLine(pedidos);
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