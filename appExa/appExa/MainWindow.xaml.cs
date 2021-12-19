using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
namespace appExa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string User = "root";
        private const string Contrasena = "toor";
        private const string _Path ="/inventario.csv";
        private Inventario _inventario = new Inventario(_Path);
        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Boton_OnClick(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        private void BotonIngresar_OnClick(object sender, RoutedEventArgs e)
        {
            sqlCon.Open();
            SqlCommand consulta = new SqlCommand("select Usuario, Password from Usuario where Usuario = @tUsuario AND Password = @tPassword", sqlCon);
            consulta.Parameters.AddWithValue("@tUsuario", Usuario.Text);
            consulta.Parameters.AddWithValue("@tPassword", PasswordBox.Password);
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.Read())
                MessageBox.Show("Inicio de sesion correcto");
            else
            {
                MessageBox.Show("El usuario y/o la contrasena son incorrectos");
            }
            sqlCon.Close();
        }
    }
} 