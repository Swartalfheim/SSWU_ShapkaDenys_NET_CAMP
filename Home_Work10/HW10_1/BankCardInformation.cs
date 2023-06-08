namespace HW10_1
{
    public class BankCardInformation
    {
        public BankCardInformation(List<ulong> bankСard)
        {
            Bank = new HashSet<ulong>(bankСard);
        }

        public HashSet<ulong> Bank { get; private set; }
        public void PrintInfo()
        {
            CardProcessing cardProcessing = new CardProcessing();
            cardProcessing.Result(Bank);
        }
    }
}
