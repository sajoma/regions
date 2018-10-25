using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fenster;
using System.Windows.Forms;
using System.Drawing;



public class Programm
    {
        public static void Main(string[] args)
        {
            Fenster.Rectangle newRect1 = new Fenster.Rectangle(0, 2, 0, 2);
            Fenster.Rectangle newRect2 = new Fenster.Rectangle(1, 3, 1, 3);
        
            Fenster.Window w = new Fenster.Window();

            w.OrRectRegion(newRect1);
            w.OrRectRegion(newRect2);

            //Check case1 of possible insertions: the  rectangle is outside of the old list:
            Fenster.Rectangle newRect3 = new Fenster.Rectangle(4, 5, 4, 5);
            w.OrRectRegion(newRect3);

            //Check case2 of possible insertions
            Fenster.Rectangle newRect4 = new Fenster.Rectangle(2, 3, 2, 3);
            w.OrRectRegion(newRect4);

            //Check case3 of possible insertions: there is a non-emptyintersection with IN
            Fenster.Rectangle newRect5 = new Fenster.Rectangle(2, 5, 2, 4);
            w.OrRectRegion(newRect5);

            Fenster.Rectangle newRect6 = new Fenster.Rectangle(0, 0, 0, 8);
            w.OrRectRegion(newRect6);


            Fenster.Rectangle newRect7 = new Fenster.Rectangle(0, 0, 7, 10);
            w.OrRectRegion(newRect7);

            Fenster.Rectangle newRect8 = new Fenster.Rectangle(3, 3, 0, 1);
            w.OrRectRegion(newRect8);

            w.AndRectRegion(newRect4);

            w.XorRectRegion(newRect8);

            w.XorRectRegion(newRect1);

             w.OrRectRegion(newRect1);

            w.OrRectRegion(newRect2);

            w.XorRectRegion(newRect5);


            w.OrRectRegion(newRect7);

            Fenster.Rectangle newRect9 = new Fenster.Rectangle(-2, 2, 1, 8);

            w.XorRectRegion(newRect9);

            PrintMedia.Print(w);
            // w.printDebugRegion();
            //w.printRegion();




        // Teste Funktion: Add Into Fenster.Rectangle: Hier ohne Regions und RegionRect() und RegionRectangle
        //Fenster.Rectangle basis = new Fenster.Rectangle(0, 4, 0, 4);

        // All ways Fenster.Rectangle can hit:
        //Fenster.Rectangle a1 = new Fenster.Rectangle(-10, 10, -10, 10);
        //Fenster.Rectangle a2 = new Fenster.Rectangle(10, 10, 10, 10);
        //Fenster.Rectangle a3 = new Fenster.Rectangle(-2, 1, -1, 5);
        //Fenster.Rectangle a4 = new Fenster.Rectangle(1, 3, 3, 5);
        //Fenster.Rectangle a5 = new Fenster.Rectangle(2, 5, 1, 3);
        //Fenster.Rectangle a6 = new Fenster.Rectangle(1, 3, -10, 2);
        //Fenster.Rectangle a7 = new Fenster.Rectangle(-1, 1, 2, 3);
        //Fenster.Rectangle a8 = new Fenster.Rectangle(-1, 5, 3, 5);
        //Fenster.Rectangle a9 = new Fenster.Rectangle(3, 5, -1, 5);
        //Fenster.Rectangle a10 = new Fenster.Rectangle(-5, 5, 0, 1);
        //Fenster.Rectangle a11 = new Fenster.Rectangle(-1, 5, -4, 2);

        //ListOperations aList = Fenster.Rectangle.AddIntoFenster.Rectangle(basis, a11); // Auch andersrum testen

        ////Test: Fenster.Rectangle der Konstruktor. Alle Tests O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 0, 0, -1);
        //a.printFenster.Rectangle();

        //Test: Fenster.Rectangle getCoord(). Alle Test O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 1, 2, 3);
        //List<int> b = a.getCoord();
        //foreach(int i in b)
        //{
        //    Console.WriteLine(i);
        //}
        //Console.ReadKey();

        // Test Fenster.Rectangle getInvalid. Alle Tests O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 1, 2, 3);
        //Fenster.Rectangle b = new Fenster.Rectangle(0, 1, 2, 0);
        //Console.WriteLine(a.getInvalid().ToString() + b.getInvalid().ToString());
        //Console.ReadKey();

        //Test: Fenster.Rectangle Intersection. Alle tests O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 4, 0, 4);

        //Fenster.Rectangle i1 = new Fenster.Rectangle(-1, 0, -2, 0); 
        //Fenster.Rectangle i2 = new Fenster.Rectangle(-1, 1, -1, 1);
        //Fenster.Rectangle i3 = new Fenster.Rectangle(2, 3, -1, 0);
        //Fenster.Rectangle i4 = new Fenster.Rectangle(3, 5, -1, 3);
        //Fenster.Rectangle i5 = new Fenster.Rectangle(4,5,-1,0);
        //Fenster.Rectangle i6 = new Fenster.Rectangle(-1,0,2,3);
        //Fenster.Rectangle i7 = new Fenster.Rectangle(2,3,2,3);
        //Fenster.Rectangle i8 = new Fenster.Rectangle(4,5,2,3);
        //Fenster.Rectangle i9 = new Fenster.Rectangle(-1,0,4,5);
        //Fenster.Rectangle i10 = new Fenster.Rectangle(2, 5, 3, 6);
        //Fenster.Rectangle i11 = new Fenster.Rectangle(5, 6, 7, 8);

        //Fenster.Rectangle.intersection(a, i11).printFenster.Rectangle();


        // ListOperations c = new ListOperations (new Fenster.Rectangle[] { a });

        // Test: Fenster.Rectangle Subset Alle Tests O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 1, 0, 1);
        //Fenster.Rectangle b = new Fenster.Rectangle(0, 0, 0, 0);
        //Console.WriteLine(Fenster.Rectangle.subset(b, a));
        //Console.ReadKey();

        //Test Fenster.Rectangle Equals . Alle Tests O.k.
        //Fenster.Rectangle a = new Fenster.Rectangle(0, 1, 0, 1);
        //Fenster.Rectangle b = new Fenster.Rectangle(0, 1, 0, 1);
        //Console.WriteLine(Fenster.Rectangle.Equals(a, b));
        //Console.ReadKey();

        // Test RegionRectangle Konstruktor. Allet Tests O.k.
        //RegionRectangle a = new RegionRectangle(0, 1, 0, 2);
        //Fenster.Rectangle b = new Fenster.Rectangle(-1, 3, 0, 1);
        //ListOperations c = new ListOperations(new Fenster.Rectangle[] { b });
        //a.RegionRect(c);
        //a.printFenster.Rectangle();

    }
    }
