using Hefesto.File;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hefesto.Tests
{
    public class FileTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual("image/png", FileUtil.getMimeType(".png"));
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.wordprocessingml.document", FileUtil.getMimeType(".docx"));
            Assert.AreEqual("application/x-zip-compressed", FileUtil.getMimeType(".zip"));
            Assert.AreNotEqual("application/vnd.ms-excel", FileUtil.getMimeType(".xlsx"));
            Assert.AreNotEqual("image/png", FileUtil.getMimeType(""));
        }
    }
}
