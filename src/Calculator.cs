using System;
using System.Numerics;

namespace Project1 {
    class Calculator {
        private double operand1 = 0;
        private double operand2 = 0;
        private string operate = "";
        private bool continuing = true;
        private const string operandEnterString = "Please input a number value:";
        private const string operatorEnterString = "Please input an operator:";
        private const string operandErrorString = "Input must be a number value!";
        private const string operand2ErrorString = "Input can not be 0 while operator is /!";
        private const string operatorErrorString = "Input value must be a valid operator +, -, *, or /!";
        private const string quitString = "quit";
        public Calculator() { }

        public string GetQuitString() {
            return quitString;
        }//public string GetQuitString() {

        public bool GetContinuing() {
            return continuing;
        }//public bool GetContinuing() {

        public void SetOperand1() {
            Console.WriteLine(operandEnterString);
            string operand1Str = Console.ReadLine().Trim();
            while (!double.TryParse(operand1Str, out operand1)) {
                if (operand1Str.ToLower().Equals(quitString.ToLower())) {
                    continuing = false;
                    break;
                }//if (operand1Str.ToLower().Equals(quitString.ToLower())) {
                Console.WriteLine(operandErrorString);
                Console.WriteLine(operandEnterString);
                operand1Str = Console.ReadLine().Trim();
            }//while (!double.TryParse(operand1Str, out operand1)) {
        }//public void setOperand1() {

        public void SetOperator() {
            Console.WriteLine(operatorEnterString);
            operate = Console.ReadLine().Trim();
            while (!"*/-+".Contains(operate)||operate.Length!=1) {
                if (operate.ToLower().Equals(quitString.ToLower())) {
                    continuing = false;
                    break;
                }//if (operate.ToLower().Equals(quitString.ToLower())) {
                Console.WriteLine(operatorErrorString);
                Console.WriteLine(operatorEnterString);
                operate = Console.ReadLine().Trim();
            }//while (!"*/-+".Contains(operate)||operate.Length!=1) {
        }//public void SetOperator() {

        public void SetOperand2() {
            Console.WriteLine(operandEnterString);
            string operand2Str = Console.ReadLine().Trim();
            while (!double.TryParse(operand2Str, out operand2) || operate.Equals("/") && operand2 == 0) {
                if (operand2Str.ToLower().Equals(quitString.ToLower())) {
                    continuing = false;
                    break;
                }//if (operand2Str.ToLower().Equals(quitString.ToLower())) {
                if (operate.Equals("/") && operand2 == 0) {
                    Console.WriteLine(operand2ErrorString);
                } else {//if (operate.Equals("/") && operand2 == 0) {
                    Console.WriteLine(operandErrorString);
                }//else {
                Console.WriteLine(operandEnterString);
                operand2Str = Console.ReadLine().Trim();
            }//while (!double.TryParse(operand2Str, out operand2) || operate.Equals("/") && operand2 == 0) {
        }//public void SetOperand2() {

        override
        public string ToString() {
            return "" + operand1 + " " + operate + " " + operand2 + " = " + (operate.Equals("/") ? operand1 / operand2 : operate.Equals("+") ? operand1 + operand2 : operate.Equals("-") ? operand1 - operand2 : operand1 * operand2);
        }//public string ToString() {
    }//class Calculator {
}//namespace Project1 {