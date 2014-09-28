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
            _count++;
            if (number < 1 || number > 100)
            {
                throw new ArgumentException();
            }

            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number == _number)
            {
                return true;
            }
            if (number > _number)
            {
                return false;
            }
            if (number < _number)
            {   
                return false;
            }

                return false;

            
        }
    }
}
