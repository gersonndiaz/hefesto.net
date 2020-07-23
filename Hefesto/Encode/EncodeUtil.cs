using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Encode
{
    /// <summary>
    /// Esta clase contiene funciones que permiten codificar valores a diferentes tipos de codificación
    /// </summary>
    public class EncodeUtil
    {
        /// <summary>
        /// Función que permite codificar un string a base64
        /// </summary>
        /// <param name="text">string para ser codificado</param>
        /// <returns>Retorna la cadena de texto codificada en base64</returns>
        public static string encodeToBase64(string text)
        {
            string text_encode = "";

            if (String.IsNullOrEmpty(text))
            {
                return null;
            }

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            text_encode = Convert.ToBase64String(textAsBytes);

            return text_encode;
        }

        /// <summary>
        /// Función que permite decodificar base64 a texto
        /// </summary>
        /// <param name="encodedText">string Texto codificado en base64</param>
        /// <returns>Retorna una cadena de texto decodificada desde base64</returns>
        public static string decodeBase64ToString(string encodedText)
        {
            string text_decode = "";

            if (String.IsNullOrEmpty(encodedText))
            {
                return null;
            }

            /*if (encodedText.EndsWith("="))
            {
                encodedText = encodedText.TrimEnd('=');
            }*/

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            text_decode = Encoding.UTF8.GetString(textAsBytes);

            return text_decode;
        }

        /// <summary>
        /// Función que permite codificar string a HEX
        /// </summary>
        /// <param name="text">string con el texto a ser codificado</param>
        /// <returns>Retorna un string codificado en HEX</returns>
        public static string encodeToHex(string text)
        {
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(text))
            {
                return null;
            }

            var bytes = Encoding.Unicode.GetBytes(text);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        /// <summary>
        /// Función que permite decodificar desde HEX a texto
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>Retorna string decodificado desde HEX</returns>
        public static string decodeHexToString(string hexString)
        {
            if (String.IsNullOrEmpty(hexString))
            {
                return null;
            }

            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }

        /// <summary>
        /// Función que permite codificar un texto a binario
        /// </summary>
        /// <param name="text">string con texto a codificar a binario</param>
        /// <returns>Retorna string codificado a binario</returns>
        public static string encodeToBinary(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Función que permite decodificar un string binario a texto
        /// </summary>
        /// <param name="encodedText">string binario a decodificar</param>
        /// <returns>Retorna texto decodificado desde binario</returns>
        public static string decodeBinaryToString(string encodedText)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < encodedText.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(encodedText.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

    }
}
