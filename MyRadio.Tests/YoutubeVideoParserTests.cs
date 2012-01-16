using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRadio.Domain;

namespace MyRadio.Tests
{
    [TestClass]
    public class YoutubeVideoParserTests
    {
        [TestMethod]
        public void Can_Parse_Youtube_Video()
        {
            YoutubeVideoParser parser = new YoutubeVideoParser();
            var result = parser.Parse("http://www.youtube.com/watch?v=qHSPWzuvkUM&feature=grec_index");
            Console.WriteLine(result);
        }
    }
}
