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
        private List<Rectangle> In;

        public Window (Background background, List<Rectangle> In)
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
        public void AddOr(Rectangle newRectangle)
        {
            this.simplifyAddIn(In, newRectangle);
            background.resize(In);
        }

        //public void AddOr

        private List<Rectangle> simplifyAddIn(List<Rectangle> In, Rectangle newRectangle)
        {
            // In is about to receive newRectangle as one extra rectangle. Assuming that the list was already optimal
            // we only need to check how newRectangle behaves to all the previous ones:

            bool intersectExists = intersectionWithList(In, newRectangle);
            bool isSubset = isSubsetOf(In, newRectangle);

            //Case1, the last rectangle is a subset of the old list:
            // We do not need to add anything to the List
            if (isSubset)
            {
                return In;
            }

            // Case2: there is a non-emptyintersection with INOrOut
            // Check if any of the rectangles are subset of the newRectangle. Delete thosee rectangles.
            // Add the new rectangle
            if (intersectExists)
            {
                for (int i = In.Count() - 1; i >= 0; i--)
                {
                    if (Rectangle.subset(In[i], newRectangle))
                    {
                        In.RemoveAt(i);
                    }
                }
                In.Add(newRectangle);
                return In;
            }
            else
            {
                // Case1, the last rectangle is outside of the old list. There is no simplification possible. Add the rectangle.
                In.Add(newRectangle);
                return In;
            }




        }
        private bool isSubsetOf(List<Rectangle> In, Rectangle newRectangle)
        {
            //Zählt wie viele Punkte im Durchschnitt mit der Liste stehen
            int ctr = 0;

            List<int> Coord = newRectangle.getCoord();
            int minX = Coord[0];
            int maxX = Coord[1];
            int minY = Coord[2];
            int maxY = Coord[3];

            for (int x = minX; x<=maxX; x++)
            {
                for(int y= minY; y<=maxY; y++)
                {
                    Rectangle temp = new Rectangle(x, x, y, y);
                    foreach (Rectangle item in In)
                    {
                        if (Rectangle.subset(temp,item))
                        {
                            ctr++;
                            break;
                        }
                    }

                }
            }

            //Wenn alle Punkte auch in der Liste => return true sonst false
            return (ctr == (maxX - minX+1) * (maxY - minY+1)) ? true : false;
            
        }
        private static bool intersectionWithList(List<Rectangle> rectList, Rectangle intersectWith)
        {
            if (rectList.Count() == 0)
            {
                return false;
            }

            foreach (Rectangle item in rectList)
            {
                //If item has a non-empty intersection invalid is false
                if (!Rectangle.intersection(item, intersectWith).getInvalid())
                {
                    return true;
                }
            }

            return false;
            
        }
    }
}
