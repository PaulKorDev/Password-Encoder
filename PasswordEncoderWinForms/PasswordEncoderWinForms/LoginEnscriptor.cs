using System;
using System.Globalization;

namespace PasswordEnscriptor
{
    public class LoginEnscriptor : EncsriptorBase
    {
        int _lInt;
        int _cInt;
        public LoginEnscriptor(int cInt = 0, int lInt = 0)
        {
            _cInt = cInt;
            _lInt = lInt;
        }
        protected override string CharEncoder(int someInt)
        {
        
            string res = "";

            string multiplied = (someInt * _lInt).ToString();
            int oneNum = 0;
            string oneNumStr = "";
            foreach (char item in multiplied)
                oneNum += CharUnicodeInfo.GetDigitValue(item);
            oneNumStr = oneNum.ToString();
            res = oneNumStr[oneNumStr.Length - 1].ToString() + multiplied[multiplied.Length - 1].ToString();
            return res;
        }
        protected override string CharEncoder(char someChar)
        {
            switch (someChar)
            {
                case '!': return "?";
                case '@': return "&";
                case '#': return "=";
                case '_': return "|";
                case '-': return "+";
                case '=': return "-";
                case '&': return "@";
                case '$': return "%";
                case '.': return ",";
            }

            string res = "";
            string lowerCase = someChar.ToString().ToLower();
            res = alphabet[rnd.Next(0, alphabet.Length)];
            if (rnd.Next(0, 3) == 0) res = res.ToUpper();
            int newindex = Array.IndexOf(alphabet, lowerCase) + _cInt;
            if (newindex < 0)
            {
                newindex += alphabet.Length;
            }
            else if (newindex >= alphabet.Length)
            {
                newindex -= alphabet.Length;
            }
           
            res += alphabet[newindex];
            if (Char.IsUpper(someChar)) res += "_";
            return res;
        }
    }
}
