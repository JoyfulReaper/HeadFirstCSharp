using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberjacksAndFlapjacks
{
    class Lumberjack
    {
        public string Name { get; set; }

        private Stack<Flapjack> _flapjackStack = new();

        public Lumberjack(string name)
        {
            Name = name;
        }

        public void TakeFlapJack(Flapjack flapjack)
        {
            _flapjackStack.Push(flapjack);
        }

        public void EatFlapjacks()
        {
            Console.WriteLine($"{Name} is eating flapjacks");
            while(_flapjackStack.Count > 0)
            {
                Console.WriteLine($"{Name} ate a {_flapjackStack.Pop().ToString().ToLowerInvariant()} flapjack");
            }
        }
    }
}
