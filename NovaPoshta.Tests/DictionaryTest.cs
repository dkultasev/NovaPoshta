using System.Linq;
using NovaPoshta.Core;
using NovaPoshta.Entity;
using NUnit.Framework;

namespace NovaPoshta.Tests
{
    public class DictionaryTest
    {
        [Test]
        public void GetTypesOfPayersTest()
        {
            var dl = new DictionaryLogic();
            var result = dl.GetDictionary<Dictionary>("TypesOfPayers").Count();
            Assert.Greater(result, 1);
        }

        [Test]
        public void GetPackListTest()
        {
            var dl = new DictionaryLogic();
            var result = dl.GetPackList();
            Assert.Greater(result.Count(), 1);
        }

        [Test]
        public void GetPackListWithWidth1000Test()
        {
            var dl = new DictionaryLogic();
            var result = dl.GetPackList(new PackList() { Width = 1000});
            Assert.AreEqual(result.Count(), 1);
        }
    }
}
