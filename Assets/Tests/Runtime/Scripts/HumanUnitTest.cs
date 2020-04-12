using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;
// using Project.Scripts;

namespace Tests.Scripts
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