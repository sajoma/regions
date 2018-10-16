﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenster
{

    public class Programm
    {
        public static void Main(string[] args)
        {
            Background background = new Background(0, 10, 0, 10);
            List<Rectangle> In = new List<Rectangle>();
            Rectangle newRect1 = new Rectangle(0, 2, 0, 2);
            Rectangle newRect2 = new Rectangle(1, 3, 1, 3);

 
            Window w = new Window(background, In);
            w.AddOr(newRect1);
            w.AddOr(newRect2);

            //Check case1 of possible insertions: the  rectangle is outside of the old list:
            Rectangle newRect3 = new Rectangle(4,5,4,5);
            w.AddOr(newRect3);

            //Check case2 of possible insertions
            Rectangle newRect4 = new Rectangle(2, 3, 2, 3);
            w.AddOr(newRect4);

            //Check case3 of possible insertions: there is a non-emptyintersection with IN
            Rectangle newRect5 = new Rectangle(2, 5, 2, 4);
            w.AddOr(newRect5);
            w.printWindow();

            //Test: Rectangle der Konstruktor. Alle Tests O.k.
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


            // List<Rectangle> c = new List<Rectangle> (new Rectangle[] { a });

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
            //List<Rectangle> c = new List<Rectangle>(new Rectangle[] { b });
            //a.resize(c);
            //a.printRectangle();

        }
    }
}