using System;

namespace Project1 {
    class Program {
        static void Main(string[] args) {
            Calculator calculator = new Calculator();
            while (calculator.GetContinuing()) {
                Console.WriteLine("Type " + calculator.GetQuitString() + " to quit at any times");
                calculator.SetOperand1();
                if (!calculator.GetContinuing()) {
                    break;
                }//if (!calculator.GetContinuing()) {
                calculator.SetOperator();
                if (!calculator.GetContinuing()) {
                    break;
                }//if (!calculator.GetContinuing()) {
                calculator.SetOperand2();
                if (!calculator.GetContinuing()) {
                    break;
                }//if (!calculator.GetContinuing()) {
                Console.WriteLine(calculator + "\n\n ================================================\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }//while (calculator.GetContinuing()) {
        }//static void Main(string[] args) {
    }//class Program {
}//namespace Project1 {