using System;
using System.Windows;
using System.Linq;

namespace appExa
{
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
        }

        private void CambiarContrasena(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Codigo());
        }
    }
}