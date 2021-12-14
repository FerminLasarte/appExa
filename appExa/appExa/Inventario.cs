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
        public void setMax(int max) {
            _datos = new Articulo[max];
            _max = max;
        }
        public void generarInventario(string path) {
            List<Articulo> temp = new List<Articulo>();
            using (var reader = new StreamReader(File.OpenRead(@path))) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    var values = line.Split(';');
                    Articulo agregar = new Articulo(values[0], values[1], int.Parse(values[2]));
                    temp.Add(agregar);
                }
            }
            setMax(temp.Count);
            int i=0;
            foreach (Articulo art in temp) {
                _datos[i] = art;
                i++;
            }
        }

        public void agregarAlArchivo(string path, ref Articulo art) {
            using (var writer = new StreamWriter(@path))
                writer.WriteLine(art.nombre + ';' + art.categoria + ';' + art.precio);
        }

        public void agregarAlSistema(string path, ref Articulo art) {
            
        }

    }
}