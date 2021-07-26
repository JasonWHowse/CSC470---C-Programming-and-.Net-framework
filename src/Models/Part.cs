namespace Project4.src.Models {
    class Part {
        public string PN { get; set; }
        public string PName { get; set; }
        public string Color { get; set; }
        public short Weight { get; set; }
        public string City { get; set; }

        override
        public string ToString() => "P#: " + this.PN + ", Part Name: " + this.PName + ", Color:" + this.Color + ", Weight: " + this.Weight + ", City:" + this.City;
    }//class Part {
}//namespace Project4.src.Models {