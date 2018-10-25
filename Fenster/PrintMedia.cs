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
        private int zoomFactor;

        public static void Print(Window w)
        {
            Application.Run(new PrintMedia(w, 100));
        }
        public PrintMedia(Window w, int zoomFactor)
        {
            this.zoomFactor=zoomFactor;
            this.temp = w;
            this.Paint += new PaintEventHandler(f1_paint);
            WindowState = FormWindowState.Maximized;
        }
        private void f1_paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Background
            int BcoordPairX = temp.getBackgound().getCoord()[0]*zoomFactor +10 + temp.getOffset(true);
            int BcoordPairY = temp.getBackgound().getCoord()[2] * zoomFactor +10+ temp.getOffset(false);
            int Bwidth = (temp.getBackgound().getCoord()[1] - temp.getBackgound().getCoord()[0]) * zoomFactor;
            int Bheight = (temp.getBackgound().getCoord()[3] - temp.getBackgound().getCoord()[2]) * zoomFactor;

            g.DrawRectangle(new Pen(Color.Black, 1), BcoordPairX , BcoordPairY , Bwidth , Bheight );

            for(int i = BcoordPairX; i<= BcoordPairX + Bwidth; i+=zoomFactor)
            {
                for(int j = BcoordPairY; j <= BcoordPairY+Bheight; j+=zoomFactor)
                {
                    Brush aBrush = Brushes.Olive;
                    g.FillEllipse(aBrush,i - 5, j - 5, 10, 10);
                }
            }

            foreach (Rectangle item in temp.getIn())
            {
                int coordPairX = item.getCoord()[0] * zoomFactor+10 + temp.getOffset(true);
                int coordPairY = item.getCoord()[2] * zoomFactor+10 + temp.getOffset(false);
                int width = (item.getCoord()[1] - item.getCoord()[0]) * zoomFactor;
                int height = (item.getCoord()[3] - item.getCoord()[2]) * zoomFactor;

                if ((height == 0) && (width !=0))
                {
                    g.DrawLine(new Pen(Color.Red, 2), coordPairX, coordPairY, coordPairX+width, coordPairY);
                }
                else if ((width == 0) && (height != 0))
                {
                    g.DrawLine(new Pen(Color.Red, 2), coordPairX, coordPairY, coordPairX, coordPairY+height);
                }
                else if((width == 0)&&(height == 0))
                {
                    Brush aBrush = (Brush)Brushes.Red;
                    g.FillEllipse(aBrush, coordPairX - 5, coordPairY - 5, 10, 10);
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Red, 2), coordPairX, coordPairY, width, height);
                }
                
            }
        }
    }
}
