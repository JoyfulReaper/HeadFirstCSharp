using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Guy
    {
        private decimal _cash;

        public string Name { get; set; }
        public decimal Cash
        {
            get => _cash;
            set
            {
                if(value < 0)
                {
                    GiveCash(value);
                }
                else
                {
                    ReceiveCash(value);
                }
            }
        }

        /// <summary>
        /// Writes name and amount of cash to the console
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{Name} has {Cash:C2} bucks.";
        }

        /// <summary>
        /// Receive some cash, adding it to my wallet (or thowing ArgumentException)
        /// </summary>
        /// <param name="value">Amount of cash to receive</param>
        public void ReceiveCash(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{Name} says: {amount} isn't an amount I'll take");
            }

            _cash += amount;
        }

        /// <summary>
        /// Give some of the cash away, removing it from the wallet (Cash amount)
        /// Throws an ArgumentException if I'm broke
        /// </summary>
        /// <param name="value">Amount of cash to give away</param>
        /// <returns>
        /// The amount of cash removed from the wallet
        /// </returns>
        public decimal GiveCash(decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException($"{Name} says: {amount} isn't a valid amount");
            }

            if(amount > Cash)
            {
                throw new ArgumentException($"{Name} says: I don't have enough cash to give you {amount}");
            }

            _cash -= amount;
            return amount;
        }
    }
}
