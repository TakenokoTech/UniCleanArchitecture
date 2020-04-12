using System;
using Project.Entity;
using Runtime.Exception;
using Runtime.Utils;
using UniRx;

namespace Runtime.Usecase
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
                .Start(() =>
                {
                    Log.D(Tag, "Create");
                    Call(param, this.Resolved, this.Rejected);
                })
                .SubscribeOn(Scheduler.ThreadPool)
                .DoOnError(err => _result.OnNext(new Rejected<TRes>(err)))
                .Subscribe(res =>
                {
                    Log.D(Tag, "Subscribe");
                    this.Completed();
                });
        }

        public void Cancel()
        {
            Log.D(Tag, "Cancel");
            _result.OnError(new CanceledException());
        }

        private Action<TRes> Resolved => ((TRes res) => {
            Log.D(Tag, "Resolved {0}", res.Dump());
            _result.OnNext(new Resolved<TRes>(res));
        });
        
        private Action<System.Exception> Rejected => ((System.Exception e) => {
            Log.D(Tag, "Rejected {0}", e.Message);
            _result.OnNext(new Rejected<TRes>(e));
        });
        
        private Action Completed => (() => {
            Log.D(Tag, "Completed");
            _result.OnCompleted();
        });

        protected abstract void Call(TPar param, Action<TRes> resolved, Action<System.Exception> rejected);
    }
}