using System.Collections.Generic;

namespace appExa
{
    public class Compra
    {
        private int _precio;
        private List<Articulo> _articulos;

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