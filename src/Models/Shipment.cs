namespace Project4.src.Models {
    class Shipment {
        public string SN { get; set; }
        public string PN { get; set; }
        public int QTY { get; set; }

        override
        public string ToString() => "S#: " + this.SN + ", P#: " + this.PN + ", QTY: " + this.QTY;
    }//class Shipment {
}//namespace Project4.src.Models {