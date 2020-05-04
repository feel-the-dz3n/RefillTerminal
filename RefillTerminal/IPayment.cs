namespace RefillTerminal
{
    public interface IPayment
    {
        IPayer Payer { get; }
        string AccountId { get; }
        ulong CashAmount { get; }
    }
}
