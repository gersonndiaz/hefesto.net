using System;
using System.Collections.Generic;
using System.Linq;

namespace Hefesto.Html
{
    public class HtmlUtil
    {
        /// <summary>
        /// Obtiene una cadena de texto que genera un <b>Input</b> o <b>Textarea</b> que se genera con los atributos que se ingresan en la función
        /// <br />
        /// <code>
        /// public void GetTagsTest()
        /// {
        ///     string id = "ID";
        ///     string name = "nombre";
        ///     string type = "text";
        ///     string value = "Gerson Díaz";
        ///     bool? required = true;
        ///     string placeholder = "Nombre de Usuario";
        ///     List<string> classes = new List<string>();
        ///     classes.Add("form-control");
        ///     classes.Add("form-control-lg");
        ///     classes.Add("text-center");
        ///
        ///     Dictionary<string, string> attributes = new Dictionary<string, string>();
        ///     attributes.Add("data-val", "Ejemplo");
        ///     attributes.Add("aria-label", "Default input ejemplo");
        ///     attributes.Add("disabled", "");
        ///
        ///     string input1 = HtmlUtil.getFormInputs(TypeTag.Input, id, name, type, value, classes, required, placeholder, attributes);
        ///
        ///     Console.WriteLine($"INPUT 1: {input1}");
        /// }
        /// </code>
        /// </summary>
        /// <param name="typeTag">Identifica el TAG HTML entre Input y Textarea</param>
        /// <param name="id">Id de la etiqueta</param>
        /// <param name="name">Nombre de la etiqueta</param>
        /// <param name="typeInput">Tipo de la etiqueta</param>
        /// <param name="value">Valor del input</param>
        /// <param name="classes">Listado de clases</param>
        /// <param name="required">Valor booleano si es un campo requerido o no</param>
        /// <param name="placeholder"></param>
        /// <param name="attributes">Contiene atributos adicionales de un input y su valor</param>
        /// <returns></returns>
        public static string getFormInputs(TypeTag typeTag, string id, string name, string typeInput, string value, List<string> classes, bool? required, string placeholder, Dictionary<string, string> attributes)
        {
            string r = "";
            string data = "";

            try
            {
                data += ((!String.IsNullOrEmpty(id)) ? " id=\"" + id + "\"" : "");
                data += ((!String.IsNullOrEmpty(name)) ? " name=\"" + name + "\"" : "");
                data += ((!String.IsNullOrEmpty(typeInput)) ? " type=\"" + typeInput + "\"" : "");
                //data += ((!String.IsNullOrEmpty(value)) ? " value=\"" + value + "\"" : "");
                data += ((!String.IsNullOrEmpty(id)) ? " placeholder=\"" + placeholder + "\"" : "");
                data += ((required.HasValue && required.Value == true) ? " required" : "");
                data += ((classes != null && classes.Count() > 0) ? $" class=\"{string.Join(" ", classes)}\"" : "");

                if (attributes != null && attributes.Count > 0)
                {
                    foreach (var a in attributes)
                    {
                        data += $" {a.Key}=\"{a.Value}\"";
                    }
                }

                if (typeTag.Equals(TypeTag.Textarea))
                {
                    r = $"<textarea{data}>{((!String.IsNullOrEmpty(value)) ? value : "")}</textarea>";
                }
                else
                {
                    data += ((!String.IsNullOrEmpty(value)) ? " value=\"" + value + "\"" : "");

                    r = $"<input{data} />";
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return r;
        }

        /// <summary>
        /// Obtiene una cadena de texto que genera un <b>Input</b> o <b>Textarea</b> que se genera con los atributos que se ingresan en la función
        /// <br />
        /// <code>
        /// public void GetTagsTest()
        /// {
        ///     string id = "ID";
        ///     string name = "nombre";
        ///     string type = "text";
        ///     string value = "Gerson Díaz";
        ///     bool? required = true;
        ///     string placeholder = "Nombre de Usuario";
        ///     List<string> classes = new List<string>();
        ///     classes.Add("form-control");
        ///     classes.Add("form-control-lg");
        ///     classes.Add("text-center");
        ///
        ///     Dictionary<string, string> attributes = new Dictionary<string, string>();
        ///     attributes.Add("data-val", "Ejemplo");
        ///     attributes.Add("aria-label", "Default input ejemplo");
        ///     attributes.Add("disabled", "");
        ///
        ///     string input1 = HtmlUtil.getFormInputs(TypeTag.Input, id, name, type, value, classes, required, placeholder, attributes);
        ///
        ///     Console.WriteLine($"INPUT 1: {input1}");
        /// }
        /// </code>
        /// </summary>
        /// <param name="typeTag">Identifica el TAG HTML entre Input y Textarea</param>
        /// <param name="id">Id de la etiqueta</param>
        /// <param name="name">Nombre de la etiqueta</param>
        /// <param name="typeInput">Tipo de la etiqueta</param>
        /// <param name="value">Valor del input</param>
        /// <param name="classes">Listado de clases</param>
        /// <param name="required">Valor booleano si es un campo requerido o no</param>
        /// <param name="placeholder"></param>
        /// <param name="attributes">Contiene atributos adicionales de un input y su valor</param>
        /// <param name="multiple">Identifica si permite múltiples registros</param>
        /// <returns></returns>
        public static string getFormInputs(TypeTag typeTag, string id, string name, string typeInput, string value, List<string> classes, bool? required, string placeholder, Dictionary<string, string> attributes, bool? multiple)
        {
            string r = "";
            string data = "";

            try
            {
                data += ((!String.IsNullOrEmpty(id)) ? " id=\"" + id + "\"" : "");
                data += ((!String.IsNullOrEmpty(name)) ? " name=\"" + name + "\"" : "");
                data += ((!String.IsNullOrEmpty(typeInput)) ? " type=\"" + typeInput + "\"" : "");
                //data += ((!String.IsNullOrEmpty(value)) ? " value=\"" + value + "\"" : "");
                data += ((!String.IsNullOrEmpty(id)) ? " placeholder=\"" + placeholder + "\"" : "");
                data += ((required.HasValue && required.Value == true) ? " required" : "");
                data += ((classes != null && classes.Count() > 0) ? $" class=\"{string.Join(" ", classes)}\"" : "");

                if (multiple != null && multiple.HasValue && multiple.Value)
                {
                    data += $" multiple";
                }

                if (attributes != null && attributes.Count > 0)
                {
                    foreach (var a in attributes)
                    {
                        data += $" {a.Key}=\"{a.Value}\"";
                    }
                }

                if (typeTag.Equals(TypeTag.Textarea))
                {
                    r = $"<textarea{data}>{((!String.IsNullOrEmpty(value)) ? value : "")}</textarea>";
                }
                else
                {
                    data += ((!String.IsNullOrEmpty(value)) ? " value=\"" + value + "\"" : "");

                    r = $"<input{data} />";
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return r;
        }

        /// <summary>
        /// Obtiene una cadena de texto con el HTML del input correspondiente
        /// </summary>
        /// <param name="typeTag"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="typeInput"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <param name="multiple"></param>
        /// <param name="classes"></param>
        /// <param name="required"></param>
        /// <param name="placeholder"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static string getFormInputs(TypeTag typeTag, string id, string name, string typeInput, string value, List<Value> values, bool? multiple, List<string> classes, bool? required, string placeholder, Dictionary<string, string> attributes)
        {
            string r = "";
            string data = "";

            try
            {
                data += ((!String.IsNullOrEmpty(id)) ? " id=\"" + id + "\"" : "");
                data += ((!String.IsNullOrEmpty(name)) ? " name=\"" + name + "\"" : "");
                data += ((!String.IsNullOrEmpty(typeInput)) ? " type=\"" + typeInput + "\"" : "");
                data += ((!String.IsNullOrEmpty(id)) ? " placeholder=\"" + placeholder + "\"" : "");
                data += ((required.HasValue && required.Value == true) ? " required" : "");
                data += ((classes != null && classes.Count() > 0) ? $" class=\"{string.Join(" ", classes)}\"" : "");

                if (multiple != null && multiple.HasValue && multiple.Value)
                {
                    data += $" multiple";
                }

                if (attributes != null && attributes.Count > 0)
                {
                    foreach (var a in attributes)
                    {
                        data += $" {a.Key}=\"{a.Value}\"";
                    }
                }

                if (typeTag.Equals(TypeTag.Textarea))
                {
                    r = $"<textarea{data}>{((!String.IsNullOrEmpty(value)) ? value : "")}</textarea>";
                }
                else if (typeTag.Equals(TypeTag.Select))
                {
                    r = $"<select{data}>";

                    r += $"<option>";
                    r += $"-- Seleccione --";
                    r += $"</option>";

                    if (values != null && values.Count > 0)
                    {
                        foreach(var v in values)
                        {
                            r += $"<option value='{v.value}' {((v.selected) ? "selected" : "")}>";
                            r += $"{v.label}";
                            r += $"</option>";
                        }
                    }

                    r += $"</select>";
                }
                else if (typeTag.Equals(TypeTag.Checkbox))
                {
                    r = $"";

                    if (values != null && values.Count > 0)
                    {
                        foreach (var v in values)
                        {
                            r += $"<div class='form-check'>";
                            r += $"<input{data} {((v.selected) ? "checked" : "")} />";
                            r += $"<label class='form-check-label'>";
                            r += $"{v.label}";
                            r += $"</label>";
                            r += $"</div>";
                        }
                    }
                }
                else if (typeTag.Equals(TypeTag.Radio))
                {
                    r = $"";

                    if (values != null && values.Count > 0)
                    {
                        foreach (var v in values)
                        {
                            r += $"<div class='form-check'>";
                            r += $"<input{data} {((v.selected) ? "checked" : "")} />";
                            r += $"<label class='form-check-label'>";
                            r += $"{v.label}";
                            r += $"</label>";
                            r += $"</div>";
                        }
                    }
                }
                else
                {
                    data += ((!String.IsNullOrEmpty(value)) ? " value=\"" + value + "\"" : "");

                    r = $"<input{data} />";
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return r;
        }

        #region Embedded Resources

        /// <summary>
        /// Permite cambiar una URL hacia un recurso incrustado por una url web hacia el mismo recurso
        /// </summary>
        /// <param name="embeddedUrl">Contiene la url con el formato de recurso incrustado<b>Sin incluir el nombre del archivo</b></param>
        /// <param name="currentDirectory">Es el path de la app/extension para identificar si esta correidneo como app o extension</param>
        /// <param name="extensionFolderName">Corresponde al nombre de la carpeta donde se registran las extensiones para identificar complementar si es app o extension. Por defecto es "Extensions"</param>
        /// <example>
        /// <code>
        /// [Test]
        /// public void embeddedResourceTest()
        /// {
        ///     string e1 = "Res.Images";
        ///
        ///     string dir1 = "app";
        ///     string dir2 = "Extensions";
        ///
        ///     string folderName = "Extensions";
        ///
        ///     Assert.IsTrue(HelpersUtil.embeddedToStaticFileUrl(e1, dir2, folderName).Contains("."));
        ///     Assert.IsTrue(HelpersUtil.embeddedToStaticFileUrl(e1, dir1, folderName).Contains("/"));
        ///
        ///     Assert.IsEmpty(HelpersUtil.embeddedToStaticFileUrl("", dir2, folderName));
        /// }
        /// </code>
        /// </example>
        /// <returns>
        /// Si es extensión, retorna "Res.Images.image.png" <br />
        /// Si no, retorna "Res/Images/image.png"
        /// </returns>
        public static string embeddedToStaticFileUrl(string embeddedUrl, string currentDirectory, string extensionFolderName)
        {
            try
            {
                Char replaceChar = '.';
                extensionFolderName = (!String.IsNullOrEmpty(extensionFolderName)) ? extensionFolderName : "Extensions";

                if (!currentDirectory.Contains(extensionFolderName))
                {
                    // Lo comentado evitaba cambiar el punto de extensión del archivo, pero ahora ya no es necesario

                    //int lastIndex = embeddedUrl.LastIndexOf(replaceChar);
                    //if (lastIndex != -1)
                    //{
                    //    string str = embeddedUrl.Substring(0, lastIndex);
                    //    str = str.Replace(replaceChar, '/');

                    //    embeddedUrl = str + embeddedUrl.Substring(lastIndex);
                    //}

                    embeddedUrl = embeddedUrl.Replace(replaceChar, '/');
                }
                return embeddedUrl;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Permite cambiar una URL hacia un recurso incrustado por una url web hacia el mismo recurso
        /// </summary>
        /// <param name="embeddedUrl">Contiene la url con el formato de recurso incrustado</param>
        /// <param name="currentDirectory">Es el path de la app/extension para identificar si esta correidneo como app o extension</param>
        /// <param name="extensionFolderName">Corresponde al nombre de la carpeta donde se registran las extensiones para identificar complementar si es app o extension. Por defecto es "Extensions"</param>
        /// <param name="fileName">Corresponde al nombre del archivo en caso vaya incluido en la path, para hacer la extracción de él y evitar errores</param>
        /// <example>
        /// <code>
        /// [Test]
        /// public void embeddedResourceTest()
        /// {
        ///     string e1 = "Res.Images.logo.png";
        ///
        ///     string dir1 = "app";
        ///     string dir2 = "Extensions";
        ///
        ///     string folderName = "Extensions";
        ///
        ///     Assert.IsTrue(HelpersUtil.embeddedToStaticFileUrl(e1, dir2, folderName).Contains("."));
        ///     Assert.IsTrue(HelpersUtil.embeddedToStaticFileUrl(e1, dir1, folderName).Contains("/"));
        ///
        ///     Assert.IsEmpty(HelpersUtil.embeddedToStaticFileUrl("", dir2, folderName));
        /// }
        /// </code>
        /// </example>
        /// <returns>
        /// Si es extensión, retorna "Res.Images.image.png" <br />
        /// Si no, retorna "Res/Images/image.png"
        /// </returns>
        public static string embeddedToStaticFileUrl(string embeddedUrl, string currentDirectory, string extensionFolderName, string fileName)
        {
            try
            {
                Char replaceChar = '.';
                extensionFolderName = (!String.IsNullOrEmpty(extensionFolderName)) ? extensionFolderName : "Extensions";

                if (!currentDirectory.Contains(extensionFolderName))
                {
                    // Lo comentado evitaba cambiar el punto de extensión del archivo, pero ahora ya no es necesario

                    //int lastIndex = embeddedUrl.LastIndexOf(replaceChar);
                    //if (lastIndex != -1)
                    //{
                    //    string str = embeddedUrl.Substring(0, lastIndex);
                    //    str = str.Replace(replaceChar, '/');

                    //    embeddedUrl = str + embeddedUrl.Substring(lastIndex);
                    //}

                    if (!String.IsNullOrEmpty(fileName))
                    {
                        embeddedUrl = embeddedUrl.Replace(fileName, "");
                    }

                    embeddedUrl = embeddedUrl.Replace(replaceChar, '/') + ((!String.IsNullOrEmpty(fileName)) ? fileName : "");
                }
                return embeddedUrl;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Desde una URL retorna en formato Embedded Resource
        /// </summary>
        /// <param name="url"></param>
        /// <param name="currentDirectory"></param>
        /// <param name="extensionFolderName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string staticFileUrlToEmbedded(string url, string currentDirectory, string extensionFolderName, string fileName)
        {
            try
            {
                Char replaceChar = '/';
                extensionFolderName = (!String.IsNullOrEmpty(extensionFolderName)) ? extensionFolderName : "Extensions";

                if (currentDirectory.Contains(extensionFolderName))
                {
                    url = url.Replace(replaceChar, '.');
                }
                return url;
            }
            catch
            {
                throw;
            }
        }

        #endregion Embedded Resources
    }

    public enum TypeTag
    {
        Input = 1,
        Textarea = 2,
        Select = 3,
        Checkbox = 4,
        Radio = 5
    }

    public class Value
    {
        public string label { get; set; }
        public string value { get; set; }
        public bool selected { get; set; }
    }
}
