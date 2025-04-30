using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows.Shapes;
using TCTUI.TCTModel;
using TCTUI.TCTEnum;
using TCTUI.ValueConverter;

namespace TCTUI.TCTButton
{
    /// <summary>
    /// 圓形按鈕
    /// </summary>
    public class TCTRectangleButton : TCTBaseButton
    {
        #region Property
        /// <summary>
        /// 邊框粗細
        /// </summary>
        public double _optimalBorderThickness { get; set; }

        /// <summary>
        /// 邊框粗細
        /// </summary>
        public double OptimalBorderThickness
        {
            get
            {
                double width = double.IsNaN(this.Width) ? DefaultWidthHeight : this.Width;
                double height = double.IsNaN(this.Height) ? DefaultWidthHeight : this.Height;
                double goldenSize = (Math.Min(width, height) / 1.618 / 100 * 5) + 1;
                return goldenSize;
                //if (double.IsNaN(this.Width) || this.Width <= 0 || double.IsNaN(this.Height) || this.Height <= 0)
                //{
                //    return (DefaultWidthHeight / 1.618 / 100 * 5) + 1;
                //}
                //else
                //{
                //    double goldenSize = (Math.Min(this.Width, this.Height) / 1.618 / 100 * 5) + 1;
                //    return goldenSize;
                //}               
            }
        }

        #endregion

        static TCTRectangleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TCTRectangleButton),
                new FrameworkPropertyMetadata(typeof(TCTRectangleButton)));
        }

        #region Init
        /// <summary>
        /// 初始化
        /// </summary>
        public TCTRectangleButton()
        {           
            this.Loaded += TCTRectangleButton_Loaded;
        }

        #endregion


        #region Method
        /// <summary>
        /// 載入動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void TCTRectangleButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.MajorColor == null)
            {
                this.MajorColor = new SolidColorBrush(Colors.Yellow);
                //throw new InvalidOperationException("Please check TCTRectangleButton must setttingsh MajorColor");
            }

            if (this.MinorColor == null)
            {
                this.MajorColor = new SolidColorBrush(Colors.White);
                //throw new InvalidOperationException("Please check TCTRectangleButton must setttingsh MinorColor");
            }

            if (this.Width <= 0)
            {
                this.Width = DefaultWidthHeight;
                //throw new InvalidOperationException("Please check TCTRectangleButton, must setttingsh Width and Value > 0");
            }

            if (this.Height <= 0)
            {
                this.Width = DefaultWidthHeight;
                //throw new InvalidOperationException("Please check TCTRectangleButton, must setttingsh Height and Value > 0");
            }

            // 註冊樣式
            this.RegisterStyle();

        }

        /// <summary>
        /// 註冊樣式
        /// </summary>
        private void RegisterStyle()
        {
            Style style = new Style(typeof(TCTRectangleButton));

            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultObvious:
                case TCTControlStyleType.DefaultEnlarge:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    style.Setters.Add(new Setter(ForegroundProperty, this.MajorColor));
                    style.Setters.Add(new Setter(BackgroundProperty, this.MinorColor));
                    style.Setters.Add(new Setter(BorderBrushProperty, this.MajorColor));
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDefault:
                case TCTControlStyleType.ObviousEnlarge:
                case TCTControlStyleType.ObviousDarkEnlarge:
                case TCTControlStyleType.ObviousDefaultEnlarge:
                    style.Setters.Add(new Setter(ForegroundProperty, this.MinorColor));
                    style.Setters.Add(new Setter(BackgroundProperty, this.MajorColor));
                    style.Setters.Add(new Setter(BorderBrushProperty, this.MinorColor));
                    break;
                default:
                    break;
            }
            style.Setters.Add(new Setter(CursorProperty, System.Windows.Input.Cursors.Hand));
            style.Setters.Add(new Setter(FontWeightProperty, FontWeights.Bold));

            // 設定縮放 (預設1.0, 1.0)
            ScaleTransform scaleTransform = new ScaleTransform(1.0, 1.0);
            style.Setters.Add(new Setter(RenderTransformProperty, scaleTransform));
            style.Setters.Add(new Setter(RenderTransformOriginProperty, new Point(0.5, 0.5)));

            // 設定 ControlTemplate
            ControlTemplate template = new ControlTemplate(typeof(TCTRectangleButton));
            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            // 創建一個 Border，並設定固定 CornerRadius
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(this.OptimalBorderThickness));  // 設定圓角
            border.SetBinding(Border.BackgroundProperty, new Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            border.SetBinding(Border.BorderBrushProperty, new Binding("BorderBrush") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            border.SetBinding(Border.BorderThicknessProperty, new Binding("BorderThickness") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            // 設定邊框粗細
            border.SetValue(Shape.StrokeThicknessProperty, this.OptimalBorderThickness);

            // 按鈕添加陰影效果
            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Colors.Gray,          // 陰影顏色
                Direction = 315,               // 陰影的方向，315度為右下角
                ShadowDepth = 6,              // 陰影的深度，數值越大陰影偏移越大
                BlurRadius = 15               // 陰影的模糊半徑，數值越大陰影越模糊
            };

            // 將陰影效果應用到圓形
            //ellipse.SetValue(EffectProperty, shadowEffect);
            border.SetValue(EffectProperty, shadowEffect);

            // 創建文字
            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            //123            
            // 圖層（黑色透明 PNG）
            var imageBorder = new FrameworkElementFactory(typeof(Border));
            var imageBrush = new FrameworkElementFactory(typeof(Border));
            imageBorder.SetBinding(Border.BackgroundProperty, new Binding(nameof(BackgroundImage))
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
                Converter = new ImageSourceToBrushConverter()
             });            
            //123456

            // 添加到 Grid
            //grid.AppendChild(ellipse);
            //邊框
            grid.AppendChild(border);
            //圖片
            grid.AppendChild(imageBorder);
            //創建文字
            grid.AppendChild(contentPresenter);

            template.VisualTree = grid;
            style.Setters.Add(new Setter(TemplateProperty, template));

            // === 滑鼠移入時變化 ===
            Trigger mouseOverTrigger = new Trigger { Property = IsMouseOverProperty, Value = true };
            //mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(0.95, 0.95))); // 縮放 0.95
            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultObvious:
                    mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(0.95, 0.95))); // 縮放 0.95
                    break;
                case TCTControlStyleType.DefaultEnlarge:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(1.10, 1.10))); // 縮放 1.10
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDefault:
                    mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(0.95, 0.95))); // 縮放 0.95
                    break;
                case TCTControlStyleType.ObviousEnlarge:
                case TCTControlStyleType.ObviousDarkEnlarge:
                case TCTControlStyleType.ObviousDefaultEnlarge:
                    mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(1.10, 1.10))); // 縮放 1.10
                    break;
                default:
                    break;
            }

            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultEnlarge:
                    break;
                case TCTControlStyleType.DefaultObvious:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, this.MinorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, this.MajorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, this.MinorColor));
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousEnlarge:
                    break;
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDarkEnlarge:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, Brushes.White));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, Brushes.Black));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, this.MinorColor));
                    break;
                case TCTControlStyleType.ObviousDefault:
                case TCTControlStyleType.ObviousDefaultEnlarge:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, this.MajorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, this.MinorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, this.MajorColor));
                    break;
                default:
                    break;
            }            
            style.Triggers.Add(mouseOverTrigger);

            this.Style = style;
        }
        #endregion

        #region Static Method



        #endregion
    }
}
