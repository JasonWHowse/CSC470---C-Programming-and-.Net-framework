
using System.Windows;

namespace Lab2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }//public MainWindow() {

        private void TheButton(object sender, RoutedEventArgs e) {
            this.TheLabel.Content = this.TheTextBox.Text;
        }//private void TheButton(object sender, RoutedEventArgs e) {
    }//public partial class MainWindow : Window {
}//namespace Lab2 {