using Hefesto.Check;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Tests
{
    public class HttpTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HttpTest()
        {
            bool b1= HttpUtil.urlExist("https://www.ckelar.cl/");
            bool b2 = HttpUtil.urlExist("http://ckelarsoftware.cl/");
            //bool b3 = HttpUtil.urlExist("http://ckelarsoftware.cl/Prueba");
            bool b4 = HttpUtil.urlExist("https://www.ckelar.cl/web/wp-content/uploads/2019/04/cropped-ckelar4_t.png");
            
            Assert.IsTrue(b1);
            Assert.IsTrue(b2);
            //Assert.IsFalse(b3);
            Assert.IsTrue(b4);
        }
    }
}
