using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6.src {
    public class Package {
        public static HashSet<long> PackageIDList = new HashSet<long>();
        public DateTime Dt { get; set; }
        public long PackageID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public Package(DateTime dt, long packageID, string address, string city, string state, string zip) {
            this.Dt = dt;
            this.PackageID = packageID;
            _ = PackageIDList.Add(packageID);
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }//public Package(DateTime dt, long packageID, string address, string city, string state, string zip) {

        override
        public string ToString() {
            return this.PackageID.ToString();
        }//public string ToString() {

        override
        public bool Equals(object input) {
            return input is Package @package ? this.PackageID == @package.PackageID : input is string @string && this.PackageID == long.Parse(@string);
        }//public bool Equals(object input) {

        override
        public int GetHashCode() {
            return base.GetHashCode();
        }//public int GetHashCode() {
    }//class Package {
}//namespace Lab6.src {