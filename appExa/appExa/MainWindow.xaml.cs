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
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // FALTA SERVIDOR SQL
        private SqlConnection con = new SqlConnection(@"Data Source=(servidor");

        public void Logear(string User, string Contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_Usuario FROM usuarios WHERE Usuario = @usuario AND Contrasena = @pas, con");
                cmd.Parameters.AddWithValue("usuario", User);
                cmd.Parameters.AddWithValue("pas", Contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admin")
                    {
                        // ventana ADMIN
                    }
                    else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        // ventana USER
                    }
                }
                else
                {
                    MessageBox.Show("El usuario y/o la contrasena ingresados son incorrectos");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void Boton_OnClick(object sender, RoutedEventArgs e)
        {
            Logear(this.Usuario.Text, this.PasswordBox.Password);
            if ((Usuario.Text == User) && (Contrasena ==  PasswordBox.Password))
            {
                NameLabel.Content = $"hola, {Usuario.Text.ToString()}";
                Ventana1 ventana = new Ventana1();
                ventana.Show();
            }
        }
    }
}