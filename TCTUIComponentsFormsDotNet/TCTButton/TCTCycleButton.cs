using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCTUIComponentsFormsDotNet.TCTEnum;
using TCTUIComponentsFormsDotNet.TCTModel;

namespace TCTUIComponentsFormsDotNet.TCTButton
{
    public partial class TCTCycleButton : TCTBaseButton
    {
        #region Property

        /// <summary>
        /// 尺寸,預設值 (60)
        /// </summary>
        public int _circleSize = 60;

        /// <summary>
        /// 尺寸
        /// </summary>
        public int CircleSize
        {
            get => this._circleSize;
            set
            {
                if (this._circleSize < 0)
                { 
                
                }
                else if (this._circleSize != value)
                {
                    this._circleSize = value;
                }
            }
        }

        /// <summary>
        /// 邊框粗細
        /// </summary>
        public int _optimalBorderThickness { get; set; }

        /// <summary>
        /// 邊框粗細
        /// </summary>
        public int OptimalBorderThickness
        {
            get
            {
                int goldenSize = (int)Math.Round((this.CircleSize / 1.618 / 100 * 5));
                return goldenSize;
            }
        }

        #endregion

        public TCTCycleButton()
        {
            InitializeComponent();
        }

        public TCTCycleButton(IContainer container)
            :base()
        {
            container.Add(this);

            InitializeComponent();
            
            //if (this.Size.Width != this.Size.Height)
            //{
            //    throw new InvalidOperationException("Please check Width & Height, must same");
            //}

            //if (this.CircleSize <= 0)
            //{
            //    throw new InvalidOperationException("Please check TCTCycleButton, must setttingsh CircleSize and Value > 0");
            //}


            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font(this.Font, FontStyle.Bold);

            // 設置圓形的 Region，這裡使用 GraphicsPath 來創建圓形
            //this.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath(
            //    new[] { new Point(0, 0), new Point(this.CircleSize, 0), new Point(this.CircleSize, this.CircleSize), new Point(0, this.CircleSize) },
            //    new byte[] { 0, 0, 0, 0 }
            //));                       

            this.VisibleChanged += TCTCycleButton_VisibleChanged!;
            this.MouseEnter += TCTCycleButton_MouseEnter!;
            this.MouseLeave += TCTCycleButton_MouseLeave!;            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var tpcolor = Color.White;

            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultObvious:
                case TCTControlStyleType.DefaultEnlarge:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    tpcolor = this.MajorColor;                    
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDefault:
                case TCTControlStyleType.ObviousEnlarge:
                case TCTControlStyleType.ObviousDarkEnlarge:
                case TCTControlStyleType.ObviousDefaultEnlarge:                   
                    tpcolor = this.MinorColor;
                    break;
                default:
                    break;
            }

            // 設定圓形的邊框顏色和粗細
            using (Pen borderPen = new Pen(tpcolor, this.OptimalBorderThickness)) // 使用設定的邊框顏色和粗細
            {
                // 使用 Graphics 對象來繪製圓形的邊框
                e.Graphics.DrawEllipse(borderPen, 0, 0, this.CircleSize, this.CircleSize); // 略微調整寬高以保持圓形邊界
            }
        }

        /// <summary>
        /// 預設樣式
        /// </summary>
        private void RegisterStyle()
        {
            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultObvious:
                case TCTControlStyleType.DefaultEnlarge:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    this.ForeColor = this.MajorColor;
                    this.BackColor = this.MinorColor;
                    //this.FlatAppearance.BorderColor = this.MajorColor;
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDefault:
                case TCTControlStyleType.ObviousEnlarge:
                case TCTControlStyleType.ObviousDarkEnlarge:
                case TCTControlStyleType.ObviousDefaultEnlarge:
                    this.ForeColor = this.MinorColor;
                    this.BackColor = this.MajorColor;
                    //this.FlatAppearance.BorderColor = this.MinorColor;
                    break;
                default:
                    break;
            }            
        }

        /// <summary>
        /// 當可見性變化時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCTCycleButton_VisibleChanged(object sender, EventArgs e)
        {
            // 檢查是否是顯示（Visible）狀態
            if (this.Visible)
            {
                this.CircleSize = this.Width;

                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(path);

                this.RegisterStyle();
            }
        }

        /// <summary>
        /// 滑鼠進入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCTCycleButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            // 顯示鼠標移入時的變化
            switch (this.StyleType)
            {
                case TCTControlStyleType.Default:
                case TCTControlStyleType.DefaultEnlarge:                    
                    break;
                case TCTControlStyleType.DefaultObvious:
                case TCTControlStyleType.DefaultObviousEnlarge:
                    this.ForeColor = this.MinorColor;
                    this.BackColor = this.MajorColor;
                    this.FlatAppearance.BorderColor = this.MinorColor;                    
                    break;
                case TCTControlStyleType.Obvious:
                case TCTControlStyleType.ObviousEnlarge:                    
                    break;
                case TCTControlStyleType.ObviousDark:
                case TCTControlStyleType.ObviousDarkEnlarge:
                    this.ForeColor = Color.White;
                    this.BackColor = Color.Black;
                    this.FlatAppearance.BorderColor = this.MinorColor;                   
                    break;
                case TCTControlStyleType.ObviousDefault:
                case TCTControlStyleType.ObviousDefaultEnlarge:
                    this.ForeColor = this.MajorColor;
                    this.BackColor = this.MinorColor;
                    this.FlatAppearance.BorderColor = this.MajorColor;
                    break;
                default:
                    break;
            }

            //switch (this.StyleType)
            //{
            //    case TCTControlStyleType.Default:
            //    case TCTControlStyleType.DefaultObvious:
            //        this.Scale(new SizeF(0.95f, 0.95f));
            //        break;
            //    case TCTControlStyleType.DefaultEnlarge:
            //    case TCTControlStyleType.DefaultObviousEnlarge:
            //        this.Scale(new SizeF(1.10f, 1.10f));
            //        break;
            //    case TCTControlStyleType.Obvious:
            //    case TCTControlStyleType.ObviousDark:
            //    case TCTControlStyleType.ObviousDefault:
            //        this.Scale(new SizeF(0.95f, 0.95f));
            //        break;
            //    case TCTControlStyleType.ObviousEnlarge:
            //    case TCTControlStyleType.ObviousDarkEnlarge:
            //    case TCTControlStyleType.ObviousDefaultEnlarge:
            //        this.Scale(new SizeF(1.10f, 1.10f));
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// 滑鼠離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCTCycleButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            // 滑鼠移出時恢復原樣
            this.RegisterStyle();
        }
    }
}
