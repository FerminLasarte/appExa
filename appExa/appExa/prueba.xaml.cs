using System.Windows.Controls;
using System;
using System.Windows;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Input;

namespace appExa
{
    public partial class prueba : Page
    {
        public prueba()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");

        string captcha;

        public static void sendMail(string to, string asunto, string body)
        {
            string from = "AppExa2021@hotmail.com";
            string displayName = "AppEXA";

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "AppExaAdmin");
                client.EnableSsl = true;
                
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string CodigoCaptcha()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var CharArr = new char[8];
            var random = new Random();

            for (int i = 0; i < CharArr.Length; i++)
            {
                CharArr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(CharArr);
            return resultString;
        }

        private void EnviarCaptcha(object sender, RoutedEventArgs e)
        {
            sqlCon.Open();
            SqlCommand consulta =
                new SqlCommand("select Usuario, Contrasena from Usuarios where Email = @tEmail", sqlCon);
            consulta.Parameters.AddWithValue("@tEmail", Email.Text);
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.Read())
            {
                string htmlCode = "<DOCTYPE html>";
                captcha = CodigoCaptcha();
                sendMail(Email.Text, "Cambio de contrasena", "Su codigo es: " + captcha);
                Email.IsReadOnly = true;
            }
            else
            { 
                MessageBox.Show("El Email no se encuentra registrado.");
            }
            sqlCon.Close();
        }

        private void Confirmar(object sender, RoutedEventArgs e)
        {
            if (captcha == this.Captcha.Text)
            {
                sqlCon.Open();
                string consulta = "update Usuarios set Contrasena = '"+Contrasena.Password+"' where Email ='"+Email.Text+"'";
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.ExecuteNonQuery();
                sqlCon.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("El CAPTCHA ingresado no es correcto.");
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
        
    }
}