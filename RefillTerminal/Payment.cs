namespace RefillTerminal
{
    public class Payment : IPayment
    {
        public IPayer Payer { get; set; }

        public ulong CashAmount { get; set; }

        public string AccountId { get; set; }

        public Payment() { }

        public Payment(IPayer payer, string accountId, ulong cashAmount) 
        {
            Payer = payer;
            CashAmount = cashAmount;
            AccountId = accountId;
        }
    }
}
