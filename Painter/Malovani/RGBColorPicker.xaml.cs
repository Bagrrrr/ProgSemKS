using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Malovani
{
    /// <summary>
    /// Interaction logic for RGBColorPicker.xaml
    /// </summary>
    public partial class RGBColorPicker : Window
    {
        public bool Success { get; private set; }
        public Color Color { get; private set; }
        public RGBColorPicker()
        {
            InitializeComponent();
            keyValuePairs = new Dictionary<TextBox, Slider>()
            {
                {txtRed, sliRed },
                { txtGreen, sliGreen },
                { txtBlue, sliBlue }
            };
        }
        Dictionary<TextBox, Slider> keyValuePairs;

        private void Integer(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(cc => Char.IsNumber(cc));
            base.OnPreviewTextInput(e);
        }

        private void ChangeRectangleColor()
        {
            byte red = Convert.ToByte(txtRed.Text);
            byte green = Convert.ToByte(txtGreen.Text);
            byte blue = Convert.ToByte(txtBlue.Text);
            rectColor.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));

        }

        private void ChangeHexLabel()
        {
            byte red = Convert.ToByte(txtRed.Text);
            byte green = Convert.ToByte(txtGreen.Text);
            byte blue = Convert.ToByte(txtBlue.Text);
            string hex = "#";
            if (red < 10)
                hex += "0";
            hex += string.Format("{0:X}", red);
            if (green < 10)
                hex += "0";
            hex += string.Format("{0:X}", green);
            if (blue < 10)
                hex += "0";
            hex += string.Format("{0:X}", blue);
            lblHex.Content = hex;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text != "" && Convert.ToInt32(text) > 255)
            {
                MessageBox.Show("Zadávejte pouze hodnoty nižší než 256");
                ((TextBox)sender).Text = text.Substring(0, text.Length - 1);
            }
            if (keyValuePairs != null)
            {
                keyValuePairs[((TextBox)sender)].Value = Convert.ToInt32(((TextBox)sender).Text);
                ChangeRectangleColor();
                ChangeHexLabel();
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (keyValuePairs != null)
            {
                TextBox txt = keyValuePairs.FirstOrDefault(x => x.Value == ((Slider)sender)).Key;
                txt.Text = ((Slider)sender).Value.ToString();
            }

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            byte red = Convert.ToByte(txtRed.Text);
            byte green = Convert.ToByte(txtGreen.Text);
            byte blue = Convert.ToByte(txtBlue.Text);
            Color = Color.FromRgb(red,green, blue);
            Close();
        }

        
    }
}
