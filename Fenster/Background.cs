using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenster
{
    public class Background : Rectangle
    {
        public Background(int minX, int maxX, int minY, int maxY) :base(minX, maxX, minY, maxY)
        {}
        public void RegionRect(ListOperations In)
        {
            if (In.Count != 0)
            {
                // Our regionRectangle must at least be as big as that
                this.minX = In[0].getCoord()[0];
                this.maxX = In[0].getCoord()[1];
                this.minY = In[0].getCoord()[2];
                this.maxY = In[0].getCoord()[3];

                foreach (Rectangle item in In)
                {
                    //minX
                    if (item.getCoord()[0] < this.minX)
                    {
                        this.minX = item.getCoord()[0];
                    }
                    // maxX
                    if (item.getCoord()[1] > this.maxX)
                    {
                        this.maxX = item.getCoord()[1];
                    }
                    // minY
                    if (item.getCoord()[2] < this.minY)
                    {
                        this.minY = item.getCoord()[2];
                    }
                    // maxY
                    if (item.getCoord()[3] > this.maxY)
                    {
                        this.maxY = item.getCoord()[3];
                    }
                }
            }
            else
            {
                this.minX = 0;
                this.maxX = 0;
                this.minY = 0;
                this.maxY = 0;
            }
            
        }


    }
}
