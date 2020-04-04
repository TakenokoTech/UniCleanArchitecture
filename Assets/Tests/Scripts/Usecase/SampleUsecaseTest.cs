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

        
        [Test]
        public void ExecuteTest()
        {
            var observer = new TestObserver<SampleUsecase.Result>();
            var sampleUsecase = new SampleUsecase();
            
            sampleUsecase.Source.Subscribe(observer);
            sampleUsecase.Execute(new SampleUsecase.Param());

            Assert.IsNotNull(observer.Value);
            Assert.IsNull(observer.Error);
            Assert.AreEqual(observer.Value.GetOrNull(), new SampleUsecase.Result());
        }
    }

    internal class TestObserver<T> : IObserver<Usecase<T>> where T : struct
    {
        public Usecase<T> Value { get; private set; } = null;
        public Exception Error { get; private set; } = null;
        
        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            this.Error = error;
        }

        public void OnNext(Usecase<T> value)
        {
            this.Value = value;
        }
    }
}