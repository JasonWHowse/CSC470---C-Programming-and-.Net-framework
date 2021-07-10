using System;

namespace Lab5.src {
    public class LogEntry {
        private string Group { get; set; }
        private DateTime DateTime { get; set; }

        public LogEntry(string group) {
            group = group.Length == 1 ? "0" : group;
            this.DateTime = DateTime.Now;
            switch (group) {
                case "1645":
                case "1689": //Technicians
                    this.Group = "Technicians";
                    break;
                case "8345": //Custodians
                    this.Group = "Custodians";
                    break;
                case "9998":
                case "1006":
                case "1007":
                case "1008": //Scientists
                    this.Group = "Scientists";
                    break;
                case "0":
                    this.Group = "Restricted Access";
                    break;
                default:
                    this.Group = "Access Denied";
                    break;
            }//switch (group) {
        }//public LogEntry(string group) {

        override
        public string ToString() {
            return this.DateTime + " " + this.Group;
        }//public string ToString() {
    }//public class LogEntry {
}//namespace Lab5.src {