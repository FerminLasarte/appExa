using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace appExa
{
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }
        
        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");
        private void BotonIngresar_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.PasswordBox.Password == this.ConfirmPasswordBox.Password)
            {
                sqlCon.Open();
                string consulta = "insert into Usuario values ("+Id_Usuario.Text+", '"+Nombre.Text+"', '"+Usuario.Text+"', '"+PasswordBox.Password+"')";
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.ExecuteNonQuery();
                sqlCon.Close();
                this.Close();
                aaa
            }
        }
    }
}