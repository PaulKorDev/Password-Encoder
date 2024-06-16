using System;
using System.Text;

namespace PasswordEnscriptor
{
    internal class Program
    {
        static public string[] alphabet = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
        "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w",
        "x", "y", "z"};
        static public Random rnd = new Random();

        static void Main(string[] args)
        {
            string[] texts;
            string text;
            EncsriptorBase encoder = null;
            LoginEnscriptor loginEnscriptor = new LoginEnscriptor();
            PassEnscriptor passEnscriptor = new PassEnscriptor();
            while (true)
            {
                texts = null;
                Console.Write("Write text: ");
                text = Console.ReadLine();
                //NEW
                if (text.Contains(" "))
                    texts = text.Split(' ');
                //
                bool isSelected = false;
                do
                {
                    Console.Write("Select L(1) or P(2): ");
                    int.TryParse(Console.ReadLine(), out int select);
                    switch (select)
                    {
                        case 1: encoder = loginEnscriptor; isSelected = true; break;
                        case 2: encoder = passEnscriptor; isSelected = true; break;
                        default: break;
                    }

                } while (!isSelected);

                //NEW
                if (texts != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var word in texts)
                    {
                        stringBuilder.Append(encoder.Enscript(word)).Append(" ");
                    }
                    isSelected = false;
                    Console.WriteLine(stringBuilder.ToString());

                    //
                } else
                {
                    string result = encoder.Enscript(text);
                    isSelected = false;
                    Console.WriteLine(result);
                }
            }


        }





    }
}
