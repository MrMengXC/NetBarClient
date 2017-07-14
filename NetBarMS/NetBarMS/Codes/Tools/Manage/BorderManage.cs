using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Codes.Tools.Manage
{
    /// <summary>
    /// 边框管理类
    /// </summary>
    class BorderManage
    {

        public static void DrawBorder(Graphics gra,Rectangle angle,BORDER_TYPE type)
        {
            switch(type)
            {
                case BORDER_TYPE.TEXTEDIT_BORDER:
                    ControlPaint.DrawBorder(gra, angle, Color.Blue, ButtonBorderStyle.Solid);

                    break;

                default:

                    break;
            }


        }



    }
}
