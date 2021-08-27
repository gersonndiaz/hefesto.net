using Hefesto.Html;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Hefesto.Tests
{
    public class HtmlTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTagsTest()
        {
            string id = "ID";
            string name = "nombre";
            string type = "text";
            string value = "Gerson Díaz";
            bool? required = true;
            string placeholder = "Nombre de Usuario";
            List<string> classes = new List<string>();
            classes.Add("form-control");
            classes.Add("form-control-lg");
            classes.Add("text-center");

            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("data-val", "Ejemplo");
            attributes.Add("aria-label", "Default input ejemplo");
            attributes.Add("disabled", "");


            string input1 = HtmlUtil.getFormInputs(TypeTag.Input, id, name, type, value, classes, required, placeholder, attributes);

            Console.WriteLine($"INPUT 1: {input1}");

            Assert.IsNotEmpty(input1);
        }
    }
}
