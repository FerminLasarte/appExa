using System;
using System.Windows;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace appExa
{
    public partial class CambioContrasena : Window
    {
        public CambioContrasena()
        {
            InitializeComponent();
        }
        
        SqlConnection sqlCon = new SqlConnection("server = DESKTOP-BRILGCD\\SERVIDORAPPEXA; database = BaseEXA; integrated security = true;");

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

        private void Confirmar(object sender, RoutedEventArgs e)
        {
            //sqlCon.Open();
            //string consulta = "update Usuarios set Contrasena = '" + PasswordBox.Password + "' where Usuario = '"+Usuario.Text+"' OR Email = '"+Usuario.Text+"'";
            sqlCon.Open();
            SqlCommand consulta =
                new SqlCommand("select Usuario, Contrasena from Usuarios where Email = @tEmail", sqlCon);
            consulta.Parameters.AddWithValue("@tEmail", Email.Text);
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.Read())
            {
                sendMail(Email.Text, "Cambio de contrasena", "Prueba");
                Captcha pantallaCaptcha = new Captcha();
                pantallaCaptcha.Show();
                
            }
            else
            {
                MessageBox.Show("El Email no se encuentra registrado.");
            }
            sqlCon.Close();
        }
    }
}