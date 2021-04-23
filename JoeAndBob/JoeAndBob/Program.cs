using System;

namespace JoeAndBob
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy Joe = new Guy()
            {
                Name = "Joe",
                Cash = 50
            };

            Guy Bob = new Guy()
            {
                Name = "Bob",
                Cash = 100
            };

            while (true)
            {
                Bob.WriteMyInfo();
                Joe.WriteMyInfo();
                Console.WriteLine();

                string howMuch = string.Empty;
                int result;

                while (!int.TryParse(howMuch, out result))
                {
                    Console.Write("Enter an amount: (blank line to quit)");
                    howMuch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(howMuch))
                    {
                        return;
                    }
                }

                Console.Write("Who should give the cash: ");
                string whichGuy = Console.ReadLine().ToLowerInvariant();

                try
                {
                    switch (whichGuy)
                    {
                        case "bob":
                            Joe.ReceiveCash(Bob.GiveCash(result));
                            break;
                        case "joe":
                            Bob.ReceiveCash(Joe.GiveCash(result));
                            break;
                        default:
                            Console.WriteLine("Please enter 'Joe' or 'Bob'");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }

        }
    }
}
