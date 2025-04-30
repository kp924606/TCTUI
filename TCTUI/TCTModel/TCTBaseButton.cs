using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TCTUI.TCTButton;
using TCTUI.TCTEnum;

namespace TCTUI.TCTModel
{
    /// <summary>
    /// 基礎按鈕
    /// </summary>
    public class TCTBaseButton : Button
    {
        #region Property

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
               typeof(TCTBaseButton),
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
                typeof(TCTBaseButton), // 所屬類別
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
               typeof(TCTBaseButton), // 所屬類別
               new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent), // 預設值
                   FrameworkPropertyMetadataOptions.AffectsRender)); // 當屬性變更時重新渲染


        /// <summary>
        /// 背景圖片
        /// </summary>
        public ImageSource BackgroundImage
        {
            get => (ImageSource)GetValue(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }

        /// <summary>
        /// 背景圖片屬性
        /// </summary>
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register(
                nameof(BackgroundImage),             // 屬性名稱
                typeof(ImageSource),                 // 屬性類型
                typeof(TCTBaseButton),          // 所屬類別
                new FrameworkPropertyMetadata(null,  // 預設值為 null
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnBackgroundImageChanged)); // 屬性變更時觸發重繪

        /// <summary>
        /// 設置背景圖片
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnBackgroundImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TCTBaseButton button && e.NewValue is ImageSource newImage)
            {
                // 僅當使用者未設置 Background 時，才自動設為圖片背景
                if (button.ReadLocalValue(BackgroundProperty) == DependencyProperty.UnsetValue)
                {
                    button.Background = new ImageBrush(newImage)
                    {
                        Stretch = Stretch.UniformToFill
                    };
                }

                //// 套用背景圖片為 ImageBrush
                //button.Background = new ImageBrush(newImage)
                //{
                //    Stretch = Stretch.UniformToFill
                //};
            }
        }

        #endregion
    }
}
