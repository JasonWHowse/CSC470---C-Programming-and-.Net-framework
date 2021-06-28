using Lab4.src;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Lab4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly List<Charity> donations = new List<Charity>();
        private enum ToastColors { PRIMARY, WARNING, ERROR }
        private string lastDonation = "";
        public MainWindow() {
            InitializeComponent();

            SetTextBoxes();

            UpdateBackgroundGridColor(Helpers.ColorFromHex("000000"));
            UpdateInnerBoxColor(Helpers.ColorFromHex("aaaaaa"));
            UpdateTextBlockColor(Helpers.ColorFromHex("eeeeff"), Helpers.ColorFromHex("000000"));
            UpdateCharityListLabelColor(Helpers.ColorFromHex("e5fff1"), Helpers.ColorFromHex("000000"));
            UpdateAddToCharityButtoColor(Helpers.ColorFromHex("00aaff"), Helpers.ColorFromHex("000000"));
            UpdateTotalToCharityLabelColor(Helpers.ColorFromHex("ffffe5"), Helpers.ColorFromHex("000000"));
            UpdateDonationTextBoxColor(Helpers.ColorFromHex("ffffff"), Helpers.ColorFromHex("000000"));
            UpdateDonationLabelColor(Helpers.ColorFromHex("afe2fd"), Helpers.ColorFromHex("000000"));
        }//public MainWindow() {

        private void Add_Charity_To_List_Button_Click(object sender, RoutedEventArgs e) {

            if (!decimal.TryParse(Donation_TextBox.Text, out decimal donation) || Donation_TextBox.Text.Length == 0 || Donation_TextBox.Text.Trim()[0] == '-') {
                PopToastie("Donation must be a positive number", ToastColors.ERROR, 5);
                return;
            }//if (!decimal.TryParse(Donation_TextBox.Text, out decimal donation) || Donation_TextBox.Text.Length == 0 || Donation_TextBox.Text.Trim()[0] == '-') {
            donations.Add(new Charity());
            Charity.SetValues(donations[^1], donation);
            Donation_To_Charity_List_TextBlock.Text = GetToCharityString();
            Donation_To_List_TextBlock.Text = GetDonationsString();
            Donation_To_Upkeep_List_TextBlock.Text = GetUpkeepString();
            Total_To_Charity_Label.Content = Charity.GetTotalCharity();
            Total_To_Donations_Label.Content = Charity.GetTotalDonations();
            Total_To_Upkeep_Label.Content = Charity.GetTotalUpKeep();
            Donation_TextBox.Text = "";
            PopToastie("Donation Added", ToastColors.PRIMARY, 5);
        }//private void Add_Charity_To_List_Button_Click(Object sender, RoutedEventArgs e) {
        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                Add_Charity_To_List_Button_Click(sender, new RoutedEventArgs());
            }//if (e.Key == Key.Return) {
        }//private void OnKeyDownHandler(object sender, KeyEventArgs e) {

        private string GetToCharityString() {
            string output = "";
            foreach (Charity donation in donations) {
                output = donation.GetCharityValue() + "\r\n" + output;
            }//foreach (Charity donation in donations) {
            return output;
        }//private string GetToCharityString() {

        private string GetDonationsString() {
            string output = "";
            foreach (Charity donation in donations) {
                output = donation.GetDonation() + "\r\n" + output;
            }//foreach (Charity donation in donations) {
            return output;
        }//private string GetDonationsString() {

        private string GetUpkeepString() {
            string output = "";
            foreach (Charity donation in donations) {
                output = donation.GetUpKeep() + "\r\n" + output;
            }//foreach (Charity donation in donations) {
            return output;
        }//private string GetUpkeepString() {

        private void DonationTextBoxDelta(object sender, RoutedEventArgs e) {
            if (Donation_TextBox.Text.Length > 0 && !Donation_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Donation_TextBox.Text, out decimal donation) || donation < 0)) {
                int index = Donation_TextBox.CaretIndex - 1;
                Donation_TextBox.Text = lastDonation;
                Donation_TextBox.CaretIndex = index;
                PopToastie("Donation must be a positive number", ToastColors.ERROR, 5);
            }//if (Donation_TextBox.Text.Length > 0 && !Donation_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Donation_TextBox.Text, out decimal donation) || donation < 0)) {
            lastDonation = Donation_TextBox.Text;
        }//private void DonationTextBoxDelta(object sender, RoutedEventArgs e) {

        private void SetTextBoxes() {
            Charity_Total_Label.Content = "Total Charity";
            Total_To_Charity_Label.Content = "";
            Donations_Total_Label.Content = "Total Donations";
            Total_To_Donations_Label.Content = "";
            Upkeep_Total_Label.Content = "Total Upkeep";
            Total_To_Upkeep_Label.Content = "";

            Donation_Label.Content = "Donation";
            Add_Charity_To_List_Button.Content = "Add Donation";
            Donation_To_Charity_List_Label.Content = "Charity";
            Donation_To_Charity_List_TextBlock.Text = "";
            Donation_To_List_Label.Content = "Donations";
            Donation_To_List_TextBlock.Text = "";
            Donation_To_Upkeep_List_Label.Content = "Upkeep";
            Donation_To_Upkeep_List_TextBlock.Text = "";
        }//private void SetTextBoxes() {

        private void PopToastie(string message, ToastColors tc, int seconds) {
            switch (tc) {
                case ToastColors.PRIMARY:
                    Toastie.Background = new SolidColorBrush(Color.FromArgb(225, 0, 125, 0));
                    Toastie.BorderBrush = new SolidColorBrush(Color.FromArgb(225, 0, 255, 0));
                    ToastieText.Foreground = new SolidColorBrush(Color.FromArgb(225, 0, 255, 0));
                    break;
                case ToastColors.ERROR:
                    Toastie.Background = new SolidColorBrush(Color.FromArgb(225, 125, 0, 0));
                    Toastie.BorderBrush = new SolidColorBrush(Color.FromArgb(225, 255, 0, 0));
                    ToastieText.Foreground = new SolidColorBrush(Color.FromArgb(225, 255, 0, 0));
                    break;
                case ToastColors.WARNING:
                    Toastie.Background = new SolidColorBrush(Color.FromArgb(225, 125, 125, 0));
                    Toastie.BorderBrush = new SolidColorBrush(Color.FromArgb(225, 255, 255, 0));
                    ToastieText.Foreground = new SolidColorBrush(Color.FromArgb(225, 255, 255, 0));
                    break;
                default:
                    Toastie.Background = new SolidColorBrush(Color.FromArgb(225, 255, 255, 255));
                    Toastie.BorderBrush = new SolidColorBrush(Color.FromArgb(225, 0, 0, 0));
                    ToastieText.Foreground = new SolidColorBrush(Color.FromArgb(225, 100, 100, 100));
                    break;
            }//switch (tc) {
            ToastieText.Text = message;
            Toastie.Visibility = Visibility.Visible;
            DispatcherTimer timer = new DispatcherTimer {
                Interval = TimeSpan.FromSeconds(seconds)
            };
            timer.Stop();
            timer.Tick += (s, en) => {
                Toastie.Visibility = Visibility.Hidden;
                timer.Stop();
            };
            timer.Start();
        }//private void PopToastie(string message, ToastColors tc, int seconds) {

        private void UpdateBackgroundGridColor(Color backgroundColor) {
            Background_Grid.Background = new SolidColorBrush(backgroundColor);
        }//private void UpdateBackgroundGridColor(Color backgroundColor) {

        private void UpdateInnerBoxColor(Color backgroundColor) {
            Inner_Box.Fill = new SolidColorBrush(backgroundColor);
        }//private void UpdateInnerBoxColor(Color backgroundColor) {

        private void UpdateDonationLabelColor(Color backgroundColor, Color fontColor) {
            Upkeep_Total_Label.Background = Donations_Total_Label.Background = Charity_Total_Label.Background = Donation_Label.Background = new SolidColorBrush(backgroundColor);
            Upkeep_Total_Label.Foreground = Donations_Total_Label.Foreground = Charity_Total_Label.Foreground = Donation_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateDonationLabelColor(Color backgroundColor, Color fontColor) {

        private void UpdateDonationTextBoxColor(Color backgroundColor, Color fontColor) {
            Donation_TextBox.Background = new SolidColorBrush(backgroundColor);
            Donation_TextBox.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateDonationTextBoxColor(Color backgroundColor, Color fontColor) {

        private void UpdateTotalToCharityLabelColor(Color backgroundColor, Color fontColor) {
            Total_To_Upkeep_Label.Background = Total_To_Donations_Label.Background = Total_To_Charity_Label.Background = new SolidColorBrush(backgroundColor);
            Total_To_Upkeep_Label.Foreground = Total_To_Donations_Label.Foreground = Total_To_Charity_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateTotalToCharityLabelColor(Color backgroundColor, Color fontColor) {

        private void UpdateAddToCharityButtoColor(Color backgroundColor, Color fontColor) {
            Add_Charity_To_List_Button.Background = new SolidColorBrush(backgroundColor);
            Add_Charity_To_List_Button.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateAddToCharityButtoColor(Color backgroundColor, Color fontColor) {

        private void UpdateCharityListLabelColor(Color backgroundColor, Color fontColor) {
            Donation_To_Charity_List_Label.Background = Donation_To_List_Label.Background = Donation_To_Upkeep_List_Label.Background = new SolidColorBrush(backgroundColor);
            Donation_To_Charity_List_Label.Foreground = Donation_To_List_Label.Foreground = Donation_To_Upkeep_List_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateCharityListLabel(Color backgroundColor, Color fontColor) {

        private void UpdateTextBlockColor(Color backgroundColor, Color fontColor) {
            Donation_To_Charity_List_TextBlock.Background = Donation_To_List_TextBlock.Background = Donation_To_Upkeep_List_TextBlock.Background = new SolidColorBrush(backgroundColor);
            Donation_To_Upkeep_List_TextBlock.Foreground = Donation_To_List_TextBlock.Foreground = Donation_To_Charity_List_TextBlock.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateTextBlockColor(Color backgroundColor,Color fontColor) {
    }//public partial class MainWindow : Window {
}//namespace Lab4 {