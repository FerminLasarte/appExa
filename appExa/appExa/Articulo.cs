namespace appExa
{
    public class Articulo
    {
        private string _nombre;
        private string _categoria;
        private int _precio;
        private bool _disponible;
        private int _disponibles;
        public Articulo(string nombre, string categoria, int precio)
        {
            _nombre = nombre;
            _categoria = categoria;
            _precio = precio;
            _disponible = true;
            _disponibles = 0;
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        public bool disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }
        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public int disponibles
        {
            get { return _disponibles; }
            set { _disponibles = value; }
        }
        
    }
}