using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Hefesto.Html
{
    /// <summary>
    /// Clase que permite generar una tabla HTML a partir de un Json
    /// </summary>
    public class JsonToHtmlTable
    {
        private string id;
        private string name;
        private List<string> classes;
        private Dictionary<string, string> attributes;

        /// <summary>
        /// Crea instancia sin atributos
        /// </summary>
        public JsonToHtmlTable()
        { }

        /// <summary>
        /// Crea instancia con atributos para generar tabla HTML con propiedades
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="classes"></param>
        /// <param name="attributes"></param>
        public JsonToHtmlTable(string id, string name, List<string> classes, Dictionary<string, string> attributes)
        {
            this.id = id;
            this.name = name;
            this.classes = classes;
            this.attributes = attributes;
        }

        /// <summary>
        /// Función principal que recibe el Json para transformar a Tabla HTML
        /// </summary>
        /// <param name="json">Cadena Json que será convertida en tabla HTML</param>
        /// <returns></returns>
        public string ConvertJsonToHtmlTable(string json)
        {
            string data = "";
            data += ((!String.IsNullOrEmpty(id)) ? " id=\"" + id + "\"" : "");
            data += ((!String.IsNullOrEmpty(name)) ? " name=\"" + name + "\"" : "");
            data += ((classes != null && classes.Count() > 0) ? $" class=\"{string.Join(" ", classes)}\"" : "");

            if (attributes != null && attributes.Count > 0)
            {
                foreach (var a in attributes)
                {
                    data += $" {a.Key}=\"{a.Value}\"";
                }
            }

            StringBuilder htmlTable = new StringBuilder();

            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;

            htmlTable.AppendLine($"<table{data}>");
            GenerateTableRows(root, htmlTable);
            htmlTable.AppendLine("</table>");

            return htmlTable.ToString();
        }

        /// <summary>
        /// Función que crea las filas de la tabla según el contenido encontrado
        /// </summary>
        /// <param name="element">Objeto encontrado</param>
        /// <param name="htmlTable">String de la tabla HTML</param>
        /// <exception cref="ArgumentException"></exception>
        private void GenerateTableRows(JsonElement element, StringBuilder htmlTable)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement arrayElement in element.EnumerateArray())
                {
                    htmlTable.AppendLine("<tr>");

                    foreach (JsonProperty property in arrayElement.EnumerateObject())
                    {
                        htmlTable.AppendLine($"<td>{property.Name}</td>");

                        if (property.Value.ValueKind == JsonValueKind.Array || property.Value.ValueKind == JsonValueKind.Object)
                        {
                            htmlTable.AppendLine("<td>");

                            GenerateTableRows(property.Value, htmlTable);

                            htmlTable.AppendLine("</td>");
                        }
                        else
                        {
                            htmlTable.AppendLine($"<td>{GetCellContent(property.Value)}</td>");
                        }
                    }

                    htmlTable.AppendLine("</tr>");
                }
            }
            else if (element.ValueKind == JsonValueKind.Object)
            {
                htmlTable.AppendLine("<tr>");

                foreach (JsonProperty property in element.EnumerateObject())
                {
                    htmlTable.AppendLine($"<td>{property.Name}</td>");

                    if (property.Value.ValueKind == JsonValueKind.Array || property.Value.ValueKind == JsonValueKind.Object)
                    {
                        htmlTable.AppendLine("<td>");

                        GenerateTableRows(property.Value, htmlTable);

                        htmlTable.AppendLine("</td>");
                    }
                    else
                    {
                        htmlTable.AppendLine($"<td>{GetCellContent(property.Value)}</td>");
                    }
                }

                htmlTable.AppendLine("</tr>");
            }
            else
            {
                throw new ArgumentException("El JSON proporcionado no es válido.");
            }
        }

        /// <summary>
        /// Función que permite generar sub tablas cuando el contenido es otro objeto Json
        /// </summary>
        /// <param name="element">Objeto encontrado</param>
        /// <returns></returns>
        private string GetCellContent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Object || element.ValueKind == JsonValueKind.Array)
            {
                return ConvertJsonToHtmlTable(element.ToString());
            }
            else
            {
                return element.ToString();
            }
        }
    }

}
