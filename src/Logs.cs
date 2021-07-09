using System.Collections.Generic;

namespace Lab5.src {
    public class Logs : List<LogEntry> {
        public void Add(string input) {
            this.Add(new LogEntry(input));
        }//public void Add(string input) {

        override
        public string ToString() {
            string output = "";
            foreach (LogEntry log in this) {
                output = log.ToString() + "\r\n" + output;
            }//foreach (LogEntry log in this) {
            return output;
        }//public string ToString() {
    }//public class Logs : List<LogEntry> {
}//namespace Lab5.src {