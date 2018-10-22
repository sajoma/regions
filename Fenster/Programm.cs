using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fenster;



    public class Programm
    {
        public static void Main(string[] args)
        {
            Rectangle newRect1 = new Rectangle(0, 2, 0, 2);
            Rectangle newRect2 = new Rectangle(1, 3, 1, 3);


            Window w = new Window();
            w.AddOr(newRect1);
            w.AddOr(newRect2);
            

        //Check case1 of possible insertions: the  rectangle is outside of the old list:
            Rectangle newRect3 = new Rectangle(4, 5, 4, 5);
            w.AddOr(newRect3);

            //Check case2 of possible insertions
            Rectangle newRect4 = new Rectangle(2, 3, 2, 3);
            w.AddOr(newRect4);

            //Check case3 of possible insertions: there is a non-emptyintersection with IN
            Rectangle newRect5 = new Rectangle(2, 5, 2, 4);
            w.AddOr(newRect5);

            Rectangle newRect6 = new Rectangle(0, 0, 0, 8);
            w.AddOr(newRect6);

            Rectangle newRect7 = new Rectangle(0, 0, 7, 10);
            w.AddOr(newRect7);

            Rectangle newRect8 = new Rectangle(3, 3, 0, 1);
            w.AddOr(newRect8);

            w.AddAnd(newRect4);

            w.AddXOR(newRect8);

            w.AddXOR(newRect1);

            w.AddOr(newRect1);

            w.AddOr(newRect2);

            w.AddXOR(newRect5);

            w.AddOr(newRect7);

            Rectangle newRect9 = new Rectangle(-2, 2, 1, 8);

            w.AddXOR(newRect9);
            w.printDebugWindow();
            w.printWindow();


        // Teste Funktion: Add Into Rectangle: Hier ohne Windows und resize() und Background
        //Rectangle basis = new Rectangle(0, 4, 0, 4);

            // All ways Rectangle can hit:
            //Rectangle a1 = new Rectangle(-10, 10, -10, 10);
            //Rectangle a2 = new Rectangle(10, 10, 10, 10);
            //Rectangle a3 = new Rectangle(-2, 1, -1, 5);
            //Rectangle a4 = new Rectangle(1, 3, 3, 5);
            //Rectangle a5 = new Rectangle(2, 5, 1, 3);
            //Rectangle a6 = new Rectangle(1, 3, -10, 2);
            //Rectangle a7 = new Rectangle(-1, 1, 2, 3);
            //Rectangle a8 = new Rectangle(-1, 5, 3, 5);
            //Rectangle a9 = new Rectangle(3, 5, -1, 5);
            //Rectangle a10 = new Rectangle(-5, 5, 0, 1);
            //Rectangle a11 = new Rectangle(-1, 5, -4, 2);

            //ListOperations aList = Rectangle.AddIntoRectangle(basis, a11); // Auch andersrum testen

            ////Test: Rectangle der Konstruktor. Alle Tests O.k.
            //Rectangle a = new Rectangle(0, 0, 0, -1);
            //a.printRectangle();

            //Test: Rectangle getCoord(). Alle Test O.k.
            //Rectangle a = new Rectangle(0, 1, 2, 3);
            //List<int> b = a.getCoord();
            //foreach(int i in b)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.ReadKey();

            // Test Rectangle getInvalid. Alle Tests O.k.
            //Rectangle a = new Rectangle(0, 1, 2, 3);
            //Rectangle b = new Rectangle(0, 1, 2, 0);
            //Console.WriteLine(a.getInvalid().ToString() + b.getInvalid().ToString());
            //Console.ReadKey();

            //Test: Rectangle Intersection. Alle tests O.k.
            //Rectangle a = new Rectangle(0, 4, 0, 4);

            //Rectangle i1 = new Rectangle(-1, 0, -2, 0); 
            //Rectangle i2 = new Rectangle(-1, 1, -1, 1);
            //Rectangle i3 = new Rectangle(2, 3, -1, 0);
            //Rectangle i4 = new Rectangle(3, 5, -1, 3);
            //Rectangle i5 = new Rectangle(4,5,-1,0);
            //Rectangle i6 = new Rectangle(-1,0,2,3);
            //Rectangle i7 = new Rectangle(2,3,2,3);
            //Rectangle i8 = new Rectangle(4,5,2,3);
            //Rectangle i9 = new Rectangle(-1,0,4,5);
            //Rectangle i10 = new Rectangle(2, 5, 3, 6);
            //Rectangle i11 = new Rectangle(5, 6, 7, 8);

            //Rectangle.intersection(a, i11).printRectangle();


            // ListOperations c = new ListOperations (new Rectangle[] { a });

            // Test: Rectangle Subset Alle Tests O.k.
            //Rectangle a = new Rectangle(0, 1, 0, 1);
            //Rectangle b = new Rectangle(0, 0, 0, 0);
            //Console.WriteLine(Rectangle.subset(b, a));
            //Console.ReadKey();

            //Test Rectangle Equals . Alle Tests O.k.
            //Rectangle a = new Rectangle(0, 1, 0, 1);
            //Rectangle b = new Rectangle(0, 1, 0, 1);
            //Console.WriteLine(Rectangle.Equals(a, b));
            //Console.ReadKey();

            // Test Background Konstruktor. Allet Tests O.k.
            //Background a = new Background(0, 1, 0, 2);
            //Rectangle b = new Rectangle(-1, 3, 0, 1);
            //ListOperations c = new ListOperations(new Rectangle[] { b });
            //a.resize(c);
            //a.printRectangle();

        }
    }
