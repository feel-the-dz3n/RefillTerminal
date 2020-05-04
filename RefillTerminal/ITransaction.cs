namespace RefillTerminal
{
    public interface ITransaction
    {
        IPayment Payment { get; }
        bool IsPerformed { get; set; }
        bool IsSuccessful { get; set; }
    }
}
