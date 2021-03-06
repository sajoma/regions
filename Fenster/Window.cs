﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fenster
{
    public class Window
    {
        //Um wie weit ist das Fenster zum Ursprung verschoben?
        private int OffsetX;
        private int OffsetY;

        private Background region;
        private ListOperations In;

        public Window() 
        {
            this.region = new Background(0, 0, 0, 0);
            this.In = new ListOperations();
            this.OffsetX = 0;
            this.OffsetY = 0;
        }

        public Window (int OffsetX, int OffsetY)
        {
            this.region = new Background(0, 0, 0, 0);
            this.In = new ListOperations();
            this.OffsetX = OffsetX;
            this.OffsetY = OffsetY;
        }

        public int getOffset(bool xCoord)
        {
            return xCoord ? OffsetX : OffsetY;
        }
        public void printRegion()
        {
            int minX = region.getCoord()[0];
            int maxX = region.getCoord()[1];
            int minY = region.getCoord()[2];
            int maxY = region.getCoord()[3];

            for (int y = minY; y <= maxY; y++)
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
                            Console.Write("R");
                        }
                    }
                    if (!schonGedruckt)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            };
            Console.ReadKey();
        }
        public void printDebugRegion()
        {
            foreach(Rectangle item in In)
            {
                Console.WriteLine("[" + item.getCoord()[0].ToString() + "," 
                    + item.getCoord()[1].ToString() + "]" 
                    + "x" 
                    + "[" + item.getCoord()[2].ToString() + "," + item.getCoord()[3].ToString() + "]");
            }
            Console.ReadKey();
        }
        public void OrRectRegion(Rectangle newRectangle)
        {
            //1) Prüfe auf Kollisionen mit bisherigen Rectangles
            for (int c = In.Count() - 1; c >= 0; c--)
            {
                if(Rectangle.subset(In[c], newRectangle))
                {
                    In.RemoveAt(c);
                }
            }
            this.CutOrIn(In, newRectangle, true);
            this.region.RegionRect(In);
        }

        public void AndRectRegion(Rectangle newRectangle)
        {
            ListOperations newIn = new ListOperations();
            Rectangle a;
            for (int c = In.Count() - 1; c >= 0; c--)
            {
                a = Rectangle.intersection(this.In[c], newRectangle);
                this.CutOrIn(newIn, newRectangle, true);
            }
            this.OffsetRegion();
            this.region.RegionRect(newIn);
            this.In = newIn;    
        }

        public void XorRectRegion(Rectangle newRectangle)
        {

            //Step 0) Resize rectangle. Anything outside regionRectangle does not interest us as it will not be added to In
            int backMinX = this.region.getCoord()[0];
            int backMaxX = this.region.getCoord()[1];
            int backMinY = this.region.getCoord()[2];
            int backMaxY = this.region.getCoord()[3];

            Rectangle back = new Rectangle(backMinX, backMaxX, backMinY, backMaxY);
            Rectangle Rintersect = Rectangle.intersection(back, newRectangle);

             if(!Rintersect.getInvalid())
             {
                // Step 1) Find Intersection with Rectangles
                ListOperations intersect = ListOperations.regionListIntersect(this.In, newRectangle);

                // Step 2) Add rectangles except for the intersection
                this.In = addNotInIntersect(intersect, newRectangle);

                // Step 3) do the offset thing
                this.OffsetRegion();
             }
             else
                {
                    this.OrRectRegion(newRectangle);
                }

            this.region.RegionRect(In);
           
        }

        private ListOperations addNotInIntersect(ListOperations intersect, Rectangle newRectangle)
        {
            ListOperations result = new ListOperations();
            bool added = false;
            // Step 1) Add In. All rectangles inside In are disjoint.
            foreach (Rectangle item in this.In)
            {
                added = false;
                for (int c = intersect.Count() - 1; c >= 0; c--)
                {
                    //letztes Argument ist das XOR=true (die vereinigungsart);
                    if(!Rectangle.intersection(intersect[c], item).getInvalid() && !added)
                    {
                        result.AddRange(Rectangle.AddIntoRectangle(intersect[c], item, true));
                        added = true;
                    }
                    if ((c==0) && (!added))
                    {
                       result.AddRange(Rectangle.AddIntoRectangle(intersect[c], item, true));
                    } 
                }
            }

            // Step 2 add XOR to everywhere except for the intersections
            Window w = new Window();
            w.In = intersect;
            int length = w.In.Count();
            w.CutOrIn(intersect, newRectangle, false);
            w.In.RemoveRange(0, length);

            for (int i = w.In.Count() - 1; i >= 0; i--)
            {
                if (i > w.In.Count() - 1)
                {
                    i = w.In.Count() - 1;
                }
                w.In = w.In.simplifyByX(w.In, i);
                if (i > w.In.Count() - 1)
                {
                    i = w.In.Count() - 1;
                }
                w.In = w.In.simplifyByY(w.In, i);
            }
            result.AddRange(w.In);
            return result;
        }

        private void CutOrIn(ListOperations In, Rectangle newRectangle, bool simplify)
        {
            int minX = newRectangle.getCoord()[0];
            int maxX = newRectangle.getCoord()[1];
            int minY = newRectangle.getCoord()[2];
            int maxY = newRectangle.getCoord()[3];

            int ctrX = 0;
            Rectangle start = new Rectangle(minX, minX, minY, minY);
            bool isIntersect = ListOperations.boolListIntersect(In, start);

            for (int y = minY; y <= maxY; y++)
            {
                ctrX = 0;
                for (int x = minX; x <= maxX; x++)
                {
                    Rectangle r = new Rectangle(x, x, y, y);
                    if (x == minX)
                    {
                        isIntersect = ListOperations.boolListIntersect(In, r);
                    }
                    if (ListOperations.boolListIntersect(In, r))
                    {
                        //We were in open space
                        if (!isIntersect)
                        {
                            Rectangle toAdd = new Rectangle(x - ctrX, x - 1, y, y);
                            In.validAdd(toAdd, simplify);
                            ctrX = -1;
                        }
                        //Else: We used to intersect and we are intersecting now too
                        isIntersect = true;
                    }
                    else
                    {
                        //We are not intersecting and x == maxX. And we didn't intersect.
                        if ((x == maxX) && (!isIntersect))
                        {
                            Rectangle endAdd = new Rectangle(x - ctrX, x, y, y);
                            In.validAdd(endAdd, simplify);
                            ctrX = -1;
                        }
                        //We are not intersecting and x == maxX. But we used to intersect
                        if ((x == maxX) && (isIntersect))
                        {
                            Rectangle endAddSquare = new Rectangle(x, x, y, y);
                            In.validAdd(endAddSquare, simplify);
                            ctrX = -1;
                        }
                        if (isIntersect)
                        {
                            ctrX = 0;
                        }
                        isIntersect = false;

                    }
                    ctrX++;
                }
            }
        }

        private List<int> CalcOffset()
        {
            List<int> result = new List<int>();
            if(In.Count() == 0)
            {
                result.Add(0);
                result.Add(0);
                return result;
            }

            int minX = In[0].getCoord()[0];
            int minY = In[0].getCoord()[0];

            foreach (Rectangle item in In)
            {
                if(minX > item.getCoord()[0])
                {
                    minX = item.getCoord()[0];
                }
                if (minY > item.getCoord()[2])
                {
                    minY = item.getCoord()[2];
                }
            }

            result.Add(minX);
            result.Add(minY);
            return result;
        }
        private void OffsetRegion()
        {
            int offsetX = this.CalcOffset()[0];
            int offsetY = this.CalcOffset()[1];

            for (int i = In.Count()-1; i>=0; i--)
            {
                int minX = In[i].getCoord()[0];
                int maxX = In[i].getCoord()[1];
                int minY = In[i].getCoord()[2];
                int maxY = In[i].getCoord()[3];
                In[i].setCoord(minX - offsetX, maxX - offsetX, minY - offsetY, maxY - offsetY);
            }
        }
        
        public Background getBackgound()
        {
            return this.region;
        }
        public List<Rectangle> getIn()
        {
            return this.In;
        }

    }
}
