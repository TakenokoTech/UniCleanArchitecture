using NUnit.Framework;
using Zenject;

// using Project.Scripts;

namespace Tests.Runtime
{
    [TestFixture]
    public class HumanUnitTest : ZenjectUnitTestFixture
    {
        
        [Test]
        public void TrueTest()
        {
            // 前進している
            Assert.True(true);
        }
    }
}