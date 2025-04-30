using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using TCTUI.TCTEnum;

namespace TCTUI.TCTButton
{
    class CircularButton : Button
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
                typeof(CircularButton), // 所屬類別
                new FrameworkPropertyMetadata(60.0, // 預設值 (60)
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    OnCircleSizeChanged), // 屬性變更時觸發
                    ValidateCircleSize);  // 驗證屬性

        /// <summary>
        /// 樣式
        /// </summary>
        public TCTControlStyleType StyleType
        {
            get => (TCTControlStyleType)GetValue(TCTControlStyleTypeProperty);
            set => SetValue(TCTControlStyleTypeProperty, value);
        }

        /// <summary>
        /// 樣式
        /// </summary>
        public static readonly DependencyProperty TCTControlStyleTypeProperty =
           DependencyProperty.Register(
               nameof(StyleType),
               typeof(TCTControlStyleType),
               typeof(CircularButton),
               new FrameworkPropertyMetadata(TCTControlStyleType.Default, // 預設值
                   FrameworkPropertyMetadataOptions.AffectsRender)); // 當屬性變更時重新渲染

        /// <summary>
        /// 主要顏色
        /// </summary>
        public Brush MajorColor
        {
            get => (Brush)GetValue(MajorColorProperty);
            set => SetValue(MajorColorProperty, value);
        }

        /// <summary>
        /// 主要顏色
        /// </summary>
        public static readonly DependencyProperty MajorColorProperty =
            DependencyProperty.Register(
                nameof(MajorColor),  // 屬性名稱
                typeof(Brush),       // 屬性類型
                typeof(CircularButton), // 所屬類別
                new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent), // 預設值
                    FrameworkPropertyMetadataOptions.AffectsRender)); // 當屬性變更時重新渲染

        /// <summary>
        /// 次要顏色
        /// </summary>
        public Brush MinorColor
        {
            get => (Brush)GetValue(MinorColorProperty);
            set => SetValue(MinorColorProperty, value);
        }

        /// <summary>
        /// 次要顏色
        /// </summary>
        public static readonly DependencyProperty MinorColorProperty =
           DependencyProperty.Register(
               nameof(MinorColor),  // 屬性名稱
               typeof(Brush),       // 屬性類型
               typeof(CircularButton), // 所屬類別
               new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent), // 預設值
                   FrameworkPropertyMetadataOptions.AffectsRender)); // 當屬性變更時重新渲染


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
                double goldenSize = CircleSize / 1.618 / 100 * 5 + 1;
                return goldenSize;
            }
        }

        //public static readonly DependencyProperty BackgroundProperty =
        //    DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(CircularButton),
        //        new FrameworkPropertyMetadata(Brushes.Transparent));
        #endregion

        #region Init
        /// <summary>
        /// 初始化
        /// </summary>
        public CircularButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularButton),
                new FrameworkPropertyMetadata(typeof(CircularButton)));

            Loaded += CircularButton_Loaded;
        }

        #endregion

        #region Method

        /// <summary>
        /// 載入動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void CircularButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (MajorColor == null)
            {
                throw new InvalidOperationException("Please check CircularButton must setttingsh MajorColor");
            }

            if (MinorColor == null)
            {
                throw new InvalidOperationException("Please check CircularButton must setttingsh MinorColor");
            }

            if (CircleSize <= 0)
            {
                throw new InvalidOperationException("Please check CircularButton, must setttingsh CircleSize and Value > 0");
            }

            // 註冊樣式
            RegisterStyle();

        }

        /// <summary>
        /// 註冊樣式
        /// </summary>
        private void RegisterStyle()
        {
            //private void RegisterStyle(TCTTIStyleType styletype, Brush majorcolor, Brush minorcolor)
            Style style = new Style(typeof(CircularButton));

            // 設定按鈕的預設屬性
            //style.Setters.Add(new Setter(WidthProperty, 100.0));
            //style.Setters.Add(new Setter(HeightProperty, 100.0));
            //style.Setters.Add(new Setter(BackgroundProperty, Brushes.Yellow));
            //style.Setters.Add(new Setter(ForegroundProperty, Brushes.Black));
            //style.Setters.Add(new Setter(BorderBrushProperty, Brushes.White));
            //style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(20)));
            //Setter majorColorSetter = new Setter(BackgroundProperty, new Binding(nameof(MajorColor))
            //{
            //    RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
            //});

            //this.StyleType, this.MajorColor, this.MinorColor
            //TCTTIStyleType styletype, Brush majorcolor, Brush minorcolor

            switch (StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultObvious:
                    style.Setters.Add(new Setter(ForegroundProperty, MajorColor));
                    style.Setters.Add(new Setter(BackgroundProperty, MinorColor));
                    style.Setters.Add(new Setter(BorderBrushProperty, MajorColor));
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDefault:
                    style.Setters.Add(new Setter(ForegroundProperty, MinorColor));
                    style.Setters.Add(new Setter(BackgroundProperty, MajorColor));
                    style.Setters.Add(new Setter(BorderBrushProperty, MinorColor));
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
            ControlTemplate template = new ControlTemplate(typeof(CircularButton));
            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            // 創建圓形
            FrameworkElementFactory ellipse = new FrameworkElementFactory(typeof(Ellipse));
            ellipse.SetBinding(Shape.FillProperty, new Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            ellipse.SetBinding(Shape.StrokeProperty, new Binding("BorderBrush") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            ellipse.SetBinding(Shape.StrokeThicknessProperty, new Binding("BorderThickness") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            // 設定邊框粗細
            ellipse.SetValue(Shape.StrokeThicknessProperty, OptimalBorderThickness);

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
            contentPresenter.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);

            // 添加到 Grid
            grid.AppendChild(ellipse);
            grid.AppendChild(contentPresenter);

            template.VisualTree = grid;
            style.Setters.Add(new Setter(TemplateProperty, template));

            // === 滑鼠移入時變化 ===
            Trigger mouseOverTrigger = new Trigger { Property = IsMouseOverProperty, Value = true };
            mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(0.95, 0.95))); // 縮放 0.95
            //mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, Brushes.Black)); // 背景變黑
            //mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, Brushes.White)); // 文字變白
            switch (StyleType)
            {
                case TCTControlStyleType.Default:
                    break;
                case TCTControlStyleType.DefaultObvious:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, MinorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, MajorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, MinorColor));
                    break;
                case TCTControlStyleType.Obvious:
                    break;
                case TCTControlStyleType.ObviousDark:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, Brushes.White));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, Brushes.Black));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, MinorColor));
                    break;
                case TCTControlStyleType.ObviousDefault:
                    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, MajorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, MinorColor));
                    mouseOverTrigger.Setters.Add(new Setter(BorderBrushProperty, MajorColor));
                    break;
                default:
                    break;
            }
            //---                       

            style.Triggers.Add(mouseOverTrigger);

            Style = style;
        }

        //private static void RegisterStyle(TCTTIStyleType styletype, Brush majorcolor, Brush minorcolor)
        //{
        //    Style style = new Style(typeof(CircularButton));

        //    // 設定按鈕的預設屬性
        //    //style.Setters.Add(new Setter(WidthProperty, 100.0));
        //    //style.Setters.Add(new Setter(HeightProperty, 100.0));
        //    //style.Setters.Add(new Setter(BackgroundProperty, Brushes.Yellow));
        //    //style.Setters.Add(new Setter(ForegroundProperty, Brushes.Black));
        //    //style.Setters.Add(new Setter(BorderBrushProperty, Brushes.White));
        //    //Setter majorColorSetter = new Setter(BackgroundProperty, new Binding(nameof(MajorColor))
        //    //{
        //    //    RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
        //    //});


        //    style.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Colors.Yellow)));
        //    style.Setters.Add(new Setter(ForegroundProperty, new SolidColorBrush(Colors.Black)));
        //    style.Setters.Add(new Setter(BorderBrushProperty, new SolidColorBrush(Colors.White)));
        //    style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(2)));
        //    style.Setters.Add(new Setter(CursorProperty, System.Windows.Input.Cursors.Hand));
        //    style.Setters.Add(new Setter(FontWeightProperty, FontWeights.Bold));

        //    // 設定縮放 (預設1.0, 1.0)
        //    ScaleTransform scaleTransform = new ScaleTransform(1.0, 1.0);
        //    style.Setters.Add(new Setter(RenderTransformProperty, scaleTransform));
        //    style.Setters.Add(new Setter(RenderTransformOriginProperty, new Point(0.5, 0.5)));

        //    // 設定 ControlTemplate
        //    ControlTemplate template = new ControlTemplate(typeof(CircularButton));
        //    FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

        //    // 創建圓形
        //    FrameworkElementFactory ellipse = new FrameworkElementFactory(typeof(Ellipse));
        //    ellipse.SetBinding(Shape.FillProperty, new System.Windows.Data.Binding("Background") { RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent) });
        //    ellipse.SetBinding(Shape.StrokeProperty, new System.Windows.Data.Binding("BorderBrush") { RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent) });
        //    ellipse.SetBinding(Shape.StrokeThicknessProperty, new System.Windows.Data.Binding("BorderThickness") { RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent) });

        //    // 創建文字
        //    FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
        //    contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
        //    contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

        //    // 添加到 Grid
        //    grid.AppendChild(ellipse);
        //    grid.AppendChild(contentPresenter);

        //    template.VisualTree = grid;
        //    style.Setters.Add(new Setter(TemplateProperty, template));

        //    // === 滑鼠移入時變化 ===
        //    Trigger mouseOverTrigger = new Trigger { Property = IsMouseOverProperty, Value = true };
        //    mouseOverTrigger.Setters.Add(new Setter(BackgroundProperty, Brushes.Black)); // 背景變黑
        //    mouseOverTrigger.Setters.Add(new Setter(ForegroundProperty, Brushes.White)); // 文字變白
        //    mouseOverTrigger.Setters.Add(new Setter(RenderTransformProperty, new ScaleTransform(0.9, 0.9))); // 縮放 0.9

        //    style.Triggers.Add(mouseOverTrigger);

        //    // 加入 Application ResourceDictionary (避免需要 Generic.xaml)
        //    Application.Current.Resources.Add(typeof(CircularButton), style);
        //}

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
            return size > 0; // 大於 0 才是合法的
        }

        /// <summary>
        /// 設置大小屬性
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCircleSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CircularButton button)
            {
                double newSize = (double)e.NewValue;
                button.Width = newSize;
                button.Height = newSize;
            }
        }

        #endregion

    }
}
