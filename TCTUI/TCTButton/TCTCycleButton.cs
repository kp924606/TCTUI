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

namespace TCTUI.TCTButton
{
    /// <summary>
    /// 圓形按鈕
    /// </summary>
    public class TCTCycleButton : TCTBaseButton
    {
        #region Property
        /// <summary>
        /// 尺寸
        /// </summary>
        public double CircleSize
        {
            get => (double)GetValue(CircleSizeProperty);
            set => SetValue(CircleSizeProperty, value);
        }

        /// <summary>
        /// 尺寸
        /// </summary>
        public static readonly DependencyProperty CircleSizeProperty =
            DependencyProperty.Register(
                nameof(CircleSize),   // 屬性名稱
                typeof(double),       // 屬性類型
                typeof(TCTCycleButton), // 所屬類別
                new FrameworkPropertyMetadata(60.0, // 預設值 (60)
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    OnCircleSizeChanged), // 屬性變更時觸發
                    ValidateCircleSize);  // 驗證屬性

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
                double goldenSize = (this.CircleSize / 1.618 / 100 * 5) + 1;
                return goldenSize;
            }
        }

        #endregion

        static TCTCycleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TCTCycleButton),
                new FrameworkPropertyMetadata(typeof(TCTCycleButton)));
        }

        #region Init
        /// <summary>
        /// 初始化
        /// </summary>
        public TCTCycleButton()
        {
            this.Loaded += TCTCycleButton_Loaded;
        }

        #endregion

        #region Method
        /// <summary>
        /// 載入動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void TCTCycleButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.MajorColor == null)
            {
                throw new InvalidOperationException("Please check TCTCycleButton must setttingsh MajorColor");
            }

            if (this.MinorColor == null)
            {
                throw new InvalidOperationException("Please check TCTCycleButton must setttingsh MinorColor");
            }

            if (this.CircleSize <= 0)
            {
                throw new InvalidOperationException("Please check TCTCycleButton, must setttingsh CircleSize and Value > 0");
            }

            // 註冊樣式
            this.RegisterStyle();
        }

        /// <summary>
        /// 註冊樣式
        /// </summary>
        private void RegisterStyle()
        {
            Style style = new Style(typeof(TCTCycleButton));

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
            ControlTemplate template = new ControlTemplate(typeof(TCTCycleButton));
            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            // 創建圓形
            FrameworkElementFactory ellipse = new FrameworkElementFactory(typeof(Ellipse));
            ellipse.SetBinding(Shape.FillProperty, new Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            ellipse.SetBinding(Shape.StrokeProperty, new Binding("BorderBrush") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            ellipse.SetBinding(Shape.StrokeThicknessProperty, new Binding("BorderThickness") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            // 設定邊框粗細
            ellipse.SetValue(Shape.StrokeThicknessProperty, this.OptimalBorderThickness);

            // 按鈕添加陰影效果
            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Colors.Gray,          // 陰影顏色
                Direction = 315,               // 陰影的方向，315度為右下角
                ShadowDepth = 6,              // 陰影的深度，數值越大陰影偏移越大
                BlurRadius = 15               // 陰影的模糊半徑，數值越大陰影越模糊
            };

            // 將陰影效果應用到圓形
            ellipse.SetValue(EffectProperty, shadowEffect);

            // 創建文字
            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            // 添加到 Grid
            grid.AppendChild(ellipse);
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

        /// <summary>
        /// 驗證數值大於 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ValidateCircleSize(object value)
        {
            double size = (double)value;
            return size > 0; // 大於 0 才是合理的
        }

        /// <summary>
        /// 設置大小屬性
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCircleSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TCTCycleButton button)
            {
                double newSize = (double)e.NewValue;
                button.Width = newSize;
                button.Height = newSize;
            }
        }

        #endregion
    }
}
