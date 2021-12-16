using System;
using System.Collections;
using System.Collections.Generic;

namespace appExa
{
    public class Pedidos: IEnumerator,IEnumerable
    {
        private List<Compra> _pedidos;
        private int _pedidoActual;
        private int _position;
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            _position++;
            return (_position < _pedidos.Count);
        }
        //IEnumerable
        public void Reset()
        {
            _position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return _pedidos[_position];}
        }
        public Pedidos()
        {
            _pedidos = new List<Compra>();
            _pedidoActual = 1;
        }
        public void agregarPedido()
        {
            DateTime now = DateTime.Now;
            Compra compra = new Compra(ref now,_pedidoActual);
            _pedidos.Add(compra);
            _pedidoActual++;
        }

        public void despacharPedido(int numeroPedido)
        {
            List<Articulo> categoria1 = new List<Articulo>();
            List<Articulo> categoria2 = new List<Articulo>();
            foreach (Articulo art in _pedidos[numeroPedido])
            {
                switch (art.categoria)
                {
                    case "categoria1":
                    {
                        categoria1.Add(art);
                        break;
                    }
                    case "categoria2":
                    {
                        categoria2.Add(art);
                        break;
                    }
                }
            }
            // mandar categoria1 a servidor categoria 1
            // mandar categoria2 a servidor categoria 2
            // ...
            
        }
    }
}