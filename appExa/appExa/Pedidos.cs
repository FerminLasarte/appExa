using System;
using System.Collections.Generic;

namespace appExa
{
    public class Pedidos
    {
        private List<Compra> _pedidos;
        private int _pedidoActual=1;

        public void agregarPedido()
        {
            DateTime now = DateTime.Now;
            Compra compra = new Compra(ref now,_pedidoActual);
            _pedidos.Add(compra);
            _pedidoActual++;
        }
    }
}