using System;
using System.Text.RegularExpressions;

namespace Hefesto.Validation
{
    /// <summary>
    /// Esta clase permite realizar validaciones de tipos de datos, comprobando si son validos
    /// </summary>
    /// <summary lang="en-US">
    /// This class perform validations over datatypes, check if it is valid
    /// </summary>
    public class DataTypeValidation
    {

        /// <summary>
        /// Comprueba que la estructura del email sea valida
        /// </summary>
        /// <summary lang="en-US">
        /// Check that email structure is valid
        /// </summary>
        /// <remarks>
        /// Esta función permite comprobar por medio de una expresión regular si el correo electrónico es valido
        /// </remarks>
        /// <remarks lang="en-US">
        /// This function allows to check using regular expression if an email is valid
        /// </remarks>
        /// <param name="emailAdress">string Dirección de correo electrónico</param>
        /// <param name="emailAdress" lang="en-US">string Email Address</param>
        /// <example>
        /// <code>
        /// bool isValid = DataTypeValidation.checkEmailAddress("name@email.cl");
        /// string msg = (isValid) ? "OK" : "ERR";
        /// Console.WriteLine(msg);
        /// </code>
        /// </example>
        /// <returns>true || false</returns>
        public static bool checkEmailAddress(string emailAdress)
        {
            bool success = false;

            Regex expresion = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (expresion.IsMatch(emailAdress))
            {
                success = true;
            }
            else
            {
                success = false;
            }

            return success;

        }

        /// <summary>
        /// Comprueba que el valor ingresado corresponda a un GUID valido
        /// </summary>
        /// <param name="checkGuid">string GUID</param>
        /// <returns>true || false</returns>
        public static bool checkGuid(string checkGuid)
        {
            bool success = false;

            if (string.IsNullOrEmpty(checkGuid))
            {
                success = false;
            }
            else
            {
                Guid resultGuid;
                success = Guid.TryParse(checkGuid, out resultGuid);
            }

            return success;
        }

        /// <summary>
        /// Comprueba que el valor ingresado sea un RUT chileno valido
        /// </summary>
        /// <param name="rut">string con el valor del RUT a validar</param>
        /// <returns>true || false</returns>
        public static bool checkRutChile(string rut)
        {

            bool validacion = false;
            rut = rut.ToUpper();
            rut = rut.Trim();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                validacion = true;
            }
            return validacion;
        }

        /// <summary>
        /// Comprueba que el valor ingresado corresponda a un valor numérico
        /// </summary>
        /// <param name="valor">string con el valor a comprobar</param>
        /// <returns>true or false</returns>
        public static bool checkNumber(string valor)
        {
            bool success = false;

            Regex expresion = new Regex(@"^-*[0-9,\.]+$");

            if (expresion.IsMatch(valor))
            {
                success = true;
            }
            else
            {
                success = false;
            }

            return success;

        }

    }
}
