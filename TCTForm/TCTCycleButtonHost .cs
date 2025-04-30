using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using TCTUI.TCTButton;
using TCTUI.TCTEnum; // A 專案內的 WPF 按鈕

namespace TCTForm
{
    [ToolboxItem(true)]
    public class TCTCycleButtonHost : Control
    {
        private ElementHost elementHost;

        public TCTCycleButtonHost()
        {
            // 創建 TCTCycleButton 控制項
            TCTCycleButton wpfButton = new TCTCycleButton
            {
                //CircleSize = 60,
                MajorColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow),
                MinorColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White),
                Content = @"123",
                StyleType = TCTControlStyleType.ObviousDarkEnlarge
            };

            // 創建 ElementHost 並設置為自動填充
            elementHost = new ElementHost
            {
                //Dock = DockStyle.Fill  // 設置填滿容器
                Width = (int)wpfButton.CircleSize,
                Height = (int)wpfButton.CircleSize,
            };

            this.Controls.Add(elementHost);  // 添加 ElementHost 到自定義控件

            
            // 將 WPF 控制項添加到 ElementHost 中
            elementHost.Child = wpfButton;
        }
    }
}
