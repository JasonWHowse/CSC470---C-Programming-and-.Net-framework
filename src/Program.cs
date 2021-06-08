using System;

namespace Project1 {
    class Program {
        static void Main() {
            Calculator calculator = new Calculator();
            while (calculator.GetContinuing()) {
                calculator.SetOperand1();
                calculator.SetOperator();
                calculator.SetOperand2();
                Console.WriteLine(calculator + "\n\n================================================\n\nPress "+calculator.GetQuitChar()+" to quit or any other key to continue");
                if (calculator.GetQuitChar() == Console.ReadKey().KeyChar) {
                    calculator.FlipContinuing();
                }//if (calculator.GetQuitChar() == Console.ReadKey().KeyChar) {
                Console.Clear();
            }//while (calculator.GetContinuing()) {
        }//static void Main(string[] args) {
    }//class Program {
}//namespace Project1 {