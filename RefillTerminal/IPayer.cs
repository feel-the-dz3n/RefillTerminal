using System;
using System.Collections.Generic;
using System.Text;

namespace RefillTerminal
{
    public interface IPayer : IPerson
    {
        IPayment Payment { get; }
    }
}
