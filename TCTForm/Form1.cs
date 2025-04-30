using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using TCTUI.TCTButton;
using TCTUI.TCTEnum; // A 專案內的 WPF 按鈕

namespace TCTForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitializeWPFButton();
        }

        private void InitializeWPFButton()
        {
            // 創建 WPF 控制項
            TCTCycleButton wpfButton = new TCTCycleButton();
            wpfButton.CircleSize = 60;
            wpfButton.MajorColor = new SolidColorBrush(Colors.Yellow);
            wpfButton.MinorColor = new SolidColorBrush(Colors.White);
            wpfButton.Content = @"123";
            wpfButton.StyleType = TCTControlStyleType.ObviousDarkEnlarge;

            // 創建 ElementHost 控制項
            ElementHost elementHost = new ElementHost
            {
                //AutoSize = true,
                //Dock = DockStyle.Fill, // 可以調整大小或設置為固定大小
                Child = wpfButton, // 將 WPF 控制項添加到 ElementHost
                //Width = 60,
                //Height  = 60
                Width = (int)wpfButton.CircleSize,
                Height  = (int)wpfButton.CircleSize,
            };

            // 將 ElementHost 添加到 WinForms Form
            this.Controls.Add(elementHost);            
        }
    }
}
