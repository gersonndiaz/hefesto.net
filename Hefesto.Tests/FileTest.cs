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


            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Gerson\Downloads\_Testing\EjemploExcel_20210507.xlsx");
            string file = FileUtil.fileToBase64(bytes, null, null);
            string file2 = FileUtil.fileToBase64(bytes, null, false);
            string file3 = FileUtil.fileToBase64(bytes, FileUtil.getMimeType(".xlsx"), true);

            byte[] bytes2 = FileUtil.base64ToFile(file);
            byte[] bytes3 = FileUtil.base64ToFile(file2);
            byte[] bytes4 = FileUtil.base64ToFile(file3);
            System.IO.File.WriteAllBytes(@"C:\Users\Gerson\Downloads\_Testing\Writed\ej1.xlsx", bytes2);
            System.IO.File.WriteAllBytes(@"C:\Users\Gerson\Downloads\_Testing\Writed\ej2.xlsx", bytes3);
            System.IO.File.WriteAllBytes(@"C:\Users\Gerson\Downloads\_Testing\Writed\ej3.xlsx", bytes4);
        }
    }
}
