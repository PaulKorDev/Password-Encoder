using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEnscriptor
{
    public abstract class EncsriptorBase
    {
        protected string[] alphabet = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
        "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w",
        "x", "y", "z"};
        protected Random rnd = new Random();
        public virtual string Enscript(string text)
        {
            string encodedString = "";
            string encodedChar;


            foreach (char item in text.ToCharArray())
            {
                if (char.IsDigit(item))
                {
                    int digit = CharUnicodeInfo.GetDigitValue(item);
                    encodedChar = CharEncoder(digit);
                }
                else
                {
                    encodedChar = CharEncoder(item);
                }

                encodedString += encodedChar;
            }
            return encodedString;
        }
        abstract protected string CharEncoder(int someInt);
        abstract protected string CharEncoder(char someString);
    }
}
