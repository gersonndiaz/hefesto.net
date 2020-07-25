using System;

namespace Hefesto.File
{
    /// <summary>
    /// Esta clase contiene funciones para trabajar con archivos
    /// </summary>
    /// <summary lang="en-US">
    /// This class contains functions for working with files
    /// </summary>
    public class FileUtil
    {
        /// <summary>
        /// Comprueba si existe un archivo
        /// </summary>
        /// <param name="path">Ruta física del archivo</param>
        /// <returns></returns>
        public static bool existsFile(string path)
        {
            bool success = false;

            try
            {
                success = System.IO.File.Exists(path);
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return success;
        }

        /// <summary>
        /// Permite eliinar un archivo
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool deleteFile(string path)
        {
            bool success = false;

            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    success = System.IO.File.Exists(path);
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

        /// <summary>
        /// Mueve un archivo de directorio
        /// </summary>
        /// <param name="currentPath">Ruta física actual del archivo</param>
        /// <param name="newPath">Ruta física a la cual se desea mover el archivo</param>
        /// <returns></returns>
        public static bool moveFile(string currentPath, string newPath)
        {
            bool success = false;

            try
            {
                if (!System.IO.File.Exists(newPath))
                {
                    System.IO.File.Move(currentPath, newPath);
                }
                
                success = System.IO.File.Exists(newPath);
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return success;
        }

        /// <summary>
        /// Copia un archivo a otro directorio
        /// </summary>
        /// <param name="currentPath">Ruta física actual del archivo</param>
        /// <param name="newPath">Ruta física a la cual se desea copiar el archivo</param>
        /// <returns></returns>
        public static bool copyFile(string currentPath, string newPath)
        {
            bool success = false;

            try
            {
                if (!System.IO.File.Exists(newPath))
                {
                    System.IO.File.Copy(currentPath, newPath);
                }

                success = System.IO.File.Exists(newPath);
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return success;
        }
    }
}
