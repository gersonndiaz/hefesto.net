using Hefesto.Format;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Tests
{
    public class RutTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FormatTest()
        {
            string rut = "11.111.111-1";
            string rutSinFormato = FormatUtil.removeFormatRutChile(rut);

            Assert.AreEqual("111111111", rutSinFormato);
        }
    }
}
