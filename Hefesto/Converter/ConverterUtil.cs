using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Converter
{
    /// <summary>
    /// Esta clase permite convertir tipos de datos
    /// </summary>
    /// <summary lang="en-US">
    /// This class allows converting data types
    /// </summary>
    public class ConverterUtil
    {
        /// <summary>
        /// Permite convertir una cadena de texto en formato DateTime
        /// </summary>
        /// <param name="text">Cadena de texto</param>
        /// <returns>DateTime</returns>
        public static DateTime textToDateTime(string text)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(text);
                return dateTime;
            }
            catch(Exception e)
            {
                throw new Exception("Error", e);
            }
        }

        /// <summary>
        /// Permite convertir una cadena de texto en un número entero
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int textToInt(string text)
        {
            try
            {
                int v = int.Parse(text);
                return v;
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }
        }
    }
}
