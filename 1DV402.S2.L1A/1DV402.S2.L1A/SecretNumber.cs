using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        
        private int _count;
        private int _number;
        public const int MaxNumberOfGuesses = 7;
        public SecretNumber()
        {
            Initialize();
        }
        public void Initialize() // sätter _count till 0 och ger _number ett random nummer mellan 1-101
        {
            _count = 0;
            Random random = new Random();
            _number = random.Next(1, 100);
        }

        public bool MakeGuess(int number)
        {
            if (_count == MaxNumberOfGuesses)
            { 
                throw new ApplicationException(); 
            }
            if (number < 1 || number > 100)
            {
                throw new ArgumentException();
            }

            int Number = _number;
            if (number == Number)
            {
                return true;
            }
            else
            {
                _count += 1;

                    Console.WriteLine("Du har förbrukat {0} gissning(ar) du har {1} gissningar kvar", _count, (7 - _count));
                    return false;

            }
            
        }
    }
}
