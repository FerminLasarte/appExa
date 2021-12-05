using System.Windows;

namespace appExa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string Name = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton_OnClick(object sender, RoutedEventArgs e)
        {
            Name = Usuario.Text;
            NameLabel.Content = $"hola, {Name.ToString()}";
        }
        
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "Password")
            {
                StatusText.Text = "'Password' is not allowed as a password.";
            }
            else
            {
                StatusText.Text = string.Empty;
            }
        }
    }
}