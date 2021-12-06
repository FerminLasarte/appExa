using System.Collections.Generic;

namespace appExa
{
    public class Compra
    {
        private int _precio = 0;
        private List<Articulo> _articulos;

        public void agregarArticulo(ref Articulo art)
        {
            _articulos.Add(art);
            _precio += art.precio;
        }
    }
}