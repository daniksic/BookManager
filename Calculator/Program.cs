using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Using, and without modifying, the code below, write a console application which reads in two points and calculates the distance between them.
*/

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me first point");
            var firstInput = new 
            {
                X = double.Parse(Console.ReadLine()),
                Y = double.Parse(Console.ReadLine())
            };
            var first = new Point(firstInput.X, firstInput.Y);

            Console.WriteLine("Give me second point");
            var secondInput = new
            {
                X = double.Parse(Console.ReadLine()),
                Y = double.Parse(Console.ReadLine())
            };
            var second = new Point(secondInput.X, secondInput.Y);

            var calculator = new Distance(first, second);

            var distance = calculator.GetDistance((f, s) => {
                //formula: c2 = (xA − xB)2 + (yA − yB)2
                var a = Math.Pow((f.X - s.X), 2);
                var b = Math.Pow((f.Y - s.Y), 2);
                return Math.Sqrt(a + b);
            });

            Console.WriteLine(distance);
            Console.ReadLine();
        }
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(double xCoor, double yCoor)
        {
            X = xCoor;
            Y = yCoor;
        }
    }

    public sealed class Distance
    {
        private readonly Point _pointOne;
        private readonly Point _pointTwo;

        public Distance(Point pointOne, Point pointTwo)
        {
            _pointOne = pointOne;
            _pointTwo = pointTwo;
        }

        public double GetDistance(Func<Point, Point, double> distances)
        {
            return distances(_pointOne, _pointTwo);
        }
    }

}
