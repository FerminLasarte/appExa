using System.Windows;

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

        private void Boton_OnClick(object sender, RoutedEventArgs e)
        {
            if ((Usuario.Text == User) && (Contrasena ==  PasswordBox.Password))
            {
                NameLabel.Content = $"hola, {Usuario.Text.ToString()}";
                Ventana1 ventana = new Ventana1();
                ventana.Show();
            }
            
        }
        

    }
}