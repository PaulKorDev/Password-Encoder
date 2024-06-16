using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEnscriptor
{
    public class PassEnscriptor : EncsriptorBase
    {
        public override string Enscript(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            string reversedText = new string(chars);
            return base.Enscript(reversedText);
        }
        protected override string CharEncoder(int someInt)
        {
            someInt = (someInt + 1) * 5 - 1;
            return someInt.ToString();    
        }

        protected override string CharEncoder(char someString)
        {
            switch (someString)
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
            string lowerCase = someString.ToString().ToLower();
            
            res = Program.alphabet[Program.rnd.Next(0, Program.alphabet.Length)];
            if (Program.rnd.Next(0,2) == 0) res = res.ToUpper();
            res += lowerCase;
            if (Char.IsUpper(someString)) res += "!";
            return res;
        }
    }
}
