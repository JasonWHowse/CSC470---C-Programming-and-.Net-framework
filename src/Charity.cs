﻿namespace Lab4.src {
    public class Charity {

        private string donation;
        private string upKeep;
        private string charityValue;
        private static decimal totalCharity;
        private static decimal totalUpKeep;
        private static decimal totalDonations;

        public static void SetValues(Charity charity, decimal donation) {
            charity.donation = donation.ToString("C2");
            charity.upKeep = (donation * .17m).ToString("C2");
            charity.charityValue = (donation * .83m).ToString("C2");
            totalCharity += donation * .83m;
            totalUpKeep += donation * .17m;
            totalDonations += donation;
        }//public static void SetValues(Charity charity, int value) {

        public string GetDonation() {
            return donation;
        }//public string GetTotalValue() {

        public string GetUpKeep() {
            return upKeep;
        }//public string GetUpKeep() {

        public string GetCharityValue() {
            return charityValue;
        }//public string GetcharityValue() {

        public static string GetTotalCharity() {
            return totalCharity.ToString("C2");
        }//public static string getTotalCharity() {

        public static string GetTotalUpKeep() {
            return totalUpKeep.ToString("C2");
        }//public static string GetTotalUpKeep() {

        public static string GetTotalDonations() {
            return totalDonations.ToString("C2");
        }//public static string GetTotalDonations() {
    }//public class Charity {   
}//namespace Lab4.src {
