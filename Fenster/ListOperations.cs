using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenster
{   
    //Diese Klasse verfügt über Funktionen für das In Array
    public class ListOperations : List<Rectangle>
    {
        
        public static bool intersectionWithList(ListOperations rectList, Rectangle intersectWith)
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
        
        public ListOperations validAdd(Rectangle add)
        {
            if (!add.getInvalid())
            {
                this.Add(add);
            }
            return this;
        }
        //See how index can be simplified with other rectangles
        public ListOperations simplifyByX(ListOperations List, int index)
        {
            for (int i = List.Count() - 1; i >= 0; i--)
            {
                if (i!= index)
                {
                    if ((List[i].getCoord()[0] == List[index].getCoord()[0]) && (List[i].getCoord()[1] == List[index].getCoord()[1]))
                    {
                        if (intersectionWithList(List, List[index]) && i != index)
                        {
                            int minX = List[i].getCoord()[0];
                            int maxX = List[i].getCoord()[1];

                            int minYList = List[i].getCoord()[2];
                            int minYIndex = List[index].getCoord()[2];
                            int minY = Math.Min(minYList, minYIndex);

                            int maxYList = List[i].getCoord()[3];
                            int maxYIndex = List[index].getCoord()[3];
                            int maxY = Math.Max(maxYList, maxYIndex);

                            Rectangle simplified = new Rectangle(minX, maxX, minY, maxY);

                            if (i > index)
                            {
                                List.RemoveAt(i);
                                List.RemoveAt(index);
                            }
                            else
                            {
                                List.RemoveAt(index);
                                List.RemoveAt(i);
                            }

                            List.Insert(Math.Max(0, List.Count()), simplified);
                            index = Math.Max(0, List.Count() - 1);
                        }
                    }
                }
               
            }

            return List;
        }
    }
}
