using NUnit.Framework;
using Project.Scripts.Runtime.Utils;
using Zenject;

namespace Project.Tests.Runtime.Utils
{
    [TestFixture]
    public class PrefsTest : ZenjectUnitTestFixture
    {
        private const string Tag = "PrefsTest";
        
        [SetUp]
        public void Init()
        {
            Prefs.ClearAll();
        }

        [Test]
        public void ExecuteTest()
        {
            Assert.AreEqual(Prefs.Sample, "");
       
            Prefs.Sample = "Sample text 1";
            Assert.AreEqual(Prefs.Sample, "Sample text 1");

            Prefs.Sample = "Sample text 2";
            Assert.AreEqual(Prefs.Sample, "Sample text 2");
        }
    }
}

