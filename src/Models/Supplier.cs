namespace Project4.src.Models {
    class Supplier {
        public string SN { get; set; }
        public string SName { get; set; }
        public int Status { get; set; }
        public string City { get; set; }

        override
        public string ToString() => "S#: " + this.SN + ", SName: " + this.SName + ", Status: " + this.Status + ", City: " + this.City;
    }//class Supplier {
}//namespace Project4.src.Models {