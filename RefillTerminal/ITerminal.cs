using System;
using System.Collections.Generic;
using System.Text;

namespace RefillTerminal
{
    public interface ITerminal
    {
        ITransaction CreateTransaction(IPayment payment);
        ITransaction PerformTransaction(ITransaction transaction);
        void PrintCheck(ITransaction transaction);
    }
}
