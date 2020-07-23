using System;
using System.Security.Cryptography;
using System.Text;

namespace Hefesto.Generator
{
    public class GeneratorUtil
    {

        /// <summary>
        /// Genera un código alfanumerico
        /// </summary>
        /// <param name="lenght">Largo del código generado</param>
        /// <returns>Retorna string con el valor generado</returns>
        public static string codeGenerator(int lenght)
        {
            Random obj = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-~@";
            int size = chars.Length;
            char c;
            string new_string = string.Empty;
            for (int i = 0; i < lenght; i++)
            {
                c = chars[obj.Next(lenght)];
                new_string += c.ToString();
            }
            return new_string;
        }

        /// <summary>
        /// Genera un código Random único
        /// </summary>
        /// <param name="maxSize">int Capacidad del string</param>
        /// <returns>Retorna string con valor generado</returns>
        public static string getUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

    }
}
