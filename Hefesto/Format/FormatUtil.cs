using System;

namespace Hefesto.Format
{
    public class FormatUtil
    {

        /// <summary>
        /// Formatear Rut Chile asignando puntos y guión
        /// </summary>
        /// <param name="rut">string texto con el rut a formatear</param>
        /// <returns>Retorna RUT formateado</returns>
        [Obsolete("Este método será movido a Rut.class", false)]
        public static string formatRutChile(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Trim();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");

                if (rut.StartsWith("0"))
                {
                    rut = rut.Substring(1);
                }

                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        /// <summary>
        /// Retorna el rut sin formato (Quita Puntos y Guiones)
        /// </summary>
        /// <param name="rut">string con el valor del rut a quitar formato</param>
        /// <returns>Retorna RUTsin formato</returns>
        [Obsolete("Este método será movido a Rut.class", false)]
        public static string removeFormatRutChile(string rut)
        {
            rut = rut.ToUpper();
            rut = rut.Trim();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");

            return rut;
        }

    }
}
