using System;
using Project.Entity;
using UniRx;

namespace Project.Scripts.Usecase
{
    public abstract class Usecase<TPar, TRes> where TPar: struct where TRes : struct
    {
        private readonly Subject<Usecase<TRes>> _result = new Subject<Usecase<TRes>>();
        public IObservable<Usecase<TRes>> Source => _result;

        public void Execute(TPar param)
        {
            _result.OnNext(new Pending<TRes>());
            Observable.Create<TRes>(observer => { Call(param); return Disposable.Empty; })
                .DoOnError(err => _result.OnNext(new Rejected<TRes>(err)))
                .Subscribe(res => _result.OnNext(new Resolved<TRes>(res)));
        }

        public void Cancel()
        {
            _result.OnError(new CanceledException());
        }

        protected abstract TRes Call(TPar param);

        private class CanceledException : Exception {}
    }
}