using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace appExa
{
    public class Compra
    {
        private int _precio;
        private List<Articulo> _articulos;
        private int _numeroCompra;
        private DateTime _fecha;
        private string _tipoFactura;

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
            _precio += art.precio;
        }

        public void borrarPos(int pos)
        {
            _precio -= _articulos[pos].precio;
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