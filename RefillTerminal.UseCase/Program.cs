using System;

namespace RefillTerminal.UseCase
{
    class Program
    {
        static string Ask(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            var firstName = Ask("First name: ");
            var lastName = Ask("Last name: ");
            var accountId = Ask("Account ID: ");
            var amount = ulong.Parse(Ask("Amount: "));

            Console.WriteLine("\nUse case: begin\n");

            var user = new TerminalUser(firstName, lastName, amount, accountId); 
            var terminal = new Terminal();
            var transaction = terminal.CreateTransaction(user.Payment);
            terminal.PerformTransaction(transaction);
            terminal.PrintCheck(transaction);

            Console.WriteLine("\nUse case: end");
            Console.WriteLine(DateTime.Now - startTime);
        }
    }
}
