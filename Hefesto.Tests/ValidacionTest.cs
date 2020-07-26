using Hefesto.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Tests
{
    public class ValidacionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Assert.IsTrue(DataTypeValidation.checkUrl("https://www.ckelar.cl/"));
            Assert.IsTrue(DataTypeValidation.checkUrl("http://www.escolaresenlinea.cl/Producto/Categoria?categoria_id=18"));
            Assert.IsTrue(DataTypeValidation.checkUrl("https://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url"));
            Assert.IsTrue(DataTypeValidation.checkUrl("https://www.google.com/search?safe=active&sxsrf=ALeKk01de8kGEUPib_r4vOiWnz0g6qDT-A%3A1595716697553&ei=WbQcX4e6Ieed5OUPjLWDuAQ&q=c%23+datetime+yyyy+mm+dd+hh+mm+ss&oq=datetime+yyyy+mm+dd+hh+mm+ss+&gs_lcp=CgZwc3ktYWIQAxgBMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB46BAgAEEc6BAgAEEM6BQgAELEDOgIIADoICAAQsQMQgwE6AgguOgQIIxAnOgUILhCxAzoKCAAQsQMQFBCHAjoHCAAQsQMQQ1CP18MCWJWhxAJg5MXEAmgAcAN4AIABYIgBygeSAQIxM5gBAKABAaoBB2d3cy13aXrAAQE&sclient=psy-ab"));
            Assert.IsTrue(DataTypeValidation.checkUrl("https://docs.microsoft.com/en-us/dotnet/api/system.uri.iswellformeduristring?redirectedfrom=MSDN&view=netcore-3.1#System_Uri_IsWellFormedUriString_System_String_System_UriKind_"));

            Assert.IsFalse(DataTypeValidation.checkUrl(""));
            Assert.IsFalse(DataTypeValidation.checkUrl("/Producto/Categoria?categoria_id=18"));
            Assert.IsFalse(DataTypeValidation.checkUrl("www.ckelar"));
            Assert.IsFalse(DataTypeValidation.checkUrl("www.ckelar.cl"));
            Assert.IsFalse(DataTypeValidation.checkUrl("ckelar.cl"));
            //Assert.IsFalse(DataTypeValidation.checkUrl(""));
        }
    }
}
