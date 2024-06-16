using System;
using System.Globalization;

namespace PasswordEnscriptor
{
    public class LoginEnscriptor : EncsriptorBase
    {
        protected override string CharEncoder(int someInt)
        {
        
            string res = "";

            string multiplied = (someInt * 6).ToString();
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
            int index = Array.IndexOf(Program.alphabet, lowerCase);
            if (index == 0) index = 26;
            res = Program.alphabet[Program.rnd.Next(0, Program.alphabet.Length)];
            if (Program.rnd.Next(0, 3) == 0) res = res.ToUpper();
            res += Program.alphabet[index - 1];
            if (Char.IsUpper(someChar)) res += "_";
            return res;
        }
    }
}
