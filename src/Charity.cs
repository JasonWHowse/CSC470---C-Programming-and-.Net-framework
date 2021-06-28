namespace Lab4.src {
    public class Charity {

        private string donation;
        private string upKeep;
        private string charityValue;
        private static decimal totalCharity;

        public static void SetValues(Charity charity, decimal donation) {
            charity.donation = donation.ToString();
            charity.upKeep = (donation * .17m).ToString();
            charity.charityValue = (donation * .83m).ToString();
            totalCharity += donation * .83m;
        }//public static void SetValues(Charity charity, int value) {

        public string GetDonation() {
            return donation;
        }//public string GetTotalValue() {

        public string GetUpKeep() {
            return upKeep;
        }//public string GetUpKeep() {

        public string GetcharityValue() {
            return charityValue;
        }//public string GetcharityValue() {

        public static string getTotalCharity() {
            return totalCharity.ToString();
        }//public static string getTotalCharity() {
    }//public class Charity {   
}//namespace src{
