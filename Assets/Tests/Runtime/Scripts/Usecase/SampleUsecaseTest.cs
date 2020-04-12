using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.Entity;
using Project.Scripts.Usecase;
using Project.Scripts.Utils;
using UniRx;
using UniRx.Async;
using UnityEngine.TestTools;
using Zenject;

namespace Tests.Scripts.Usecase
{
    [TestFixture]
    public class SampleUsecaseTest : ZenjectUnitTestFixture
    {
        private const string Tag = "SampleUsecaseTest";
        private readonly TimeSpan _waitTime = new TimeSpan(0, 0, 0, 1500);

        [Test]
        public void ExecuteTest()
        {
            var result = new List<string>();
            var sampleUsecase = new SampleUsecase();
            sampleUsecase.Execute(new SampleUsecase.Param {param1 = "p1"});
            
            // TODO: Util
            sampleUsecase.Source.Subscribe(
                next =>
                {
                    result.Add(next.GetOrNull()?.Value ?? next.ExceptionOrNull().Message);
                    Log.D(Tag, "{0}", next.GetOrNull()?.Dump() );
                },
                exception =>
                {
                    Log.D(Tag, "{0}", exception.Message);
                }
            );
            Thread.Sleep(1000);
            
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0], "OK");
            Assert.AreEqual(result[1], "sample error.");
            Assert.AreEqual(result[2], "OK");
        }

        [UnityTest]
        public IEnumerator ExecuteTest2() => UniTask.ToCoroutine(async () =>
        {

            var sampleUsecaseTask = new SampleUsecaseTask();
            var result = await sampleUsecaseTask.Execute(new SampleUsecaseTask.Param {param1 = "p1"});

            Log.D(Tag, "{0}", result.GetOrNull().Dump());
            Assert.IsNotNull(result.GetOrNull());
            Assert.IsNull(result.ExceptionOrNull());
            Assert.AreEqual(result.GetOrNull()?.Value, "OK");
        });
    }
}
