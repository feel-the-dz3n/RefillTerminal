using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RefillTerminal
{
    public class Terminal : ITerminal
    {
        private void Log(string text = "", ConsoleColor? color = null)
        {
            var oldColor = Console.ForegroundColor;

            if (color != null)
            {
                Console.ForegroundColor = (ConsoleColor)color;
            }

            Console.WriteLine(text);

            if (color != null)
            {
                Console.ForegroundColor = oldColor;
            }
        }

        private void Print(ITransaction transaction)
        {
            Log($"  [TRANSACTION] IsPerformed: {transaction.IsPerformed}");
            Log($"  [TRANSACTION] IsSuccessful: {transaction.IsSuccessful}");
            Log($"  [TRANSACTION] Payment:");
            Print(transaction.Payment);
        }

        private void Print(IPayment payment)
        {
            Log($"    [PAYMENT] Account ID: {payment.AccountId}");
            Log($"    [PAYMENT] Payer: {payment.Payer.FirstName} {payment.Payer.LastName}");
            Log($"    [PAYMENT] Amount: {payment.CashAmount}");
        }

        public ITransaction CreateTransaction(IPayment payment)
        {
            Log($"[TERMINAL] Creating a transaction for payment:", ConsoleColor.White);
            Print(payment);
            Log($"[TERMINAL] P.S.: Now terminal user should perform a transaction");
            return new Transaction(payment);
        }

        public ITransaction PerformTransaction(ITransaction transaction)
        {
            Log($"[TERMINAL] PERFORMING TRANSACTION:", ConsoleColor.Yellow);
            Print(transaction);

            if (transaction.IsPerformed)
            {
                transaction.IsSuccessful = false;
            }
            else
            {
                transaction.IsPerformed = true;
                transaction.IsSuccessful = true;
            }

            Log($"!!! BRUH. Sent ${transaction.Payment.CashAmount} to {transaction.Payment.AccountId}", ConsoleColor.Green);

            return transaction;
        }

        public void PrintCheck(ITransaction transaction)
        {
            Log("[TERMINAL] Asked to print a check for a transaction:", ConsoleColor.White);
            Print(transaction);
            Log();
            Log($"===============================", ConsoleColor.Yellow);
            Log($"             CHECK             ", ConsoleColor.Yellow);
            Log($"===============================", ConsoleColor.Yellow);
            Log($" Amount: ${transaction.Payment.CashAmount}", ConsoleColor.Yellow);
            Log($" Payer: {transaction.Payment.Payer.FirstName} {transaction.Payment.Payer.LastName}", ConsoleColor.Yellow);
            if (transaction.IsPerformed)
                if (transaction.IsSuccessful)
                    Log($" Transaction successful", ConsoleColor.Green);
                else
                    Log($" Transaction failed", ConsoleColor.Red);
            else
                Log($" Unable to perform a transaction", ConsoleColor.Red);
            Log($"===============================", ConsoleColor.Yellow);
        }
    }
}
