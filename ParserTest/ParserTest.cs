using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MifParser;

namespace ParserTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestMyParser()
        {
            var parser = new MyParser();
            parser.Parse();            
        }

        [TestMethod]
        public void AssertNumRows()
        {
            using (var db = new GeoDbContext())
            {
                var c = db.Owners.Count();
                Assert.AreEqual(3551, c);
            }
        }
    }
}