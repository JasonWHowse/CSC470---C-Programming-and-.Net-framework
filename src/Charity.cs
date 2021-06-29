namespace Lab4.src {
    public class Charity {

        private string donation;
        private string upKeep;
        private string charityValue;
        private static decimal totalCharity;
        private static decimal totalUpKeep;
        private static decimal totalDonations;

        public static void SetValues(Charity charity, decimal donation) {
            charity.donation = donation.ToString("C2");
            totalDonations += donation;
            decimal newDonation = Splitter(ref donation);
            charity.upKeep = donation.ToString("C2");
            totalUpKeep += donation;
            charity.charityValue = newDonation.ToString("C2");
            totalCharity += newDonation;
        }//public static void SetValues(Charity charity, int value) {

        private static decimal Splitter(ref decimal donation) {
            decimal output = donation;
            donation = 0.17m * donation;
            return output - donation;
        }//private static void Splitter(ref decimal donation) {

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
