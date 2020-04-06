using System;
using Project.Entity;
using Project.Scripts.Utils;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Usecase
{
    public abstract class Usecase<TPar, TRes> where TPar : struct where TRes : struct
    {
        private const string Tag = "Usecase";

        private readonly Subject<Usecase<TRes>> _result = new Subject<Usecase<TRes>>();
        public IObservable<Usecase<TRes>> Source => _result;

        public void Execute(TPar param)
        {
            Log.D(Tag, "Execute");
            _result.OnNext(new Pending<TRes>());

            Observable
                .Create<TRes>(observer =>
                {
                    Log.D(Tag, "Create");
                    observer.OnNext(Call(param));
                    observer.OnCompleted();
                    return Disposable.Empty;
                })
                .SubscribeOn(Scheduler.ThreadPool)
                .DoOnError(err => _result.OnNext(new Rejected<TRes>(err)))
                .Subscribe(res =>
                    {
                        Log.D(Tag, "onNext");
                        _result.OnNext(new Resolved<TRes>(res));
                        _result.OnCompleted();
                    }
                );
        }

        public void Cancel()
        {
            Log.D(Tag, "Cancel");
            _result.OnError(new CanceledException());
        }

        protected abstract TRes Call(TPar param);

        private class CanceledException : Exception
        {
        }
    }
}