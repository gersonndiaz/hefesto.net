using System.Text.RegularExpressions;

namespace Hefesto.Patente
{
    /// <summary>
    /// Çlase con funciones [Experimentales] de expresión regular para placas patente chilenas
    /// </summary>
    public class PatenteChile
    {
        /// <summary>
        /// Retorna la patente eliminndo caracteres que no sorman parte de la placa patente
        /// </summary>
        /// <param name="patente"></param>
        /// <returns></returns>
        public static string Format(string patente)
        {
            // Remover cualquier carácter no alfanumérico
            patente = Regex.Replace(patente, "[^a-zA-Z0-9]", "");
            patente = patente.Replace("·", "");

            return patente.ToUpper();
        }

        /// <summary>
        /// Valida una placa patente
        /// </summary>
        /// <param name="patente"></param>
        /// <returns></returns>
        public static bool Validar(string patente)
        {
            // Remover cualquier carácter no alfanumérico
            patente = Regex.Replace(patente, @"[^A-Z0-9]", "");
            patente = patente.Replace("·", "");

            // Formato: AA·10·00
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{2}\d{2}$"))
            {
                return true; // Formato válido: AA·10·00
            }

            // Formato: BB·BB·10
            if (Regex.IsMatch(patente, @"^[A-Z]{2}[A-Z]{2}\d{2}$"))
            {
                return true; // Formato válido: BB·BB·10
            }

            // Formato: PR·206 (PROVICIONAL)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{3}$"))
            {
                return true; // Formato válido: PR·206
            }

            // Formato: RP·2001 (CARABINEROS DE CHILE)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{4}$"))
            {
                return true; // Formato válido: RP·2001
            }

            // Formato: Z·3750 (CARABINEROS DE CHILE)
            if (Regex.IsMatch(patente, @"^[A-Z]\d{4}$"))
            {
                return true; // Formato válido: Z·3750
            }

            // Formato: BB·LB·30 (TAXI)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}[A-Z][A-Z]\d{2}$"))
            {
                return true; // Formato válido: BB·LB·30
            }

            // Formato: CD·0510 (CUERPO DIPLOMATICO)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{4}$"))
            {
                return true; // Formato válido: CD·0510
            }

            // Formato: BB·WB·40 (TAXI COLECTIVO)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}[A-Z]\d{2}$"))
            {
                return true; // Formato válido: BB·WB·40
            }

            // Formato: BG·BB·70 (BUS TRANSANTIAGO)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}[A-Z]{2}\d{2}$"))
            {
                return true; // Formato válido: BG·BB·70
            }

            // Formato: VPU·184 (REMOLQUE MUNICIPAL)
            //if (Regex.IsMatch(patente, @"^[A-Z]{3}\d{2}$"))
            if (Regex.IsMatch(patente, @"^[A-Z]{3}·?\d{3}$"))
            {
                return true; // Formato válido: VPU·184
            }

            // Formato: BC·BB·60 (RADIOTAXI - TURISMO)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}[A-Z]{2}\d{2}$"))
            {
                return true; // Formato válido: BC·BB·60
            }

            // Formato: JA·10·00 (REMOLQUE)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{2}\d{2}$"))
            {
                return true; // Formato válido: JA·10·00
            }

            // Formato: WS·19·00 (ZONA FRANCA)
            if (Regex.IsMatch(patente, @"^[A-Z]{2}\d{2}\d{2}$"))
            {
                return true; // Formato válido: WS·19·00
            }

            // Si ninguno de los formatos coincide, la patente no es válida
            return false;
        }

        /// <summary>
        /// Permite identificar el tipo de placa patente
        /// </summary>
        /// <param name="patente"></param>
        /// <returns></returns>
        public static TipoPatente IdentificarTipoPatente(string patente)
        {
            // Eliminar los puntos medios y guiones de la patente
            string patenteSinSeparadores = patente.Replace("·", "")
                                                  .Replace("-", "")
                                                  .Replace("*", "")
                                                  .Replace("\n", "")
                                                  .Replace("\t", "")
                                                  .Replace("%20", "")
                                                  .Replace(" ", "");

            // Expresión regular para validar los diferentes formatos de patente chilena
            string patronNormal = @"^([A-Z]{2}\d{2}\d{2})$|^([A-Z]{2}[A-Z]{2}\d{2})$|^([A-Z]{2}\d{2})$|^([A-Z]{1}[A-Z]{1}\d{3})$|^([A-Z]{1}\d{3})$|^([A-Z]{1}\d{2}[A-Z]{1}\d{2})$";
            string patronCarabineros = @"^([A-Z]{1}[A-Z]{1}\d{1}[A-Z]{1}\d{2})$|^([A-Z]{2}[A-Z]{1}\d{1}[A-Z]{1}\d{2})$";
            string patronProvisional = @"^PR·\d{3}$";
            string patronCuerpoDiplomatico = @"^CD·\d{4}$";
            string patronRemolqueMunicipal = @"^VPU·\d{3}$";
            // Agrega más patrones según los diferentes tipos de placas especiales

            // Realizar la validación usando las expresiones regulares
            if (Regex.IsMatch(patenteSinSeparadores, patronCarabineros))
            {
                return TipoPatente.Carabineros;
            }
            else if (Regex.IsMatch(patenteSinSeparadores, patronProvisional))
            {
                return TipoPatente.Provisional;
            }
            else if (Regex.IsMatch(patenteSinSeparadores, patronCuerpoDiplomatico))
            {
                return TipoPatente.CuerpoDiplomatico;
            }
            else if (Regex.IsMatch(patenteSinSeparadores, patronRemolqueMunicipal))
            {
                return TipoPatente.RemolqueMunicipal;
            }
            else if (Regex.IsMatch(patenteSinSeparadores, patronNormal))
            {
                return TipoPatente.Normal;
            }
            else
            {
                return TipoPatente.Normal; // Si la patente no coincide con ningún patrón, se considera normal
            }
        }

        public enum TipoPatente
        {
            Normal,
            Carabineros,
            Provisional,
            CuerpoDiplomatico,
            RemolqueMunicipal,
            // Agrega más tipos según tus necesidades
        }
    }
}
