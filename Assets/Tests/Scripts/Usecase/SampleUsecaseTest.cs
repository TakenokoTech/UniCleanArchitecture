using System;
using NUnit.Framework;
using Project.Entity;
using Project.Scripts.Usecase;
using UniRx;
using Zenject;

namespace Tests.Scripts.Usecase
{
    [TestFixture]
    public class SampleUsecaseTest : ZenjectUnitTestFixture
    {
        private readonly TimeSpan _waitTime = new TimeSpan(0, 0, 0, 1, 0);

        [Test]
        public void ExecuteTest()
        {
            var sampleUsecase = new SampleUsecase();
            sampleUsecase.Execute(new SampleUsecase.Param {param1 = "p1"});
            var result = sampleUsecase.Source.Wait(_waitTime);

            Assert.IsNotNull(result.GetOrNull());
            Assert.IsNull(result.ExceptionOrNull());
            Assert.AreEqual(result.GetOrNull()?.Value, "OK");
        }
    }
}
