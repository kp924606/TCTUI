using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media;

namespace TCTUI.TCTColor
{
    public static class TCTSolidColorBrush
    {
        public static readonly Brush LowBlue = new SolidColorBrush(Color.FromRgb(66, 66, 220));
        public static readonly Brush ShinyBlue = new SolidColorBrush(Color.FromRgb(0, 255, 255));
        public static readonly Brush LightBlue = new SolidColorBrush(Color.FromRgb(0, 128, 255));
        public static readonly Brush DarkBlue = new SolidColorBrush(Color.FromRgb(0, 0, 192));

        public static readonly Brush LowRed = new SolidColorBrush(Color.FromRgb(220, 66, 66));
        public static readonly Brush ShinyRed = new SolidColorBrush(Color.FromRgb(255, 64, 64));
        public static readonly Brush LightRed = new SolidColorBrush(Color.FromRgb(255, 0, 64));
        public static readonly Brush DarkRed = new SolidColorBrush(Color.FromRgb(192, 0, 0));

        public static readonly Brush LowGreen = new SolidColorBrush(Color.FromRgb(66, 220, 66));
        public static readonly Brush ShinyGreen = new SolidColorBrush(Color.FromRgb(128, 255, 64));
        public static readonly Brush LightGreen = new SolidColorBrush(Color.FromRgb(64, 255, 0));
        public static readonly Brush DarkGreen = new SolidColorBrush(Color.FromRgb(0, 192, 0));

        public static readonly Brush ShinyGray = new SolidColorBrush(Color.FromRgb(192, 192, 192));
        public static readonly Brush LightGray = new SolidColorBrush(Color.FromRgb(128, 128, 128));
        public static readonly Brush DarkGray = new SolidColorBrush(Color.FromRgb(64, 64, 64));

        public static readonly Brush YellowOrange = new SolidColorBrush(Color.FromRgb(255, 170, 0));
    }
}
