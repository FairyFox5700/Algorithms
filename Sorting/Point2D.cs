using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sorting
{
    /// <summary>
    /// class for Convex hull 
    /// </summary>
    ///
    /// Choose point p with smallest y-coordinate.
    //・Sort points by polar angle with p.
    //・Consider points in order; discard unless it create a ccw turn.
    public class Point2D
    {
        public  double X { get; set; }
        public  double Y { get; set; }
        /*public  Comparer<Point2D> POLAR_ORDER = new PolarOrder();

        private class PolarOrder : Comparer<Point2D>
        {
            public override int Compare(Point2D firstPoint, Point2D seconPoint)
            {

                var dy1 = firstPoint.Y -this.Y;
                var dy2 = seconPoint.Y - Y;
                if (dy1 == 0 && dy2 == 0){} ;
                else if (dy1 >= 0 && dy2 < 0) return -1;// q1 above p; q2 below p
                else if (dy2 >= 0 && dy1 < 0) return +1;//q1 below p; q2 above p
                else return -ccw(this, firstPoint, seconPoint);//both above or below p
            
            }
        }*/
        public static int ccw(Point2D a, Point2D b, Point2D c)
        {
            var area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            if (area < 0) return -1;
            if (area > 0) return +1;
            return 0;
        }
    }
}