using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.src {
    public class Employee {
        private static int ID = 0;
        private readonly int employeeID;
        private string firstName;
        private string lastName;
        private int? age;
        private decimal hourlyConsultingRate;
        private decimal? usualHours;

        public Employee(string firstName, string lastName, int? age, decimal hourlyConsultingRate, decimal? usualHours) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.hourlyConsultingRate = hourlyConsultingRate;
            this.usualHours = usualHours;
            this.employeeID = ++ID;
        }//public Employee(string firstName, string lastName, int age, double hourlyConsultingRate, double usualHours) {

        public Employee(Employee that) {
            this.firstName = that.firstName;
            this.lastName = that.lastName;
            this.age = that.age;
            this.hourlyConsultingRate = that.hourlyConsultingRate;
            this.usualHours = that.usualHours;
            this.employeeID = that.employeeID;
        }//public Employee(Employee that) {

        public int GetEmployeeID() {
            return employeeID;
        }//public int GetEmployeeID() {

        public string GetFirstName() {
            return this.firstName;
        }//public string GetFirstName() {

        public void SetFirstName(string firstName) {
            this.firstName = firstName;
        }//public void SetFirstName(string firstName) {

        public string GetLastName() {
            return this.lastName;
        }//public string GetLastName() {

        public void SetLastName(string lastName) {
            this.lastName = lastName;
        }//public void SetLastName(string lastName) {

        public int? GetAge() {
            return this.age;
        }//public int GetAge() {

        public void SetAge(int? age) {
            this.age = age;
        }//public void SetAge(int age) {

        public decimal GetHourlyConsultingRate() {
            return this.hourlyConsultingRate;
        }//public double GetHourlyConsultingRate() {

        public void SetHourlyConsultingRate(decimal hourlyConsultingRate) {
            this.hourlyConsultingRate = hourlyConsultingRate;
        }//public void SetHourlyConsultingRate(double hourlyConsultingRate) {

        public decimal? GetUsualHours() {
            return this.usualHours;
        }//public double GetUsualHours() {

        public void SetUsualHours(decimal? usualHours) {
            this.usualHours = usualHours;
        }//public void SetUsualHours(double usualHours) {

        override
        public bool Equals(object obj) {
            return obj != null && obj is Employee employee && this.age == employee.age && this.firstName.Equals(employee.firstName) && this.lastName.Equals(employee.lastName);
        }//public bool Equals(object obj) {

        override
        public int GetHashCode() {
            return employeeID;
        }//public int GetHashCode() {

        override
        public string ToString() {
            return employeeID + ": " + firstName + " " + lastName;
        }//public string ToString() {
    }//public class Employee {
}//namespace Project2.src {