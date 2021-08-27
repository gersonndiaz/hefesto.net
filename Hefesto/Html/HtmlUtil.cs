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
    }

    public enum TypeTag
    {
        Input = 1,
        Textarea = 2
    }
}
