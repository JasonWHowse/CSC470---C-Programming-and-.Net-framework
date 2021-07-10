using System;

namespace Prj3_F18_.src {
    public class Interface : IButtons {

        private readonly Engine engine;
        private readonly Display display;

        public Interface(Display display) {
            this.display = display;
            this.engine = new Engine();
        }//public Interface(Display display) {

        public void ClearSolution() {
            this.engine.ClearAll();
            this.display.DisplayClear();
        }//public void ClearSolution() {

        public void SetCalculatorOff() {
            this.ClearSolution();
            this.display.DisplayOff();
        }//public void SetCalculatorOff() {

        public void SetCalculatorOn() {
            if (this.display.DisplayOn()) {
                this.display.DisplayError();
            }//if (this.display.DisplayOn()) {
        }//public void SetCalculatorOn() {

        public void SetOperand(string input) {
            if (this.engine.SetOperand(input) && !this.engine.End) {
                this.display.DisplayOperand(input);
            } else {//if (this.engine.SetOperand(input) && !this.engine.End) {
                this.display.DisplayError();
            }//else {
        }//public void SetOperand(string input) {

        public void SetOperator(string input) {
            if (this.engine.SetOperator(input) && !this.engine.End) {
                this.display.DisplayClear();
            } else if (input.Equals("=") && !this.engine.End && this.engine.IsReadyForSolution()) {//if (this.engine.SetOperator(input) && !this.engine.End) {
                this.SetSolution();
            } else {//else if (input.Equals("=") && !this.engine.End && this.engine.IsReadyForSolution()) {
                this.display.DisplayError();
            }//else {
        }//public void SetOperator(string input) {

        public void SetSolution() {
            try {
                this.display.DisplayAnswer(this.engine.SetSolution());
            } catch (DivideByZeroException) {//try {
                this.display.DisplayError();
            }//catch (DivideByZeroException) {
        }//public void SetSolution() {
    }//public class Interface : IButtons {
}//namespace Prj3_F18_.src {