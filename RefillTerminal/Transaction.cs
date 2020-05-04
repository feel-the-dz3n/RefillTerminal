using System;
using System.Collections.Generic;
using System.Text;

namespace RefillTerminal
{
    public class Transaction : ITransaction
    {
        public IPayment Payment { get; set; }

        public bool IsPerformed { get; set; }

        public bool IsSuccessful { get; set; }

        public Transaction(IPayment payment)
        {
            this.Payment = payment;
        }
    }
}
