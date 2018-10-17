using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fenster
{
    public class Rectangle
    {
        protected int minX, maxX, minY, maxY;
        protected bool invalid;
        public Rectangle(int minX, int maxX, int minY, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;

            // Is intersection actually empty?
            if ((minX > maxX) || (minY > maxY))
            {
                this.invalid = true;
            }
        }
        public List<int> getCoord()
        {
            List<int> coordinates = new List<int>(new int[] { this.minX, this.maxX, this.minY, this.maxY });
            return coordinates;
        }
        public bool getInvalid()
        {
            return this.invalid;
        }
        public static Rectangle intersection(Rectangle a, Rectangle b)
        {
            // get intersection x_Axis:
            int minX = Math.Max(a.getCoord()[0], b.getCoord()[0]);
            int maxX = Math.Min(a.getCoord()[1], b.getCoord()[1]);

            // get Intersection y-Axis:
            int minY = Math.Max(a.getCoord()[2], b.getCoord()[2]);
            int maxY = Math.Min(a.getCoord()[3], b.getCoord()[3]);

            //Falls intersection keinen sinn macht, z.B. minX>maxX, dann setzt konstruktor invalid auf true;
            Rectangle c = new Rectangle(minX, maxX, minY, maxY);
            return c;
        }
        public static bool subset(Rectangle a, Rectangle b)
        {
            //Check x-Axis
            if ((a.minX >= b.minX) && (a.maxX <= b.maxX))
            {
                //Check y-Axis
                return ((a.minY >= b.minY) && (a.maxY <= b.maxY)) ? true : false;
            }
            else
            {
                return false;
            }
        }
        
        public static ListOperations AddIntoRectangle(Rectangle old, Rectangle add)
        {
            ListOperations aList = new ListOperations();
            if(subset(old,add))
            {
                aList.Add(add);
                return aList;
            }
            if(subset(add, old))
            {
                aList.Add(old);
                return aList;
            }

            int oldMinX = old.getCoord()[0];
            int oldMaxX = old.getCoord()[1];
            int oldMinY = old.getCoord()[2];
            int oldMaxY = old.getCoord()[3];

            int addMinX = add.getCoord()[0];
            int addMaxX = add.getCoord()[1];
            int addMinY = add.getCoord()[2];
            int addMaxY = add.getCoord()[3];

            if ((oldMinX <addMinX) &&  (addMaxX < oldMaxX))
            {
                Rectangle lower = new Rectangle(addMinX, addMaxX, oldMinY, addMinY);
                Rectangle upper = new Rectangle(addMinX, addMaxX, oldMaxY, addMaxY);
                aList.validAdd
                
            }

        }
        public static bool Equals(Rectangle a, Rectangle b)
        {
            if (!(a.getCoord().SequenceEqual(b.getCoord())))
            {
                return false;
            }
            return (a.invalid == b.invalid) ? true : false;
        }
        public void printRectangle()
        {
            Console.WriteLine(this.minX.ToString() + this.maxY.ToString() + " ----- " + this.maxX.ToString() + this.minY.ToString());
            Console.WriteLine(this.minX.ToString() + this.minY.ToString() + " ----- " + this.maxX.ToString() + this.maxY.ToString());
            Console.WriteLine("[" + this.minX.ToString() + "," + this.maxX.ToString() + "]" + "x" + "[" + this.minY.ToString() + "," + this.maxY.ToString() + "]");
            Console.WriteLine(this.invalid);
            Console.ReadKey();
        }
    }
}
