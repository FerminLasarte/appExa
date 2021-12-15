using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;

//conjunto de articulos
namespace appExa
{
    public class Inventario
    {
        private List<Articulo> _datos;

        public Inventario()
        {
            _datos = new List<Articulo>();
        }
        public void cargarInventario(string path) {
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
        public Articulo getItem(int pos)
        {
            Articulo* art = *_datos[pos];
            if (_datos[pos].disponible && _datos[pos].)
            
        }
        
    }
}