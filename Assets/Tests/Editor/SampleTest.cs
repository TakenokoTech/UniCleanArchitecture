using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Packages_Tests
{
    
    public class SampleTest
    {
        [SetUp]
        public void Init()
        {
        }
        
        [TearDown]
        public void Finish()
        {
        }

        [Test]
        public void TrueTest()
        {
            Assert.True(true);
        }
    }
}