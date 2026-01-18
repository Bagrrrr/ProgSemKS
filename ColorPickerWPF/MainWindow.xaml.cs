using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorPickerWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SLR.Minimum = 0;
            SLR.Maximum = 255;
            SLG.Minimum = 0;
            SLG.Maximum = 255;
            SLB.Minimum = 0;
            SLB.Maximum = 255;
        }

        private void SLB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            T1.Text = ((int)SLR.Value).ToString();
            T2.Text = ((int)SLG.Value).ToString();
            T3.Text = ((int)SLB.Value).ToString();
            UpdateColorPreview();
        }
        private void UpdateColorPreview()
        {
            if (SLR == null || SLG == null || SLB == null || ColorPreview == null || Hex == null)
                return;
            byte r = (byte)SLR.Value;
            byte g = (byte)SLG.Value;
            byte b = (byte)SLB.Value;
            Color color = Color.FromRgb(r, g, b);
            ColorPreview.Fill = new SolidColorBrush(color);
            Hex.Content = string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
        }
        private byte? validateByte(string t)
        {
            if (string.IsNullOrEmpty(t)) return 0;


            if (int.TryParse(t, out int value))
            {
                if (value >= 0 && value <= 255)
                {
                    return (byte)value;
                }
            }
            MessageBox.Show("Please enter a whole number between 0 and 255.",
                            "Invalid Input",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
            return null;
        }

        private void T1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            TextBox tb = sender as TextBox;
            if (tb == null || SLR == null) return;
            byte? result = validateByte(tb.Text);
            if (result == null)
            {
                tb.Text = "0"; 
                tb.SelectAll(); 
            }
            else
            {
                if (tb == T1) SLR.Value = result.Value;
                else if (tb == T2) SLG.Value = result.Value;
                else if (tb == T3) SLB.Value = result.Value;
            }
        }
    }
}