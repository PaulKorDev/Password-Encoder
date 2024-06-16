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
