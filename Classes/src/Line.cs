namespace Classes {
    class Line {
        private Point point1;
        private Point point2;

        public Line(Point point1, Point point2) {
            this.point1 = point1;
            this.point2 = point2;
        }//public Line(Point point1, Point point2) {

        public Line(int p1x, int p1y, int p2x, int p2y) {
            this.point1 = new Point(p1x, p1y);
            this.point2 = new Point(p2x, p2y);
        }//public Line(int p1x, int p1y, int p2x, int p2y) {

        public double GetLength() {
            return point1.DistanceTo(point2);
        }//public double GetLength() {
    }//class Line {
}//namespace Classes {