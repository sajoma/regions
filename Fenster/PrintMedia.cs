using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Fenster
{
    public class PrintMedia : Form
    {
        private Window temp;
        public PrintMedia(Window w)
        {
            this.temp = w;
            this.Paint += new PaintEventHandler(f1_paint);
        }
        private void f1_paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int BcoordPairX = temp.getBackgound().getCoord()[0] + 10;
            int BcoordPairY = temp.getBackgound().getCoord()[2] + 10;
            int Bwidth = temp.getBackgound().getCoord()[1] - temp.getBackgound().getCoord()[0];
            int Bheight = temp.getBackgound().getCoord()[3] - temp.getBackgound().getCoord()[2];

            g.DrawRectangle(new Pen(Color.Black, 1), (Int32)BcoordPairX , (Int32)BcoordPairY , (Int32)Bwidth , (Int32)Bheight );

            foreach (Rectangle item in temp.getIn())
            {
                int coordPairX = item.getCoord()[0]+10;
                int coordPairY = item.getCoord()[2]+10;
                int width = item.getCoord()[1] - item.getCoord()[0];
                int height = item.getCoord()[3] - item.getCoord()[2];
                if(height == 0)
                {
                    g.DrawLine(new Pen(Color.Black, 1), coordPairX, coordPairY, (width + item.getCoord()[0] + 10), height+item.getCoord()[2] + 10);
                }
                if(width == 0)
                {

                }
                g.DrawRectangle(new Pen(Color.Black, 1),(Int32) coordPairX, (Int32) coordPairY, (Int32) width, (Int32) height);
            }
        }
    }
}
