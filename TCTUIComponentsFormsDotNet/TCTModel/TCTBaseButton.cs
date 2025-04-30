using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCTUIComponentsFormsDotNet.TCTEnum;

namespace TCTUIComponentsFormsDotNet.TCTModel
{
    public partial class TCTBaseButton : Button
    {
        #region Property

        /// <summary>
        /// 樣式
        /// </summary>
        public TCTControlStyleType StyleType { set; get; }

        /// <summary>
        /// 主要顏色,預設為透明
        /// </summary>
        private Color _majorColor { set; get; }

        /// <summary>
        /// 主要顏色
        /// </summary>
        public Color MajorColor
        {
            get => this._majorColor;
            set
            {
                if (this._majorColor != value)
                {
                    this._majorColor = value;
                }
            }
        }

        /// <summary>
        /// 次要顏色,預設為透明
        /// </summary>
        private Color _minorColor { set; get; }

        /// <summary>
        /// 次要顏色
        /// </summary>
        public Color MinorColor
        {
            get => this._minorColor;
            set
            {
                if (this._minorColor != value)
                {
                    this._minorColor = value;
                }
            }
        }

        #endregion

        //[Browsable(false)]
        //public new Color BackColor
        //{
        //    get { return base.BackColor; }
        //    set { base.BackColor = Color.Yellow; }  // 始終設為預設值
        //}

        public TCTBaseButton()
        {
            InitializeComponent();            
        }

        public TCTBaseButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //this.BackColor = Color.Yellow;
        }
    }
}
