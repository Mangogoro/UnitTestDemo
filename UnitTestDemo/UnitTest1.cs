using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace UnitTestDemo
{

    public class UnitTest1
    {


        //[TestCase(@"'嵐CASA(嵐 CASA)")]
        [TestCase("")]
        public void BuildFXML(string sMemo)
        {
            Encoding oEncoding = Encoding.UTF8;
            sMemo = "'嵐CASA(嵐 CASA)";

            var oMemoryStream = new MemoryStream();
            var oXmlTextWriter = new XmlTextWriter(oMemoryStream, oEncoding);
            oXmlTextWriter.WriteStartDocument(false);
            //====================================


            oXmlTextWriter.WriteElementString("Memo", sMemo);
            

            //====================================
            oXmlTextWriter.WriteEndDocument();
            oXmlTextWriter.Flush();


            StreamReader reader = new StreamReader(oMemoryStream, oEncoding);
            oMemoryStream.Seek(0, SeekOrigin.Begin);
            string ss = reader.ReadToEnd();


            Console.WriteLine(ss);

            Assert.IsTrue(ss.Contains("&"));
        }


    }
}
