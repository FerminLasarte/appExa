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
            Name = Input.Text;
            nameLabel.Content = $"hola, {Name.ToString()}";
        }
    }
}