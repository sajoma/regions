using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fenster
{
    public class Window
    {
        private Background background;

        // Welche Bereiche sind In dem Fenster?
        private ListOperations In;

        public Window (Background background, ListOperations In)
        {
            this.background = background;
            this.In = In;
        }
        public void printWindow()
        {
            int minX = background.getCoord()[0];
            int maxX = background.getCoord()[1];
            int minY = background.getCoord()[2];
            int maxY = background.getCoord()[3];

            for (int y = maxY; y >= minY; y--)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Rectangle r = new Rectangle(x, x, y, y);
                    bool schonGedruckt = false;
                    foreach (Rectangle s in In)
                    {
                        if (Rectangle.subset(r, s) && !schonGedruckt)
                        {
                            schonGedruckt = true;
                            Console.Write("o");
                        }
                    }
                    if (!schonGedruckt)
                    {
                        Console.Write("x");
                    }
                }
                Console.WriteLine();
            };
            Console.ReadKey();
        }

        private void CutOrIn(ListOperations In, Rectangle newRectangle)
        {
            ListOperations toBeInserted;

            if(In.Count() == 0)
            {
                In.Add(newRectangle);
            }
            for(int c = In.Count()-1; c>=0; c--)
            {
                toBeInserted = Rectangle.AddIntoRectangle(In[c], newRectangle);
                foreach (Rectangle elemAdd in toBeInserted)
                {
                    In.Add(elemAdd);
                }
            }
            


        }

        public void AddOr(Rectangle newRectangle)
        {
            //1) Prüfe auf Kollisionen mit bisherigen Rectangles
            this.CutOrIn(In, newRectangle);
            this.In.simplifyByX(In, Math.Max(0, In.Count()-1));
            this.background.resize(In);
        }

        //public void AddAnd

        
        
        
    }
}
