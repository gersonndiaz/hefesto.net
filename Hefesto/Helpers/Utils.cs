using System;

namespace Hefesto.Helpers
{
    /// <summary>
    /// Esta clase contiene funciones adicionales
    /// </summary>
    /// <summary lang="en-US">
    /// This class contains aditional functions
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Permite calcular la cantidad de páginas en base al total de registros por página
        /// </summary>
        /// <param name="totalItems">Cantidad total de registros</param>
        /// <param name="itemsPerPage">Cantidad de registros para mostrar por página</param>
        /// <returns>Retorna cantidad de páginas</returns>
        public static int calculateTotalPages(int totalItems, int itemsPerPage)
        {
            try
            {
                int totalPages = totalItems / itemsPerPage;

                if (totalItems % itemsPerPage != 0)
                {
                    totalPages++; // Last page with only 1 item left
                }

                return totalPages;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
