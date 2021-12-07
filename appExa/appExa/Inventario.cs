using System.Collections.Generic;

namespace appExa
{
    public class Inventario
    {
        private Articulo[] _datos;
        private int _max = 0;
        private int _actual = 0;
        public void setMax(int max)
        {
            _datos = new Articulo[max];
            _max = max;
        }
        public void agregar(ref Articulo art)
        {
            if (_actual < _max) {
                _datos[_actual] = art;
                _actual++;
            }
        }

    }
}