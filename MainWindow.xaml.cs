using Project2.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Project2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /*============================Instance Variables==============================*/

        private readonly List<Employee> employees = new List<Employee>();
        private enum ToastColors { PRIMARY, WARNING, ERROR }
        private string lastHours = "";
        private string lastFirstName = "";
        private string lastLastName = "";
        private string lastAge = "";
        private string lastHourlyRate = "";
        private string lastUsualHours = "";

        /*=====================End of Instance Variables==============================*/

        public MainWindow() {
            InitializeComponent();
            Calculate_Combo_Box.ItemsSource = employees;
            Update_Combo_Box.ItemsSource = employees;

            UpdateLeftBoxLabelsColor(ColorFromHex("e5fff1"), ColorFromHex("000000"));
            UpdateLeftBoxTextBoxColor(ColorFromHex("eeeeee"), ColorFromHex("000000"));

            UpdateRightBoxLabelsColor(ColorFromHex("afe2fd"), ColorFromHex("000000"));
            UpdateRightBoxTextBoxColor(ColorFromHex("eeeeee"), ColorFromHex("000000"));
            UpdateRightBoxWageLabel(ColorFromHex("e5fff1"), ColorFromHex("000000"));
            UpdateRightSalaryLabel(ColorFromHex("e5fff1"), ColorFromHex("000000"));

            /*=======================================================================*/

            UpdateRequired_Label(ColorFromHex("ff0000"));

            UpdateCalculateButton(ColorFromHex("00cc33"), ColorFromHex("000000"));

            UpdateUpdateButton(ColorFromHex("eeee00"), ColorFromHex("000000"));
            UpdateDeleteButton(ColorFromHex("cc0000"), ColorFromHex("000000"));

            UpdateSaveButton(ColorFromHex("00cc33"), ColorFromHex("000000"));
            UpdateBackButton(ColorFromHex("eeee00"), ColorFromHex("000000"));

            UpdateUpdateEmployeeButton(ColorFromHex("ff7f00"), ColorFromHex("000000"));
            UpdateCreateEmployeeButton(ColorFromHex("00aaff"), ColorFromHex("000000"));

            /*=======================================================================*/

            UpdateBackground(ColorFromHex("0000cc"));
            UpdateRightBoxSquare(ColorFromHex("cccccc"));
            UpdateLeftBoxSquare(ColorFromHex("cccccc"));

            Employee_Create.Visibility = Employee_Update.Visibility = Visibility.Visible;

            Required_Label.Visibility = Employee_Back_Secondary.Visibility = Toastie.Visibility = Employee_Delete_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Update_Combo_Box.Visibility = Employee_Update_Secondary.Visibility = EmployeeID_Label.Visibility = EmployeeID_LabelText.Visibility = Employee_Save_Secondary.Visibility = Visibility.Hidden;
        }//public MainWindow() {

        /*============================ComboBox Delta==================================*/

        private void Combo_Box_Calculate(object sender, SelectionChangedEventArgs e) {
            if (Calculate_Combo_Box.SelectedIndex >= 0) {
                Employee employee = GetEmployee(Calculate_Combo_Box.SelectedItem.ToString());
                Hours_TextBox.Text = employee.GetUsualHours() == null ? "" : employee.GetUsualHours().ToString();
                Wage_Label.Content = employee.GetHourlyConsultingRate().ToString("C2");
                if (employee.GetUsualHours() != null) {
                    Salary_Label.Content = employee.GetUsualHours() > 40.0m ? ((decimal)((employee.GetUsualHours() - 40.0m) * employee.GetHourlyConsultingRate() * 1.5m + 40.0m * employee.GetHourlyConsultingRate())).ToString("C2") : ((decimal)(employee.GetHourlyConsultingRate() * employee.GetUsualHours())).ToString("C2");
                }//if (employee.GetUsualHours() != null) {
            } else {//if (Calculate_Combo_Box.SelectedIndex >= 0) {
                Hours_TextBox.Text = "";
                Wage_Label.Content = "";
                Salary_Label.Content = "";
            }//else {
        }//private void Combo_Box_Calculate(object sender, SelectionChangedEventArgs e) {

        private void Update_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (Update_Combo_Box.SelectedIndex >= 0) {
                Employee employee = GetEmployee(Update_Combo_Box.SelectedItem.ToString());
                First_Name_TextBox.Text = employee.GetFirstName();
                Last_Name_TextBox.Text = employee.GetLastName();
                Age_TextBox.Text = employee.GetAge() == null ? "" : employee.GetAge().ToString();
                Hourly_Rate_TextBox.Text = employee.GetHourlyConsultingRate().ToString();
                Usual_Hours_TextBox.Text = employee.GetUsualHours() == null ? "" : employee.GetUsualHours().ToString();
                EmployeeID_Label.Content = employee.GetEmployeeID();
            }//if (Update_Combo_Box.SelectedIndex >= 0) {
        }//private void Update_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        /*=====================End of ComboBox Delta==================================*/

        /*==============================Buttons=======================================*/

        private void Calculate_wage(object sender, RoutedEventArgs e) {
            if (Calculate_Combo_Box.SelectedIndex >= 0) {
                Employee employee = GetEmployee(Calculate_Combo_Box.SelectedItem.ToString());
                if (!decimal.TryParse(Hours_TextBox.Text, out decimal hours)) {
                    PopToastie("Hours must be a positive number", ToastColors.ERROR, 2);
                } else if (hours < 0) {//if (!decimal.TryParse(Hours_TextBox.Text, out hours)) {
                    PopToastie("Hours must be a positive number", ToastColors.ERROR, 2);
                } else {//else if (hours < 0) {
                    Salary_Label.Content = (hours > 40.0m ? 1.5m * (hours - 40.0m) * employee.GetHourlyConsultingRate() + 40.0m * employee.GetHourlyConsultingRate() : hours * employee.GetHourlyConsultingRate()).ToString("C2");
                }//} else {
            } else {//if (Calculate_Combo_Box.SelectedIndex >= 0) {
                PopToastie("Please select an employee", ToastColors.ERROR, 2);
            }//else {
        }//private void Calculate_wage(object sender, RoutedEventArgs e) {

        private void Create_Employee(object sender, RoutedEventArgs e) {
            Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Hidden;

            Required_Label.Visibility = Employee_Back_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Employee_Save_Secondary.Visibility = Visibility.Visible;
        }//private void Create_Employee(object sender, RoutedEventArgs e) {

        private void Secondary_Back_Employee(object sender, RoutedEventArgs e) {
            Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Visible;

            First_Name_TextBox.Text = Last_Name_TextBox.Text = Age_TextBox.Text = Hourly_Rate_TextBox.Text = Usual_Hours_TextBox.Text = "";

            Required_Label.Visibility = Employee_Back_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Employee_Save_Secondary.Visibility = Visibility.Hidden;
        }//private void Secondary_Back_Employee(object sender, RoutedEventArgs e) {

        private void Secondary_Delete_Employee(object sender, RoutedEventArgs e) {
            if (Update_Combo_Box.SelectedIndex == -1) {
                PopToastie("Must select an employee", ToastColors.ERROR, 2);
                return;
            }//if (Update_Combo_Box.SelectedIndex == -1) {

            employees.Remove(GetEmployee(Update_Combo_Box.SelectedItem.ToString()));

            Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Visible;

            Update_Combo_Box.SelectedIndex = -1;

            Calculate_Combo_Box.ItemsSource = null;
            Update_Combo_Box.ItemsSource = null;

            Calculate_Combo_Box.ItemsSource = employees;
            Update_Combo_Box.ItemsSource = employees;

            EmployeeID_Label.Content = First_Name_TextBox.Text = Last_Name_TextBox.Text = Age_TextBox.Text = Hourly_Rate_TextBox.Text = Usual_Hours_TextBox.Text = "";

            Required_Label.Visibility = Employee_Delete_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Update_Combo_Box.Visibility = Employee_Update_Secondary.Visibility = EmployeeID_Label.Visibility = EmployeeID_LabelText.Visibility = Visibility.Hidden;
            PopToastie("Employee Deleted", ToastColors.ERROR, 2);
        }//private void Secondary_Delete_Employee(object sender, RoutedEventArgs e) {

        private void Secondary_Save_Employee(object sender, RoutedEventArgs e) {
            int? age = -1;
            decimal hourlyRate = -1.0m;
            decimal? usualHours = -1.0m;
            bool flag;

            (age, hourlyRate, usualHours, flag) = IsValid();
            if (!flag) {
                return;
            }//if (!flag) {

            employees.Add(new Employee(First_Name_TextBox.Text, Last_Name_TextBox.Text, age == -1 ? null : age, hourlyRate, usualHours == -1.0m ? null : usualHours));

            employees.Sort((a, b) => a.GetEmployeeID() - b.GetEmployeeID());

            Update_Combo_Box.SelectedIndex = -1;

            Calculate_Combo_Box.ItemsSource = null;
            Update_Combo_Box.ItemsSource = null;

            Calculate_Combo_Box.ItemsSource = employees;
            Update_Combo_Box.ItemsSource = employees;

            Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Visible;

            EmployeeID_Label.Content = First_Name_TextBox.Text = Last_Name_TextBox.Text = Age_TextBox.Text = Hourly_Rate_TextBox.Text = Usual_Hours_TextBox.Text = "";

            Required_Label.Visibility = Employee_Back_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Employee_Save_Secondary.Visibility = Visibility.Hidden;
            PopToastie("Employee Added", ToastColors.PRIMARY, 2);
        }//private void Secondary_Save_Employee(object sender, RoutedEventArgs e) {

        private void Secondary_Update_Employee(object sender, RoutedEventArgs e) {
            int? age = -1;
            decimal hourlyRate = -1.0m;
            decimal? usualHours = -1.0m;
            bool flag;
            Employee employee;


            if (Update_Combo_Box.SelectedIndex == -1) {
                PopToastie("Must select an employee", ToastColors.ERROR, 5);
                return;
            } else {//if (Update_Combo_Box.SelectedIndex == -1) {
                (age, hourlyRate, usualHours, flag) = IsValid();
            }//else {
            if (!flag) {
                return;
            }//f (!flag) {

            employee = GetEmployee(Update_Combo_Box.SelectedItem.ToString());
            employee.SetAge(age == -1 ? null : age);
            employee.SetFirstName(First_Name_TextBox.Text);
            employee.SetLastName(Last_Name_TextBox.Text);
            employee.SetUsualHours(usualHours == -1 ? null : usualHours);
            employee.SetHourlyConsultingRate(hourlyRate);

            employees.Sort((a, b) => a.GetEmployeeID() - b.GetEmployeeID());

            Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Visible;

            Update_Combo_Box.SelectedIndex = -1;

            Calculate_Combo_Box.ItemsSource = null;
            Update_Combo_Box.ItemsSource = null;

            Calculate_Combo_Box.ItemsSource = employees;
            Update_Combo_Box.ItemsSource = employees;

            EmployeeID_Label.Content = First_Name_TextBox.Text = Last_Name_TextBox.Text = Age_TextBox.Text = Hourly_Rate_TextBox.Text = Usual_Hours_TextBox.Text = "";

            Required_Label.Visibility = Employee_Delete_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Update_Combo_Box.Visibility = Employee_Update_Secondary.Visibility = EmployeeID_Label.Visibility = EmployeeID_LabelText.Visibility = Visibility.Hidden;
            PopToastie("Employee Updated", ToastColors.WARNING, 2);
        }//private void Secondary_Update_Employee(object sender, RoutedEventArgs e) {

        private void Update_Employee(object sender, RoutedEventArgs e) {
            if (employees.Count != 0) {
                Employee_Update.Visibility = Employee_Create.Visibility = Visibility.Hidden;

                Required_Label.Visibility = Employee_Delete_Secondary.Visibility = First_Name_Label.Visibility = First_Name_TextBox.Visibility = Last_Name_Label.Visibility = Last_Name_TextBox.Visibility = Age_Label.Visibility = Age_TextBox.Visibility = Hourly_Rate_Label.Visibility = Hourly_Rate_TextBox.Visibility = Usual_Hours_Label.Visibility = Usual_Hours_TextBox.Visibility = Update_Combo_Box.Visibility = Employee_Update_Secondary.Visibility = EmployeeID_Label.Visibility = EmployeeID_LabelText.Visibility = Visibility.Visible;
            } else {//if (employees.Count != 0) {
                PopToastie("No employees created", ToastColors.ERROR, 2);
            }//else {
        }//private void Update_Employee(object sender, RoutedEventArgs e) {

        /*=======================End of Buttons=======================================*/

        /*=======================Text box delta checkers==============================*/

        private void AgeDelta(object sender, RoutedEventArgs e) {
            if (Age_TextBox.Text.Length != 0 && (!int.TryParse(Age_TextBox.Text, out int age) || age < 0)) {
                int index = Age_TextBox.CaretIndex - 1;
                Age_TextBox.Text = lastAge;
                Age_TextBox.CaretIndex = index;
                PopToastie("Age must be a positive integer", ToastColors.ERROR, 5);
            }//if (Age_TextBox.Text.Length != 0 && (!int.TryParse(Age_TextBox.Text, out int age) || age < 0)) {
            lastAge = Age_TextBox.Text;
        }//private void AgeDelta(object sender, RoutedEventArgs e) {

        private void FirstNameDelta(object sender, RoutedEventArgs e) {
            if (First_Name_TextBox.Text.Length > 0 && !First_Name_TextBox.Text.All(char.IsLetter)) {
                int index = First_Name_TextBox.CaretIndex - 1;
                First_Name_TextBox.Text = lastFirstName;
                First_Name_TextBox.CaretIndex = index;
                PopToastie("First name must only contain alphabet characters", ToastColors.ERROR, 5);
            }////if (First_Name_TextBox.Text.Length > 0 && !First_Name_TextBox.Text.All(char.IsLetter)) {
            lastFirstName = First_Name_TextBox.Text;
        }//private void FirstNameDelta(object sender, RoutedEventArgs e) {

        private void HoursDelta(object sender, RoutedEventArgs e) {
            if (Hours_TextBox.Text.Length > 0 && !Hours_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Hours_TextBox.Text, out decimal hours) || hours < 0)) {
                int index = Hours_TextBox.CaretIndex - 1;
                Hours_TextBox.Text = lastHours;
                Hours_TextBox.CaretIndex = index;
                PopToastie("Hours must be a positive number", ToastColors.ERROR, 5);
            }//if (Hours_TextBox.Text.Length > 0 && !Hours_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Hours_TextBox.Text, out decimal hours) || hours < 0)) {
            lastHours = Hours_TextBox.Text;
        }//private void HoursDelta(object sender, RoutedEventArgs e) {

        private void HourlyRateDelta(object sender, RoutedEventArgs e) {
            if (Hourly_Rate_TextBox.Text.Length > 0 && !Hourly_Rate_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Hourly_Rate_TextBox.Text, out decimal hourlyRate) || hourlyRate < 0)) {
                int index = Hourly_Rate_TextBox.CaretIndex - 1;
                Hourly_Rate_TextBox.Text = lastHourlyRate;
                Hourly_Rate_TextBox.CaretIndex = index;
                PopToastie("Hourly rate must be a positive number", ToastColors.ERROR, 5);
            }//if (Hourly_Rate_TextBox.Text.Length > 0 && !Hourly_Rate_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Hourly_Rate_TextBox.Text, out decimal hourlyRate) || hourlyRate < 0)) {
            lastHourlyRate = Hourly_Rate_TextBox.Text;
        }//private void HourlyRateDelta(object sender, RoutedEventArgs e) {

        private void LastNameDelta(object sender, RoutedEventArgs e) {
            if (Last_Name_TextBox.Text.Length > 0 && !Last_Name_TextBox.Text.All(char.IsLetter)) {
                int index = Last_Name_TextBox.CaretIndex - 1;
                Last_Name_TextBox.Text = lastLastName;
                Last_Name_TextBox.CaretIndex = index;
                PopToastie("Last name must only contain alphabet characters", ToastColors.ERROR, 5);
            }//if (Last_Name_TextBox.Text.Length > 0 && !Last_Name_TextBox.Text.All(char.IsLetter)) {
            lastLastName = Last_Name_TextBox.Text;
        }//private void LastNameDelta(object sender, RoutedEventArgs e) {

        private void UsualHoursDelta(object sender, RoutedEventArgs e) {
            if (Usual_Hours_TextBox.Text.Length > 0 && !Usual_Hours_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Usual_Hours_TextBox.Text, out decimal hours) || hours < 0)) {
                int index = Usual_Hours_TextBox.CaretIndex - 1;
                Usual_Hours_TextBox.Text = lastUsualHours;
                Usual_Hours_TextBox.CaretIndex = index;
                PopToastie("Usual hours must be a positive number", ToastColors.ERROR, 5);
            }//if (Usual_Hours_TextBox.Text.Length > 0 && !Usual_Hours_TextBox.Text.ToString().Equals(".") && (!decimal.TryParse(Usual_Hours_TextBox.Text, out decimal hours) || hours < 0)) {
            lastUsualHours = Usual_Hours_TextBox.Text;
        }//private void UsualHoursDelta(object sender, RoutedEventArgs e) {

        /*================End of Text box delta checkers==============================*/

        /*=======================Helper functions=====================================*/
        
        private static Color ColorFromHex(string color) {
            return Color.FromRgb(Convert.ToByte(color[0..2], 16), Convert.ToByte(color[2..4], 16), Convert.ToByte(color[4..6], 16));
        }//private static Color ColorFromHex(string color) {

        private Employee GetEmployee(string fromBox) {
            return employees.FindLast(s => s.GetEmployeeID() == int.Parse(fromBox.Split(":")[0].Trim()));
        }//private Employee GetEmployee(string fromBox) {

        private (int, decimal, decimal, bool) IsValid() {
            int age = -1;
            decimal hourlyRate = -1.0m;
            decimal usualHours = -1.0m;

            if (!First_Name_TextBox.Text.All(char.IsLetter) || First_Name_TextBox.Text.Length == 0) {
                PopToastie("First name can not be blank and must only contain alphabet characters", ToastColors.ERROR, 5);
                return (0, 0.0m, 0.0m, false);
            }//if (!First_Name_TextBox.Text.All(char.IsLetter) || First_Name_TextBox.Text.Length == 0) {
            if (!Last_Name_TextBox.Text.All(char.IsLetter) || Last_Name_TextBox.Text.Length == 0) {
                PopToastie("Last name can not be blank and must only contain alphabet characters", ToastColors.ERROR, 5);
                return (0, 0.0m, 0.0m, false);
            }//if (!Last_Name_TextBox.Text.All(char.IsLetter) || Last_Name_TextBox.Text.Length == 0) {
            if (!int.TryParse(Age_TextBox.Text, out age) && Age_TextBox.Text.Length != 0 || age < 0 || Age_TextBox.Text.Equals("-1")) {
                PopToastie("Age must be a positive integer", ToastColors.ERROR, 5);
                return (0, 0.0m, 0.0m, false);
            }//if (!int.TryParse(Age_TextBox.Text, out age) && Age_TextBox.Text.Length != 0 || age < 0 || Age_TextBox.Text.Equals("-1")) {
            if (!decimal.TryParse(Hourly_Rate_TextBox.Text, out hourlyRate) || Hourly_Rate_TextBox.Text.Length == 0 || Hourly_Rate_TextBox.Text.Trim()[0] == '-') {
                PopToastie("Hourly rate must be a positive number", ToastColors.ERROR, 5);
                return (0, 0.0m, 0.0m, false);
            }//if (!decimal.TryParse(Hourly_Rate_TextBox.Text, out hourlyRate) || Hourly_Rate_TextBox.Text.Length == 0 || Hourly_Rate_TextBox.Text.Trim()[0] == '-') {
            if (Usual_Hours_TextBox.Text.Trim().Length != 0 && (!decimal.TryParse(Usual_Hours_TextBox.Text, out usualHours) || Usual_Hours_TextBox.Text.Trim()[0] == '-')) {
                PopToastie("Usual hours must be a positive number", ToastColors.ERROR, 5);
                return (0, 0.0m, 0.0m, false);
            }//if (Usual_Hours_TextBox.Text.Trim().Length != 0 && (!decimal.TryParse(Usual_Hours_TextBox.Text, out usualHours) || Usual_Hours_TextBox.Text.Trim()[0] == '-')) {

            return (Age_TextBox.Text.Length == 0 ? -1 : age, hourlyRate, usualHours, true);
        }//private (int, decimal, decimal, bool) IsValid() {

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

        private void UpdateBackButton(Color backgroundColor, Color fontColor) {
            Employee_Back_Secondary.Background = new SolidColorBrush(backgroundColor);
            Employee_Back_Secondary.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateBackButton(Color backgroundColor, Color fontColor) {

        private void UpdateBackground(Color backgroundColor) {
            Background_Grid.Background = new SolidColorBrush(backgroundColor);
        }//private void UpdateBackground(Color backgroundColor) {

        private void UpdateCalculateButton(Color backgroundColor, Color fontColor) {
            Calculate_Button.Background = new SolidColorBrush(backgroundColor);
            Calculate_Button.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateCalculateButton(Color backgroundColor, Color fontColor) {

        private void UpdateCreateEmployeeButton(Color backgroundColor, Color fontColor) {
            Employee_Create.Background = new SolidColorBrush(backgroundColor);
            Employee_Create.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateCreateEmployeeButton(Color backgroundColor, Color fontColor) {

        private void UpdateDeleteButton(Color backgroundColor, Color fontColor) {
            Employee_Delete_Secondary.Background = new SolidColorBrush(backgroundColor);
            Employee_Delete_Secondary.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateDeleteButton(Color backgroundColor, Color fontColor) {

        private void UpdateLeftBoxLabelsColor(Color backgroundColor, Color fontColor) {
            Last_Name_Label.Background = Age_Label.Background = Hourly_Rate_Label.Background = Usual_Hours_Label.Background = EmployeeID_LabelText.Background = First_Name_Label.Background = new SolidColorBrush(backgroundColor);
            Last_Name_Label.Foreground = Age_Label.Foreground = Hourly_Rate_Label.Foreground = Usual_Hours_Label.Foreground = EmployeeID_LabelText.Foreground = First_Name_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateLeftBoxLabelsColor(Color backgroundColor, Color fontColor) {

        private void UpdateLeftBoxSquare(Color backgroundColor) {
            Left_Box.Fill = new SolidColorBrush(backgroundColor);
        }//private void UpdateLeftBoxSquare(Color backgroundColor) {

        private void UpdateLeftBoxTextBoxColor(Color backgroundColor, Color fontColor) {
            EmployeeID_Label.Background = First_Name_TextBox.Background = Last_Name_TextBox.Background = Age_TextBox.Background = Hourly_Rate_TextBox.Background = Usual_Hours_TextBox.Background = new SolidColorBrush(backgroundColor);
            EmployeeID_Label.Foreground = First_Name_TextBox.Foreground = Last_Name_TextBox.Foreground = Age_TextBox.Foreground = Hourly_Rate_TextBox.Foreground = Usual_Hours_TextBox.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateLeftBoxTextBoxColor(Color backgroundColor, Color fontColor) {

        private void UpdateRequired_Label(Color fontColor) {
            Required_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateRequired_Label(Color fontColor) {

        private void UpdateRightBoxLabelsColor(Color backgroundColor, Color fontColor) {
            Salary_Label_Text.Background = Wage_Label_Text.Background = Right_Box_Employee_Labels.Background = Right_Box_Hours_Labels.Background = new SolidColorBrush(backgroundColor);
            Salary_Label_Text.Foreground = Wage_Label_Text.Foreground = Right_Box_Employee_Labels.Foreground = Right_Box_Hours_Labels.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateRightBoxLabelsColor(Color backgroundColor, Color fontColor) {
        private void UpdateRightBoxSquare(Color backgroundColor) {
            Right_Box.Fill = new SolidColorBrush(backgroundColor);
        }//private void UpdateRightBoxSquare(Color backgroundColor) {

        private void UpdateRightBoxTextBoxColor(Color backgroundColor, Color fontColor) {
            Hours_TextBox.Background = new SolidColorBrush(backgroundColor);
            Hours_TextBox.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateRightBoxTextBoxColor(Color backgroundColor, Color fontColor) {

        private void UpdateRightBoxWageLabel(Color backgroundColor, Color fontColor) {
            Wage_Label.Background = new SolidColorBrush(backgroundColor);
            Wage_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateRightBoxWageLabel(Color backgroundColor, Color fontColor) {

        private void UpdateRightSalaryLabel(Color backgroundColor, Color fontColor) {
            Salary_Label.Background = new SolidColorBrush(backgroundColor);
            Salary_Label.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateRightSalaryLabel(Color backgroundColor, Color fontColor) {

        private void UpdateSaveButton(Color backgroundColor, Color fontColor) {
            Employee_Save_Secondary.Background = new SolidColorBrush(backgroundColor);
            Employee_Save_Secondary.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateSaveButton(Color backgroundColor, Color fontColor) {

        private void UpdateUpdateButton(Color backgroundColor, Color fontColor) {
            Employee_Update_Secondary.Background = new SolidColorBrush(backgroundColor);
            Employee_Update_Secondary.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateUpdateButton(Color backgroundColor, Color fontColor) {

        private void UpdateUpdateEmployeeButton(Color backgroundColor, Color fontColor) {
            Employee_Update.Background = new SolidColorBrush(backgroundColor);
            Employee_Update.Foreground = new SolidColorBrush(fontColor);
        }//private void UpdateUpdateEmployeeButton(Color backgroundColor, Color fontColor) {

        /*================End of Helper functions=====================================*/
    }//public partial class MainWindow : Window {
}//namespace Project2 {