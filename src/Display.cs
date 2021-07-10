using System.Windows.Controls;
using System.Windows.Media;

namespace Prj3_F18_.src {
    public class Display : IDisplay {
        public bool IsOn { get; private set; }
        private string Error { get; set; }
        private readonly ContentControl display;
        public Display(ContentControl display) {
            this.display = display;
            this.IsOn = false;
            this.Error = "Error";
        }//public Display(ContentControl display) {

        public Display(ContentControl display, string errorMsg) {
            this.display = display;
            this.IsOn = false;
            this.Error = errorMsg;
        }//public Display(ContentControl display, string errorMsg) {

        public void DisplayAnswer(decimal solution) {
            this.display.Content = solution;
        }//public void DisplayAnswer(decimal solution) {

        public void DisplayClear() {
            this.display.Content = "";
        }//public void DisplayClear() {

        public void DisplayError() {
            this.display.Content = this.Error;
        }//public void DisplayError() {

        public void DisplayOff() {
            this.display.Background = new SolidColorBrush(Color.FromRgb(8, 18, 12));
            this.IsOn = false;
        }//public void DisplayOff() {

        public bool DisplayOn() {
            if (this.IsOn) {
                return true;
            }//if (this.IsOn) {
            this.display.Background = new SolidColorBrush(Color.FromRgb(16, 36, 25));
            return !(this.IsOn = true);
        }//public bool DisplayOn() {

        public void DisplayOperand(string operand) {
            this.display.Content = operand;
        }//public void DisplayOperand(string operand) {
    }//public class Display : IDisplay {
}//namespace Prj3_F18_.src {