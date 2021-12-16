namespace appExa
{
    public class Articulo
    {
        private string _nombre;
        private string _categoria;
        private int _precio;
        private bool _limitado;
        private int _stock;
        private int _descuento;
        
        public Articulo(string nombre, string categoria, int precio)
        {
            _nombre = nombre;
            _categoria = categoria;
            _precio = precio;
            _limitado = false;
            _stock = 0;
            _descuento = 0;
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
        public bool limitado
        {
            get { return _limitado; }
            set { _limitado = value; }
        }
        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public int descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        public int precioFinal
        {
            get { return _precio*((100-_descuento)/100); }
        }
        public int stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        
    }
}