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
        
        public static string Codigo()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }

        private void CambiarContrasena(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Codigo());
        }
    }
}