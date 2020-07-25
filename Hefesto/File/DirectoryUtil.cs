using System;
using System.IO;

namespace Hefesto.File
{
    /// <summary>
    /// Esta clase permite manipular directorios
    /// </summary>
    /// <summary lang="en-US">
    /// This class allows you to manipulate directories
    /// </summary>
    public class DirectoryUtil
    {
        /// <summary>
        /// Comprueba si existe un directorio
        /// </summary>
        /// <param name="path">Ruta física del directorio</param>
        /// <returns></returns>
        public static bool existsDirectory(string path)
        {
            bool success = false;

            try
            {
                success = Directory.Exists(path);
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return success;
        }

        /// <summary>
        /// Permite crear un directorio si este no existe
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool createDirectory(string path)
        {
            bool success = false;

            try
            {
                if (!existsDirectory(path))
                {
                    DirectoryInfo d = Directory.CreateDirectory(path);
                    success = d.Exists;
                }
                else
                {
                    success = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return success;
        }

    }
}
