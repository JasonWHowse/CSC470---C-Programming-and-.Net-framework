using Prj3_F18_.src;
using System.Windows;
using System.Windows.Controls;

namespace Prj3_F18_ {
    public partial class MainWindow : Window {
        private readonly Interface inter;
        private readonly Display display;
        public MainWindow() {
            this.InitializeComponent();
            this.display = new Display(this.Display);
            this.inter = new Interface(this.display);
            this.inter.SetCalculatorOff();
        }//public MainWindow() {

        private void Button_Click_On(object sender, RoutedEventArgs e) {
            this.inter.SetCalculatorOn();
        }//private void Button_Click_On(object sender, RoutedEventArgs e) {

        private void Button_Click_Off(object sender, RoutedEventArgs e) {
            this.inter.SetCalculatorOff();
        }//private void Button_Click_Off(object sender, RoutedEventArgs e) {

        private void Button_Click_C(object sender, RoutedEventArgs e) {
            if (this.display.IsOn) {
                this.inter.ClearSolution();
            }//if (this.display.DisplayIsOn()) {
        }//private void Button_Click_C(object sender, RoutedEventArgs e) {

        private void Button_Click_Operator(object sender, RoutedEventArgs e) {
            if (this.display.IsOn) {
                this.inter.SetOperator(((Button)sender).Content.ToString());
            }//if (this.display.DisplayIsOn()) {
        }//private void Button_Click_Operator(object sender, RoutedEventArgs e) {

        private void Button_Click_Operand(object sender, RoutedEventArgs e) {
            if (this.display.IsOn) {
                this.inter.SetOperand(((Button)sender).Content.ToString());
            }//if (this.display.DisplayIsOn()) {
        }//private void Button_Click_Operand(object sender, RoutedEventArgs e) {
    }//public partial class MainWindow : Window {
}//namespace Prj3_F18_ {