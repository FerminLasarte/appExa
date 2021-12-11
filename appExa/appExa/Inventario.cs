using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;

namespace appExa
{
    public class Inventario
    {
        private Articulo[] _datos;
        private int _max = 0;
        public void setMax(int max)
        {
            _datos = new Articulo[max];
            _max = max;
        }
        public void generarInventario(string path)
        {
            using (var reader = new StreamReader(File.OpenRead(@path)))
            {
                for (int i = 0; !reader.EndOfStream; i++) {
                    string line = reader.ReadLine();
                    var values = line.Split(';');
                    _datos[i] = new Articulo(values[0], values[1], int.Parse(values[2]));
                }
            }
        }

        public void agregarAlArchivo(string path, ref Articulo art)
        {
            using (var writer = new StreamWriter(@path))
            {
                string agregar = (art.nombre + ';' + art.categoria + ';' + art.precio);
                writer.
            }
        }

    }
}