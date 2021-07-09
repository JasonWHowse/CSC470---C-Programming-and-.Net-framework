using System.Windows.Controls;
using System.Windows.Media;

namespace Prj3_F18_.src {
    public class Display : IDisplay {
        private bool isOn = false;
        private readonly ContentControl display = null;
        private readonly string error = "Error";
        public Display(ContentControl display) {
            this.display = display;
        }//public Display(ContentControl display) {

        public Display(ContentControl display, string errorMsg) {
            this.display = display;
            this.error = errorMsg;
        }//public Display(ContentControl display, string errorMsg) {

        public void DisplayAnswer(decimal solution) {
            this.display.Content = solution;
        }//public void DisplayAnswer(decimal solution) {

        public void DisplayClear() {
            this.display.Content = "";
        }//public void DisplayClear() {

        public void DisplayError() {
            this.display.Content = this.error;
        }//public void DisplayError() {

        public bool DisplayIsOn() {
            return this.isOn;
        }//public bool DisplayIsOn() {

        public void DisplayOff() {
            this.display.Background = new SolidColorBrush(Color.FromRgb(8, 18, 12));
            this.isOn = false;
        }//public void DisplayOff() {

        public bool DisplayOn() {
            if (this.isOn) {
                return true;
            }//if (this.isOn) {
            this.display.Background = new SolidColorBrush(Color.FromRgb(16, 36, 25));
            return !(this.isOn = true);
        }//public bool DisplayOn() {

        public void DisplayOperand(string operand) {
            this.display.Content = operand;
        }//public void DisplayOperand(string operand) {
    }//public class Display : IDisplay {
}//namespace Prj3_F18_.src {