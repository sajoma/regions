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
        public ListOperations simplifyAddIn(ListOperations In, Rectangle newRectangle)
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
                // Case3, the last rectangle is outside of the old list. There is no simplification possible. Add the rectangle.
                In.Add(newRectangle);
                return In;
            }
        }
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
        public bool isSubsetOf(ListOperations In, Rectangle newRectangle)
        {
            //Zählt wie viele Punkte im Durchschnitt mit der Liste stehen
            int ctr = 0;

            List<int> Coord = newRectangle.getCoord();
            int minX = Coord[0];
            int maxX = Coord[1];
            int minY = Coord[2];
            int maxY = Coord[3];

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    Rectangle temp = new Rectangle(x, x, y, y);
                    foreach (Rectangle item in In)
                    {
                        if (Rectangle.subset(temp, item))
                        {
                            ctr++;
                            break;
                        }
                    }

                }
            }

            //Wenn alle Punkte auch in der Liste => return true sonst false
            return (ctr == (maxX - minX + 1) * (maxY - minY + 1)) ? true : false;

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
