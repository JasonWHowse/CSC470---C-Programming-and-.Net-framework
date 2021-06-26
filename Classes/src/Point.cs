#region Using directives

using System;

#endregion

namespace Classes {
    class Point {
        private int x, y; 
        private static int objectCount = 0;
        public Point() {
            this.x = -1;
            this.y = -1;
            objectCount++;
        }//public Point() {

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
            objectCount++;
        }//public Point(int x, int y) {

        public void Deconstruct(out int x, out int y) {
            x = this.x;
            y = this.y;
        }//public void Deconstruct(out int x, out int y) {

        public double DistanceTo(Point other) {
            int xDiff = this.x - other.x;
            int yDiff = this.y - other.y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            return distance;
        }//public double DistanceTo(Point other) {

        public static int ObjectCount() => objectCount;
    }//class Point {
}//namespace Classes {