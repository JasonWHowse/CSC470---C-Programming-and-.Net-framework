using Lab5.src;
using System.Windows;
using System.Windows.Controls;

namespace Lab5 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly Logs logs = new Logs();
        public MainWindow() {
            this.InitializeComponent();
        }//public MainWindow() {

        private void Button_Click(object sender, RoutedEventArgs e) {
            string keyPress = ((Button)sender).Content.ToString();
            switch (keyPress) {
                case "C":
                    this.CodeName.Password = "";
                    break;
                case "#":
                    if (this.CodeName.Password.Length > 0) {
                        this.logs.Add(this.CodeName.Password);
                        this.CodeName.Password = "";
                        this.Log.Text = this.logs.ToString().Trim();
                        if (this.logs.Count == 6) {
                            this.Log.Padding = new Thickness(10.0, 0.0, 0.0, 0.0);
                        }//if (this.logs.Count == 6) {
                    }//if (this.CodeName.ToString().Length > 0) {
                    break;
                default:
                    this.CodeName.Password += keyPress;
                    break;
            }//switch (keyPress) {
        }//private void Button_Click(object sender, RoutedEventArgs e) {
    }//public partial class MainWindow : Window {
}//namespace Lab5 {