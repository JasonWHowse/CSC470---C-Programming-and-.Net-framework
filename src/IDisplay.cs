namespace Prj3_F18_.src {
    public interface IDisplay {
        bool IsOn { get; }
        public void DisplayOperand(string operand);
        void DisplayAnswer(decimal solution);
        void DisplayClear();
        void DisplayError();
        void DisplayOff();
        bool DisplayOn();
    }//public interface IDisplay {
}//namespace Prj3_F18_.src {