using System;
using System.Collections.Generic;
using RestaurantApp.Entities;

namespace RestaurantApp.Service
{
    class PedidoService
    {
        List<Pedido> pedidos = new List<Pedido>();
                
        public void AdicionarProduto(Pedido pedido)
        {
            pedidos.Add(pedido);
        }
        public void RemoverProduto(Pedido pedido)
        {
            pedidos.Remove(pedido);
        }
        public float ValorTotalPedido(float valor)
        {
            float sum = 0;
            sum += valor;
            return sum;
        }
    }
}
