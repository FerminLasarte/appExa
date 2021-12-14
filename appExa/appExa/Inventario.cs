using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;

namespace appExa
{
    public class Inventario
    {
        private List<Articulo> _datos;
        public void generarInventario(string path) {
            using (var reader = new StreamReader(File.OpenRead(@path))) {   // levanto archivo en lista
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    var values = line.Split(';');
                    Articulo agregar = new Articulo(values[0], values[1], int.Parse(values[2]));
                    _datos.Add(agregar);
                }
            }
        }
        public void agregarAlInventario(string path, ref Articulo art) {
            _datos.Add(art);
            using (var writer = new StreamWriter(@path)) // agrego al archivo
                writer.WriteLine(art.nombre + ';' + art.categoria + ';' + art.precio);
        }
        public Articulo getPos(int pos) {
            if ((pos >= 0) || (pos < _datos.Count))
                return _datos[pos];
            else
                return new Articulo("error","error",0); // articulo vacio
        }

    }
}