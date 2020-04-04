using System.Collections;
using NUnit.Framework;
using Project.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;
// using Project.Scripts;

namespace Tests.Scripts
{
    public class HumanIntegrationTest : ZenjectIntegrationTestFixture
    {
        private Human _human;

        [SetUp]
        public void Init()
        {
            // SceneManager.LoadScene("Project/Scenes/SampleScene");
            _human = new Human();
        }

        private void CommonInstall()
        {
            PreInstall();
            Container.Bind<IHuman>().FromInstance(_human);
            PostInstall();
        }
        
        [TearDown]
        public void Finish()
        {
            _human.Reset();
        }

        [UnityTest]
        public IEnumerator TrueTest()
        {
            CommonInstall();
            yield return new WaitForSeconds(1);

            Assert.AreEqual(_human.GetName(), "human");
        }
    }
}