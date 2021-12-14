using System;
using System.Collections.Generic;
namespace appExa
{
    public class Compra
    {
        private int _precio;
        private List<Articulo> _articulos;
        private int _numeroCompra;
        private DateTime _fecha;

        public Compra(ref DateTime fecha, int numeroCompra)
        {
            _fecha = fecha;
            _numeroCompra = numeroCompra;
        }
        public void AgregarArt(ref Articulo art)
        {
            _articulos.Add(art);
            _precio += art.precio;
        }
        
        public void BorrarPos(int pos)
        {
            if (pos < _articulos.Count)
            {
                _precio -= _articulos[pos].precio;
                _articulos.RemoveAt(pos);
            }
        }
    }
}