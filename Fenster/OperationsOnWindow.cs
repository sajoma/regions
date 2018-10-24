using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenster
{
    public static class OperationsOnWindow
    {
        public static Window AddAnd(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                old.AddAnd(rect);
            }
            return catchEmpty(old,add);
        }

        public static Window AddOr(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                old.AddOr(rect);
            }
            return catchEmpty(old, add);
        }

        public static Window AddXOR(Window old, Window add)
        {
            List<Rectangle> addList = add.getIn();
            foreach (Rectangle rect in addList)
            {
                old.AddXOR(rect);
            }
            return catchEmpty(old, add);
        }

        private static Window catchEmpty(Window old, Window and)
        {
            if(and.getIn().Count() == 0)
            {
                old = new Window();
            }
            return old;
        }
    }
}
