using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCTUI.TCTEnum
{
    public enum TCTControlStyleType
    {
        /// <summary>
        /// 字體使用主要顏色(粗體), 背景使用次要白色, 框線使用主要顏色(寬度黃金比例).滑鼠進入時,縮放0.95
        /// </summary>
        Default,

        /// <summary>
        /// 字體使用主要顏色(粗體), 背景使用次要顏色, 框線使用主要顏色(寬度黃金比例).滑鼠進入時,縮放0.95, 背景使用主要顏色, 字體使用次要顏色(粗體), 框線使用次要顏色
        /// </summary>
        DefaultObvious,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放0.95
        /// </summary>
        Obvious,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放0.95, 背景使用黑色, 字體白色(粗體), 框線使用次要顏色
        /// </summary>
        ObviousDark,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放0.95, 背景使用次要顏色, 字體主要顏色(粗體), 框線使用主要顏色
        /// </summary>
        ObviousDefault,

        //---
        /// <summary>
        /// 字體使用主要顏色(粗體), 背景使用次要白色, 框線使用主要顏色(寬度黃金比例).滑鼠進入時,縮放1.10
        /// </summary>
        DefaultEnlarge,

        /// <summary>
        /// 字體使用主要顏色(粗體), 背景使用次要顏色, 框線使用主要顏色(寬度黃金比例).滑鼠進入時,縮放1.10, 背景使用主要顏色, 字體使用次要顏色(粗體), 框線使用次要顏色
        /// </summary>
        DefaultObviousEnlarge,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放1.10
        /// </summary>
        ObviousEnlarge,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放1.10, 背景使用黑色, 字體白色(粗體), 框線使用次要顏色
        /// </summary>
        ObviousDarkEnlarge,

        /// <summary>
        /// 字體次要顏色(粗體), 背景使用主要顏色, 框線使用次要顏色(寬度黃金比例).滑鼠進入時,縮放1.10, 背景使用次要顏色, 字體主要顏色(粗體), 框線使用主要顏色
        /// </summary>
        ObviousDefaultEnlarge,
    }
}
