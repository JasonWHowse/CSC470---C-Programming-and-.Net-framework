using System;

namespace Project1 {
    class Calculator {
        private double operand1 = 0;
        private double operand2 = 0;
        private char operate = '1';
        private bool continuing = true;
        private readonly string operandEnterString;
        private readonly string operatorEnterString;
        private readonly string operandErrorString;
        private readonly string operand2ErrorString;
        private readonly string operatorErrorString;
        private readonly char quitChar;

        public Calculator() {
            operandEnterString = "Please input a number value:";
            operatorEnterString = "Please input an operator:";
            operandErrorString = "Input must be a number value!";
            operand2ErrorString = "Input can not be 0 while operator is /!";
            operatorErrorString = "Input value must be a valid operator +, -, *, or /!";
            quitChar = 'q';
        }//public Calculator() {

        public Calculator(string operandEnterString, string operatorEnterString, string operandErrorString, string operand2ErrorString, string operatorErrorString, char quitChar) {
            this.operandEnterString = operandEnterString;
            this.operatorEnterString = operatorEnterString;
            this.operandErrorString = operandErrorString;
            this.operand2ErrorString = operand2ErrorString;
            this.operatorErrorString = operatorErrorString;
            this.quitChar = quitChar;
        }//public Calculator(string operandEnterString, string operatorEnterString, string operandErrorString, string operand2ErrorString, string operatorErrorString, char quitChar) { 

        public char GetQuitChar() {
            return quitChar;
        }//public string GetQuitString() {

        public bool GetContinuing() {
            return continuing;
        }//public bool GetContinuing() {

        public void FlipContinuing() {
            continuing = !continuing;
        }//public void SetContinuing() {

        public void SetOperand1() {
            Console.WriteLine(operandEnterString);
            string operand1Str = Console.ReadLine().Trim();
            if (!double.TryParse(operand1Str, out operand1)) {
                Console.WriteLine(operandErrorString);
                SetOperand1();
            }//if (!double.TryParse(operand1Str, out operand1)) {
        }//public void setOperand1() {

        public void SetOperator() {
            Console.WriteLine(operatorEnterString);
            operate = Console.ReadKey().KeyChar;
            Console.WriteLine((int)operate);
            if (!"*/-+".Contains(operate)) {
                Console.WriteLine(operatorErrorString);
                SetOperator();
            }//if (!"*/-+".Contains(operate)) {
        }//public void SetOperator() {

        public void SetOperand2() {
            Console.WriteLine(operandEnterString);
            string operand2Str = Console.ReadLine().Trim();
            if (!double.TryParse(operand2Str, out operand2)) {
                Console.WriteLine(operandErrorString);
                SetOperand2();
            } else if (operate == '/' && operand2 == 0) {//if (!double.TryParse(operand2Str, out operand2)) {
                Console.WriteLine(operand2ErrorString);
                SetOperand2();
            }//} else if (operate == '/' && operand2 == 0)
        }//public void SetOperand2() {

        override
        public string ToString() {
            return "" + operand1 + " " + operate + " " + operand2 + " = " + (operate == '/' ? operand1 / operand2 : operate == '+' ? operand1 + operand2 : operate == '-' ? operand1 - operand2 : operand1 * operand2);
        }//public string ToString() {
    }//class Calculator {
}//namespace Project1 {