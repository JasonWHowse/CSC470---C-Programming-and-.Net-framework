using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.src {
    public class Employee {
        private string firstName;
        private string lastName;
        private int age;
        private double hourlyConsultingRate;
        private double usualHours;

        public Employee(string firstName, string lastName, int age, double hourlyConsultingRate, double usualHours) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.hourlyConsultingRate = hourlyConsultingRate;
            this.usualHours = usualHours;
        }//public Employee(string firstName, string lastName, int age, double hourlyConsultingRate, double usualHours) {

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

        public int GetAge() {
            return this.age;
        }//public int GetAge() {

        public void SetAge(int age) {
            this.age = age;
        }//public void SetAge(int age) {

        public double GetHourlyConsultingRate() {
            return this.hourlyConsultingRate;
        }//public double GetHourlyConsultingRate() {

        public void SetHourlyConsultingRate(double hourlyConsultingRate) {
            this.hourlyConsultingRate = hourlyConsultingRate;
        }//public void SetHourlyConsultingRate(double hourlyConsultingRate) {

        public double GetUsualHours() {
            return this.usualHours;
        }//public double GetUsualHours() {

        public void SetUsualHours(double usualHours) {
            this.usualHours = usualHours;
        }//public void SetUsualHours(double usualHours) {
    }//public class Employee {
}//namespace Project2.src {