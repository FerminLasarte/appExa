using System.Windows;
using System.Windows.Input;

namespace appExa
{
    public partial class VentanaArticulos : Window
    {
        public VentanaArticulos()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}