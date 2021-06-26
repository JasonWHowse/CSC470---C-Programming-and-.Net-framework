using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    class Program {
        static void doWork() {
            Point origin = new Point();
            Point bottomRight = new Point(1366, 768);
            double distance = origin.DistanceTo(bottomRight);
            Console.WriteLine($"Distance is: {distance}"); 
            (int xVal, int yVal) = origin;
            Console.WriteLine($"Number of Point objects: {Point.ObjectCount()}");

            Line testLine = new Line(origin, bottomRight);
            Console.WriteLine("Line length is: " + testLine.GetLength());
        }//static void doWork() {

        static void Main(string[] args) {
            try {
                doWork();
            } catch (Exception ex) {//try {
                Console.WriteLine(ex.Message);
            }//catch (Exception ex) {
            Console.ReadKey();
        }//static void Main(string[] args) {
    }//class Program {
}//namespace Classes {