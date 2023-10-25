using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TravelVoucher.Tools
{
    class ColoredControl : TextBox
    {
        /// <summary>
        /// Покраска заднего фона элемента управления
        /// </summary>
        /// <param name="element">Элемент управления для покраски</param>
        /// <param name="red">Контраст красного</param>
        /// <param name="green">Контраст зелёного</param>
        /// <param name="blue">Контраст синего</param>
        public static void SetBackgroundColor(UIElement element, byte red, 
                                              byte green, byte blue)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(red, green, blue));
            if (element is Control control)
            {
                control.Background = brush;
            }
        }

        /// <summary>
        /// Покраска рамки вокруг элемента управления
        /// </summary>
        /// <param name="element">Элемент управления для покраски</param>
        /// <param name="red">Контраст красного</param>
        /// <param name="green">Контраст зелёного</param>
        /// <param name="blue">Контраст синего</param>
        public static void SetBorderColor(UIElement element, byte red, 
                                          byte green, byte blue)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(red, green, blue));
            if (element is Control control)
            {
                control.BorderBrush = brush;
            }
        }
    }
}