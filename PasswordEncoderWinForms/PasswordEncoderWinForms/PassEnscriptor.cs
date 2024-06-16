namespace PasswordEnscriptor
{
    public class PassEnscriptor : EncsriptorBase
    {
        int _p1Int;
        int _p2Int;
        public PassEnscriptor(int p1Int = 0, int p2Int = 0)
        {
            _p1Int = p1Int;
            _p2Int = p2Int;
        }
        public override string Enscript(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            string reversedText = new string(chars);
            return base.Enscript(reversedText);
        }
        protected override string CharEncoder(int someInt)
        {
            someInt = (someInt + _p1Int) * _p2Int - _p1Int;
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
            
            res = alphabet[rnd.Next(0, alphabet.Length)];
            if (rnd.Next(0,2) == 0) res = res.ToUpper();
            res += lowerCase;
            if (Char.IsUpper(someString)) res += "!";
            return res;
        }
    }
}
