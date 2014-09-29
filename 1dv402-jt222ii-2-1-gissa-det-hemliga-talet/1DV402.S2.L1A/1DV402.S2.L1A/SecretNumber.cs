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
        public void Initialize() // sätter _count till 0 och ger _number ett random nummer mellan 1-100
        {
            _count = 0;
            Random random = new Random();
            _number = random.Next(1, 101);
        }
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                Console.WriteLine("Du har slut på gissningar - du är sämst");
                throw new ApplicationException();
            }
            _count++;
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();               
            }

            if (number == _number)
            {

                Console.WriteLine("{0} var rätt!", number);
                return true;
            }
            if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Var god försök igen. Du har {1} gissningar kvar", number, (MaxNumberOfGuesses - _count));
                return false;
            }
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Var god försök igen. Du har {1} gissningar kvar", number, (MaxNumberOfGuesses - _count));
                return false;
            }
            else
                System.Console.WriteLine("Det hemliga talet är {0}.", _number);
                return false;   
        }
    }
}
