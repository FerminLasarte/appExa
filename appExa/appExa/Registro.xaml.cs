using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace appExa
{
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");
        private void BotonRegistrarse_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.Contrasena.Password == this.ConfirmContrasena.Password)
            {
                sqlCon.Open();
                string consulta = "insert into Usuarios values ('"+Nombre.Text+"', '"+Apellido.Text+"', '"+Email.Text+"', '"+Usuario.Text+"', '"+Contrasena.Password+"')";
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.ExecuteNonQuery();
                sqlCon.Close();
                this.Close();
                
            }
            MessageBox.Show("Usuario registrado con exito");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        private void Cerrar_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}