using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenster
{
    public static class OperationsOnRegion
    {
        public static Window AndRectRegion(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                cancelOffset(rect, old, add);
                old.AndRectRegion(rect);
            }
            return catchEmpty(old,add);
        }

        public static Window OrRectRegion(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                cancelOffset(rect, old, add);
                old.OrRectRegion(rect);
            }
            return old;
        }

        public static Window XorRectRegion(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                cancelOffset(rect, old, add);
                old.XorRectRegion(rect);
            }
            return old;
        }

        private static Window catchEmpty(Window old, Window and)
        {
            if(and.getIn().Count() == 0)
            {
                old = new Window();
            }
            return old;
        }

        private static void cancelOffset(Rectangle rect, Window old, Window add)
        {
            rect.translateRectangle(add.getOffset(true) - old.getOffset(true), add.getOffset(false) - old.getOffset(false));
        }
    }
}
