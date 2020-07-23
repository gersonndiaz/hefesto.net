using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Tests
{
    public class ConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void textDateTime()
        {
            string d1 = "01-03-2020";
            string d2 = "01/03/2020";
            string d3 = "01032020";
            string d4 = "20200301";
            string d5 = "2020/03/01";
            string d6 = "2020-03-01";

            Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d1));
            Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d2));
            //Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d3));
            //Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d4));
            Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d5));
            Assert.IsNotNull(Hefesto.Converter.ConverterUtil.textToDateTime(d6));
        }
    }
}
