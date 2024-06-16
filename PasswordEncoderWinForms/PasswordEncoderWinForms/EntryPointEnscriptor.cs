using Microsoft.VisualBasic.Logging;
using System;

namespace PasswordEnscriptor
{
    public class EncoderManager
    {
        private static EncsriptorBase encoder = null;

        public static string EncodeLogin(string login, int num1, int num2)
        {
            encoder = new LoginEnscriptor(num1, num2);
            return encoder.Enscript(login);
        }
        public static string EncodePassword(string password, int num1, int num2) { 
            encoder = new PassEnscriptor(num1, num2);
            return encoder.Enscript(password);
        }

        public static string[] EncodeLoginAndPassword(string login, string pass, int num1, int num2, int num3, int num4) { 
            string[] result = new string[2];
            result[0] = EncodeLogin(login, num1, num2);
            result[1] = EncodePassword(pass, num3, num4);
            return result;
        }





    }
}
