using System.Windows.Controls;
using System.Windows.Media;

namespace TravelVoucher.Tools
{
    class ColoredControl : TextBox
    {
        public void SetBackgroundColor(byte red, byte green, byte blue)
        {
            Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        public void SetBorderBrushColor(byte red, byte green, byte blue)
        {
            BorderBrush = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }
    }
}