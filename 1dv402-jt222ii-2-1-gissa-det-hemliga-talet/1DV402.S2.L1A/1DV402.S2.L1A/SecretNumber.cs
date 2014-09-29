using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        private int _count;  // antal gissningar gjordas
        private int _number; // hemliga numret förvaras här
        public const int MaxNumberOfGuesses = 7;
        public SecretNumber() // startar initialize
        {
            Initialize();
        }
        public void Initialize() // sätter _count till 0 och ger _number ett random nummer mellan 1-100
        {
            _count = 0;
            Random random = new Random();
            _number = random.Next(1, 101); //_number får ett slumpvalt tal från ett till 100
        }
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)   //om _count(antal försök) överstiger eller är 7 så kastas ett undantag. Annars _count + 1 och man har ett till försök
            {
                throw new ApplicationException();
            }
            _count++;
            if (number == _number)              // Jämför numret användaren skriver in med det hemliga talet
            {
                Console.WriteLine("GRATTIS, {0} var rätt! Du klarade det på {1} försök!", number, _count);
                return true;
            }
            if (_count == MaxNumberOfGuesses)   // om _count är lika stort som MaxNumberOfGuesses så har man förbrukat alla sina försök
            {
                Console.WriteLine("Du har förbrukat alla dina {0} försök. Det rätta svaret var: {1}", MaxNumberOfGuesses, _number);
                return false;
            }
            if (number < 1 || number > 100)    //om man skiver in ett nummer mindre än 1 eller större än 100 kastas ett undantag
            {
                throw new ArgumentOutOfRangeException();
            }
            if (number > _number) // om numret man skrev in är större än det hemliga talet säger konsollen att det var för högt och även hur många försök kvar man har
            {
                Console.WriteLine("{0} är för högt. Var god försök igen. Du har {1} gissningar kvar", number, (MaxNumberOfGuesses - _count));
                return false;
            }
            if (number < _number) // samma som ovan fast för nummer mindre än det hemliga numret
            {
                Console.WriteLine("{0} är för lågt. Var god försök igen. Du har {1} gissningar kvar", number, (MaxNumberOfGuesses - _count));
                return false;
            }
            return false;
        }
    }
}
