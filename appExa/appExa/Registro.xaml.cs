using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
        
        public static bool IsValidEmail(string inputEmail)
        {
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(inputEmail,expresion))
                {
                    if (Regex.Replace(inputEmail, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private void BotonRegistrarse_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(IsValidEmail(Email.Text).ToString());
            if ((this.Contrasena.Password == this.ConfirmContrasena.Password) && (IsValidEmail(Email.Text)))
            {
                sqlCon.Open();
                string consulta = "insert into Usuarios values ('"+Nombre.Text+"', '"+Apellido.Text+"', '"+Email.Text+"', '"+Usuario.Text+"', '"+Contrasena.Password+"')";
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.ExecuteNonQuery();
                sqlCon.Close();
                this.Close();
                MessageBox.Show("Usuario registrado con exito");
            }
            else
            {
                if (!(IsValidEmail(Email.Text)))
                    MessageBox.Show("El Email ingresado es incorrecto.");
                else
                {
                    MessageBox.Show("Las contrasenas no coinciden.");
                }
            }
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        private void Cerrar_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void Volver_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}