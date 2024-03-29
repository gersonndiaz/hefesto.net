﻿using System;

namespace Hefesto.Rut
{
    /// <summary>
    /// Clase con funcionalidades específicas para el RUT de Chile
    /// </summary>
    public class Rut
    {
        /// <summary>
        /// Formatear Rut Chile asignando puntos y guión
        /// </summary>
        /// <param name="rut">string texto con el rut a formatear</param>
        /// <returns>Retorna RUT formateado</returns>
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
        public static string removeFormatRutChile(string rut)
        {
            rut = rut.ToUpper();
            rut = rut.Trim();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");

            return rut;
        }

        /// <summary>
        /// Genera dígito Verificador a partir de la mantisa del RUT
        /// </summary>
        /// <param name="rut">Ej: 11111111</param>
        /// <returns></returns>
        public static string calcularDv(int rut)
		{
			int suma = 0;
			int multiplicador = 1;
			while (rut != 0)
			{
				multiplicador++;
				if (multiplicador == 8)
					multiplicador = 2;
				suma += (rut % 10) * multiplicador;
				rut = rut / 10;
			}
			suma = 11 - (suma % 11);
			if (suma == 11)
			{
				return "0";
			}
			else if (suma == 10)
			{
				return "K";
			}
			else
			{
				return suma.ToString();
			}
		}

        /// <summary>
        /// Comprueba que el valor ingresado sea un RUT chileno valido
        /// </summary>
        /// <param name="rut">string con el valor del RUT a validar</param>
        /// <returns>true || false</returns>
        public static bool validar(string rut)
        {
            bool validacion = false;
            
            try
            {
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
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e}");
                validacion = false;
            }

            return validacion;
        }
    }
}
