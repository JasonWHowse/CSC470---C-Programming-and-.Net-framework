using System;

namespace Lab5.src {
    public class LogEntry {
        private readonly string group;
        private readonly DateTime dateTime;

        public LogEntry(string group) {
            group = group.Length == 1 ? "0" : group;
            this.dateTime = DateTime.Now;
            switch (group) {
                case "1645":
                case "1689": //Technicians
                    this.group = "Technicians";
                    break;
                case "8345": //Custodians
                    this.group = "Custodians";
                    break;
                case "9998":
                case "1006":
                case "1007":
                case "1008": //Scientists
                    this.group = "Scientists";
                    break;
                case "0":
                    this.group = "Restricted Access";
                    break;
                default:
                    this.group = "Access Denied";
                    break;
            }//switch (group) {
        }//public LogEntry(string group) {

        override
        public string ToString() {
            return this.dateTime + " " + this.group;
        }//public string ToString() {
    }//public class LogEntry {
}//namespace Lab5.src {