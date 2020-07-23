using System.Text;

namespace Hefesto.Encrypt
{
    /// <summary>
    /// Esta clase contiene funciones que permiten encriptar datos
    /// </summary>
    public class EncryptUtil
    {

        /// <summary>
        /// Encripta una cadena de texto a SHA512
        /// </summary>
        /// <param name="text">string a encriptar en SHA512</param>
        /// <returns>Retorna una cadena con texto encriptado con SHA512</returns>
        public static string SHA512(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

    }
}
