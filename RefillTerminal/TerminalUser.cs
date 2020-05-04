using System;
using System.Collections.Generic;
using System.Text;

namespace RefillTerminal
{
    public class TerminalUser : ITerminalUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountId { get; set; }

        public IPayment Payment { get; set; }

        public TerminalUser(string firstName, string lastName, ulong amount, string accountId)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountId = accountId;

            Payment = new Payment(this, accountId, amount);
        }
    }
}
