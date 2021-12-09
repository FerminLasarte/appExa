using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Input;

namespace appExa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BotonRegistrar_OnClick(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");

        private void BotonIngresar_OnClick(object sender, RoutedEventArgs e)
        {
            sqlCon.Open();
            SqlCommand consulta = new SqlCommand("select Usuario, Contrasena from Usuarios where Usuario = @tUsuario AND Contrasena = @tPassword", sqlCon);
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Cerrar_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OlvidarContrasena_OnClick(object sender, RoutedEventArgs e)
        {
            CambioContrasena newContrasena = new CambioContrasena();
            newContrasena.Show();
        }
    }
}