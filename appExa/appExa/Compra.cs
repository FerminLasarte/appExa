using System.Collections.Generic;

namespace appExa
{
    public class Compra
    {
        private int _precio;
        private List<Articulo> _articulos;

        public void agregarArt(ref Articulo art)
        {
            _articulos.Add(art);
            _precio += art.precio;
        }

        public void borrarPos(int pos)
        {
            if (pos < _articulos.Count)
            {
                _precio -= _articulos[pos].precio;
                _articulos.RemoveAt(pos);
            }
        }
    }
}