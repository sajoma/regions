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
        public static bool boolListIntersect(ListOperations list, Rectangle intersect)
        {
            for (int c = list.Count() - 1; c >= 0; c--)
            {
                if (!(Rectangle.intersection(list[c], intersect).getInvalid()))
                {
                    return true;
                }
            }
            return false;
        }
        
        //returns \cup_{rectangle in list}(rectanlge \cap intersect)
        public static ListOperations regionListIntersect(ListOperations rectList, Rectangle intersect)
        {
            ListOperations result = new ListOperations();
            foreach(Rectangle item in rectList)
            {
                result.Add(Rectangle.intersection(item, intersect));
                if (result[result.Count()-1].getInvalid())
                {
                    result.RemoveAt(result.Count() - 1);
                }
            }
            return result;
        }

        public ListOperations validAdd(Rectangle add, bool simplify)
        {
            if (!add.getInvalid())
            {
                this.Add(add);
            }
            if (simplify)
            {
                this.simplifyByX(this, Math.Max(0, this.Count() - 1));
                this.simplifyByY(this, Math.Max(0, this.Count() - 1));
            }

            return this;
        }
        //See how index can be simplified with other rectangles
        public ListOperations simplifyByY(ListOperations List, int index)
        {
            for (int i = List.Count() - 1; i >= 0; i--)
            {
                if (i != index)
                {
                    
                    if ((List[i].getCoord()[2] == List[index].getCoord()[2]) && (List[i].getCoord()[3] == List[index].getCoord()[3]))
                    {
                        if ((Math.Abs(List[i].getCoord()[0] - List[index].getCoord()[1]) == 1) || (Math.Abs(List[i].getCoord()[1] - List[index].getCoord()[0]) == 1))
                        {
                            int minY = List[i].getCoord()[2];
                            int maxY = List[i].getCoord()[3];

                            int minXList = List[i].getCoord()[0];
                            int minXIndex = List[index].getCoord()[0];
                            int minX = Math.Min(minXList, minXIndex);

                            int maxXList = List[i].getCoord()[1];
                            int maxXIndex = List[index].getCoord()[1];
                            int maxX = Math.Max(maxXList, maxXIndex);

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

        public ListOperations simplifyByX(ListOperations List, int index)
        {
            for (int i = List.Count() - 1; i >= 0; i--)
            {
                if (i!= index)
                {
                    if ((List[i].getCoord()[0] == List[index].getCoord()[0]) && (List[i].getCoord()[1] == List[index].getCoord()[1]))
                    {
                        if ((Math.Abs(List[i].getCoord()[2] - List[index].getCoord()[3]) == 1) || (Math.Abs(List[i].getCoord()[3] - List[index].getCoord()[2]) == 1))
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
