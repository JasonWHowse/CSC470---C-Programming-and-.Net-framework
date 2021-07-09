namespace Prj3_F18_.src {
    public class Engine {
        private decimal solution;
        private int? firstOperand = null;
        private int? secondOperand = null;
        private string _operator = null;
        private bool end = false;

        public Engine() { }

        public void ClearAll() {
            this.firstOperand = null;
            this.secondOperand = null;
            this._operator = null;
            this.end = false;
        }//public void ClearAll() {

        public bool SetOperand(string input) {
            if (this.firstOperand != null && this.secondOperand == null && this._operator != null) {
                _ = int.TryParse(input, out int secondOperand);
                this.secondOperand = secondOperand;
            } else if (this.firstOperand == null) {//if (this.firstOperand != null && this.secondOperand == null && this._operator != null) {
                _ = int.TryParse(input, out int firstOperand);
                this.firstOperand = firstOperand;
            } else {//else if (this.firstOperand == null) {
                return false;
            }//else {
            return true;
        }//public bool SetOperand(string input) {

        public bool SetOperator(string input) {
            if (this.firstOperand != null && this.secondOperand == null && this._operator == null && !input.Equals("=")) {
                this._operator = input;
                return true;
            } else {//if (this.firstOperand != null && this.secondOperand == null && this._operator == null && !input.Equals("=")) {
                return false;
            }//else {
        }//public bool SetOperator(string input) {

        public decimal SetSolution() {
            switch (this._operator) {
                case "*":
                    this.solution = (decimal)this.firstOperand * (decimal)this.secondOperand;
                    break;
                case "+":
                    this.solution = (decimal)this.firstOperand + (decimal)this.secondOperand;
                    break;
                case "-":
                    this.solution = (decimal)this.firstOperand - (decimal)this.secondOperand;
                    break;
                case "/":
                    this.solution = (decimal)this.firstOperand / (decimal)this.secondOperand;
                    break;
                default:
                    break;
            }//switch (this._operator) {
            this.end = true;
            return this.solution;
        }//public decimal SetSolution() {

        public bool IsEnd() {
            return this.end;
        }//public bool IsEnd() {

        public bool IsReadyForSolution() {
            return this.secondOperand != null;
        }//public bool IsReadyForSolution() {
    }//public class Engine {
}//namespace Prj3_F18_.src {