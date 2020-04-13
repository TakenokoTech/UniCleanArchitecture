using System;
using System.Collections;
using NUnit.Framework;
using Project.Scripts.Runtime.Repository;
using Project.Scripts.Runtime.Utils;
using UniRx;
using UniRx.Async;
using UnityEngine.TestTools;
using Zenject;

namespace Project.Tests.Runtime.Repository
{
    public class HumanRepositoryTest : ZenjectIntegrationTestFixture
    {

        [SetUp]
        public void Init()
        {
        }

        private void CommonInstall()
        {
            PreInstall();
            Container.Bind<IApiBuilder>().FromInstance(new MockApiBuilder());
            Container.Bind<HumanRepository>().AsSingle();
            PostInstall();
        }
        
        [TearDown]
        public void Finish()
        {
        }

        [UnityTest]
        public IEnumerator TrueTest() => UniTask.ToCoroutine(async () =>
        {
            CommonInstall();
            
            var humanRepository = Container.Resolve<HumanRepository>();
            var result = await humanRepository.GetName();
            Assert.AreEqual(result, "text2");
        });

        private class MockApiBuilder : IApiBuilder {
            public IObservable<string> GetObservable(string uri) => Observable.Return("text1");
            public UniTask<string> GetAsync(string uri) => UniTask.FromResult("text2");
        }
    }
}