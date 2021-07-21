using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Lab6.src;
using src;
using static src.Toaster;

namespace Lab6 {
    public partial class MainWindow : Window {
        private readonly List<Package> packages = new List<Package>();
        private readonly List<string> states = new List<string>();
        private readonly Random randy = new Random();
        private List<Package> statePackage = new List<Package>();
        private int packageIndex = -1;
        private string lastZipTextBox = "";

        public MainWindow() {
            this.InitializeComponent();
            this.PopulateStates();
            this.StateComboBox.ItemsSource = this.states;
            this.StatePackageComboBox.ItemsSource = this.states;
            //this.PreLoadPackages('Z',short.MaxValue);//first var char limits the states generating packages by the first char in the abbreviation, the second var short creates that many packages per state
            this.SetInitialSettings();
        }//public MainWindow() {

        /*=============================Buttons======================================================*/

        private void AddButton_Click(object sender, RoutedEventArgs e) {
            if (this.AddIsValid()) {
                this.SetPackageInformation(false);
                this.DisableButtons();
                this.packages.Add(new Package(DateTime.Parse(this.ArrivedAtTextBox.Text), long.Parse(this.PackageIDTextBox.Text), this.AddressTextBox.Text, this.CityTextBox.Text, this.StateComboBox.SelectedItem.ToString(), this.ZipTextBox.Text));
                this.ClearPackageInformation();
            }//if (this.AddIsValid()) {
            this.GarbageCollection(75);
            this.SetNavButtons();
        }//private void AddButton_Click(object sender, RoutedEventArgs e) {

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            if (--this.packageIndex < 0) {
                this.packageIndex = this.packages.Count - 1;
            }//if (--this.packageIndex < 0) {
            this.StatePackageComboBox.SelectedItem = this.packages[this.packageIndex].State;
            this.DisplayPackage(this.packages[this.packageIndex]);
            this.SetPackageInformation(true);
            this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = true;
            this.GarbageCollection(75);
        }//private void BackButton_Click(object sender, RoutedEventArgs e) {

        private void EditButton_Click(object sender, RoutedEventArgs e) {
            if (this.AddIsValid()) {
                Package objRef = this.GetPackageByPID(this.PackageIDTextBox.Text);
                if (!objRef.State.Equals(this.StateComboBox.SelectedItem.ToString())) {
                    _ = this.statePackage.Remove(objRef);
                    objRef.State = this.StateComboBox.SelectedItem.ToString();
                    this.PackageListBox.ItemsSource = null;
                    this.PackageListBox.ItemsSource = this.statePackage;
                }//if (!objRef.State.Equals(this.StateComboBox.SelectedItem.ToString())) {
                objRef.Address = this.AddressTextBox.Text;
                objRef.City = this.CityTextBox.Text;
                objRef.Zip = this.ZipTextBox.Text;
                if (this.statePackage.Count == 0) {
                    this.StatePackageComboBox.SelectedIndex = -1;
                }//if (this.statePackage.Count == 0) {
                this.PackageListBox.SelectedIndex = -1;
                this.SetPackageInformation(false);
                this.ClearPackageInformation();
                this.DisableButtons();
            }//if (this.AddIsValid()) {
            this.SetNavButtons();
            this.GarbageCollection(75);
        }//private void EditButton_Click(object sender, RoutedEventArgs e) {

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            if (++this.packageIndex >= this.packages.Count) {
                this.packageIndex = 0;
            }//if (++this.packageIndex >= this.packages.Count) {
            this.StatePackageComboBox.SelectedItem = this.packages[this.packageIndex].State;
            this.DisplayPackage(this.packages[this.packageIndex]);
            this.SetPackageInformation(true);
            this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = true;
            this.GarbageCollection(75);
        }//private void NextButton_Click(object sender, RoutedEventArgs e) {

        private void RemoveButton_Click(object sender, RoutedEventArgs e) {
            Package objRef = this.GetPackageByPID(this.PackageIDTextBox.Text);
            if (!this.packages.Remove(objRef)) {
                this.Toast(this.PackageIDTextBox, ToastColors.ERROR, "Failed to remove the package");
            } else {//if (!this.packages.Remove(objRef)) {
                _ = this.statePackage.Remove(objRef);
                _ = Package.PackageIDList.Remove(long.Parse(this.PackageIDTextBox.Text));
                this.PackageListBox.ItemsSource = "";
                this.PackageListBox.ItemsSource = this.statePackage;
            }//else {
            this.packageIndex--;
            if (this.statePackage.Count == 0) {
                this.StatePackageComboBox.SelectedIndex = -1;
            }//if (this.statePackage.Count == 0) {
            this.PackageListBox.SelectedIndex = -1;
            this.SetPackageInformation(false);
            this.ClearPackageInformation();
            this.DisableButtons();
            this.SetNavButtons();
            this.GarbageCollection(75);
        }//private void RemoveButton_Click(object sender, RoutedEventArgs e) {

        private void ScanNewButton_Click(object sender, RoutedEventArgs e) {
            this.ClearPackageInformation();
            this.SetPackageInformation(true);
            this.AddButton.IsEnabled = true;
            this.PackageIDTextBox.Text = this.GenerateNewPackageID(long.MaxValue).ToString();
            this.StatePackageComboBox.SelectedIndex = -1;
            this.ArrivedAtTextBox.Text = DateTime.Now.ToString();
            this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = false;
            this.PackageListBox.SelectedIndex = -1;
            this.PackageListBox.ItemsSource = "";
            this.packageIndex = -1;
            _ = this.AddressTextBox.Focus();
            this.GarbageCollection(75);
        }//private void ScanNewButton_Click(object sender, RoutedEventArgs e) {

        private void ZipTextBoxDelta(object sender, RoutedEventArgs e) {
            if (!Regex.IsMatch(this.ZipTextBox.Text, "^[0-9]*[-]?[0-9]*$")) {
                int index = this.ZipTextBox.CaretIndex - 1;
                this.ZipTextBox.Text = this.lastZipTextBox;
                this.ZipTextBox.CaretIndex = index;
                this.Toast(this.ZipTextBox, ToastColors.ERROR, "Invalid");
            }//if (!Regex.IsMatch(this.ZipTextBox.Text, "^[0-9]*[-]?[0-9]*$")) {
            this.lastZipTextBox = this.ZipTextBox.Text;
            this.GarbageCollection(75);
        }//private void ZipTextBoxDelta(object sender, RoutedEventArgs e) {

        /*===========================End of Buttons=================================================*/

        /*=========================Selection Changed================================================*/

        private void PackageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ListBox)sender).SelectedIndex != -1) {
                this.SetPackageInformation(true);
                this.ClearPackageInformation();
                this.DisplayPackage(this.GetPackageByPID(((ListBox)sender).SelectedItem.ToString()));
            }//if (((ListBox)sender).SelectedIndex != -1) {
            this.GarbageCollection(75);
        }//private void PackageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        private void StatePackageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ComboBox)sender).SelectedIndex != -1) {
                this.SetPackageInformation(false);
                this.ClearPackageInformation();
                this.statePackage = new List<Package>();
                foreach (Package package in this.packages) {
                    if (package.State.Equals(((ComboBox)sender).SelectedItem.ToString())) {
                        this.statePackage.Add(package);
                    }//if (package.State.Equals(((ComboBox)sender).SelectedItem.ToString())) {
                }//foreach (Package package in this.packages) {
                this.PackageListBox.ItemsSource = this.statePackage;
                this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = this.AddButton.IsEnabled = false;
                this.PackageListBox.IsEnabled = this.statePackage.Count > 0;
            }//if (((ComboBox)sender).SelectedIndex != -1) {
            this.GarbageCollection(75);
        }//private void StatePackageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        /*===================End of Selection Changed===============================================*/

        /*==============================Set Methods=================================================*/

        private void ClearPackageInformation() {
            this.ArrivedAtTextBox.Text = this.ZipTextBox.Text = this.CityTextBox.Text = this.AddressTextBox.Text = this.PackageIDTextBox.Text = "";
            this.StateComboBox.SelectedIndex = -1;
        }//private void ClearPackageInformation() {

        private void DisableButtons() {
            this.AddButton.IsEnabled = this.RemoveButton.IsEnabled = this.EditButton.IsEnabled = false;
        }//private void DisableButtons() {

        private void DisplayPackage(Package package) {
            this.ArrivedAtTextBox.Text = package.Dt.ToString();
            this.PackageIDTextBox.Text = package.ToString();
            this.AddressTextBox.Text = package.Address;
            this.CityTextBox.Text = package.City;
            this.ZipTextBox.Text = package.Zip;
            this.StateComboBox.SelectedIndex = this.states.IndexOf(package.State);
            this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = true;
        }//private void DisplayPackage(Package package) {

        private long GenerateNewPackageID(long max) {
            long setNew;
            do {
                setNew = long.Parse((this.randy.Next() % long.Parse(max.ToString()[0].ToString()) + 1).ToString() + Regex.Replace(max.ToString()[1..], "[1-9]", "0")) + (long)(this.randy.NextDouble() * max) % long.Parse(max.ToString()[1..].ToString());
            } while (Package.PackageIDList.Contains(setNew));
            return setNew;
        }//private long GenerateNewPackageID(long max) {

        private void PopulateStates() {
            this.states.Add("AL");
            this.states.Add("FL");
            this.states.Add("GA");
            this.states.Add("KY");
            this.states.Add("MS");
            this.states.Add("NC");
            this.states.Add("SC");
            this.states.Add("TN");
            this.states.Add("WV");
            this.states.Add("VA");
        }//private void PopulateStates() {

        private void PreLoadPackages(char stateAbrThreshold, short packagesToCreatePerState) {
            int itemIndex = 0;
            foreach (string state in this.states) {
                for (int i = 0; i < packagesToCreatePerState; i++) {
                    if (state[0] < stateAbrThreshold) {
                        this.packages.Add(new Package(DateTime.Now, this.GenerateNewPackageID(long.MaxValue), "Address " + ++itemIndex, "City " + itemIndex, state, itemIndex + "-" + (itemIndex + itemIndex)));
                    }//if (state[0] < stateAbrThreshold) {
                }//for (int i = 0; i < packagesToCreatePerState; i++) {
            }//foreach (string state in this.states) {
        }//private void PreLoadPackages(char stateAbrThreshold, short packagesToCreatePerState) {

        private void SetInitialSettings() {
            this.SetNavButtons();
            this.SetPackageInformation(false);
            this.ClearPackageInformation();
            this.PackagesByStateLabel.IsEnabled = true;
            this.AddButton.IsEnabled = this.EditButton.IsEnabled = this.RemoveButton.IsEnabled = false;
        }//private void SetInitialSettings() {

        private void SetNavButtons() {
            this.StatePackageComboBox.IsEnabled = this.BackButton.IsEnabled = this.NextButton.IsEnabled = this.packages.Count > 0;
        }//private void SetNavButtons() {

        /*===========================End of Set Methods=============================================*/

        /*=============================Is Valid Methods=============================================*/

        private bool AddIsValid() {
            return this.TextBoxIsValid(this.AddressTextBox, "Not a valid address") & this.TextBoxIsValid(this.CityTextBox, "Not a valid city") & this.TextBoxIsValid(this.ZipTextBox, "Ivalid zip") & this.StateComboBoxIsValid();
        }//private bool AddIsValid() {

        private bool StateComboBoxIsValid() {
            if (this.StateComboBox.SelectedIndex == -1) {
                this.Toast(this.StateComboBox, ToastColors.PRIMARY, "Choose");
                return false;
            }//if (this.StateComboBox.SelectedIndex == -1) {
            return true;
        }//private bool StateComboBoxIsValid() {

        private bool TextBoxIsValid(TextBox textbox, string toast) {
            if (textbox.Text.Length == 0) {
                this.Toast(textbox, ToastColors.PRIMARY, toast);
                return false;
            }//if (textbox.Text.Length == 0) {
            return true;
        }//private bool TextBoxIsValid(TextBox textbox, string toast) {

        /*===========================End of Is Valid Methods========================================*/

        /*================================Utility Methods===========================================*/

        private void GarbageCollection(int removalThreshold) {
            if (this.MainGrid.Children.Count > removalThreshold) {
                List<UIElement> removalElements = new List<UIElement>();
                for (int i = 0; i < this.MainGrid.Children.Count; i++) {
                    if (!this.MainGrid.Children[i].IsVisible && this.MainGrid.Children[i].GetType().FullName.Equals("System.Windows.Controls.Border")) {
                        removalElements.Add(this.MainGrid.Children[i]);
                    }//if (!this.MainGrid.Children[i].IsVisible && this.MainGrid.Children[i].GetType().FullName.Equals("System.Windows.Controls.Border"))
                }//for (int i = 0; i < this.MainGrid.Children.Count; i++) {
                foreach (UIElement element in removalElements) {
                    this.MainGrid.Children.Remove(element);
                }//foreach (UIElement element in removalElements) {
            }//if (this.MainGrid.Children.Count > removalThreshold) {
        }//private void GarbageCollection(int removalThreshold) {

        private Package GetPackageByPID(string pid) {
            for (int i = 0; i < this.packages.Count; i++) {
                if (this.packages[i].Equals(pid)) {
                    this.packageIndex = i;
                    return this.packages[i];
                }//if (this.packages[i].Equals(pid)) {
            }//for (int i = 0; i < this.packages.Count; i++) {
            return null;
        }//private Package GetPackageByPID(string pid) {

        private void SetPackageInformation(bool isEnabled) {
            this.ArrivedAtLabel.IsEnabled = this.ArrivedAtTextBox.IsEnabled = this.PackageInformationLabel.IsEnabled = this.PackageIDLabel.IsEnabled = this.PackageIDTextBox.IsEnabled = this.AddressLabel.IsEnabled = this.AddressTextBox.IsEnabled = this.CityLabel.IsEnabled = this.CityTextBox.IsEnabled = this.StateLabel.IsEnabled = this.StateComboBox.IsEnabled = this.ZipLabel.IsEnabled = this.ZipTextBox.IsEnabled = isEnabled;
            this.PackageInformationRectangle.Stroke = isEnabled ? new SolidColorBrush(Color.FromRgb(0, 0, 0)) : new SolidColorBrush(Color.FromRgb(127, 127, 127));
        }//private void SetPackageInformation(bool isEnabled) {

        private void Toast(Control control, ToastColors color, string toast) {
            Toaster internalToast = new Toaster();
            _ = this.MainGrid.Children.Add(internalToast.GetToast());
            internalToast.SetBorderHeight((int)control.Height);
            internalToast.SetBorderWidth((int)control.Width);
            internalToast.SetBorderMargin(control.Margin.Left, control.Margin.Top, control.Margin.Right, control.Margin.Bottom);
            internalToast.SetBorderVerticalAlignment(VerticalAlignment.Center);
            internalToast.SetBorderCornerRadius(new CornerRadius(0.0));
            internalToast.SetPrimaryColors(Color.FromRgb(200, 200, 200), Color.FromRgb(100, 100, 100), Color.FromRgb(0, 0, 0));
            internalToast.PopToastie(toast, color, 1);
        }//private void Toast(Control control, ToastColors color, string toast) {

        /*=============================End of Utility Methods=======================================*/
    }//public partial class MainWindow : Window {
}//namespace Lab6 {