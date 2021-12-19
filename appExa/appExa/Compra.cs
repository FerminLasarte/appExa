using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

// listado de la compra del cliente
namespace appExa
{
    public class Compra: IEnumerator,IEnumerable
    {
        private int _precio;
        private List<Articulo> _articulos;
        private int _numeroCompra;
        private DateTime _fecha;
        private string _tipoFactura;
        private int _pos;
        
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            _pos++;
            return (_pos < _articulos.Count);
        }
        //IEnumerable
        public void Reset()
        {
            _pos = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return _articulos[_pos];}
        }

        public int precio
        {
            get { return _precio; }
        }
        public DateTime fecha
        {
            get { return _fecha; }
        }
        public Compra(ref DateTime fecha, int numeroCompra)
        {
            _fecha = fecha;
            _precio = 0;
            _numeroCompra = numeroCompra;
            _articulos = new List<Articulo>();
            _tipoFactura = null;
        }

        public void agregarArt(ref Articulo art)
        {
            _articulos.Add(art);
            _precio += art.precioFinal;
        }

        public void borrarPos(int pos)
        {
            _precio -= _articulos[pos].precioFinal;
            _articulos.RemoveAt(pos);
        }

        public void imprimirComanda()
        {
            // esto tendria q generar un pdf que se imprime
        }

        public int facturarYGetPrecio(string tipofactura)
        {
            _tipoFactura = tipofactura;
            if (_tipoFactura != "efectivo")
                try
                {
                    // facturar en la afip
                }
                catch (Exception e)
                {
                    // reintentar
                    throw;
                }
                finally
                {
                    // imprimir comprobante fiscal
                }

            imprimirComanda();
            return _precio;
        }
    }
}