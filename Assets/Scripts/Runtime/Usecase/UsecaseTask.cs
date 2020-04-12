using System;
using System.Threading.Tasks;
using Project.Entity;
using Runtime.Utils;
using UniRx.Async;

namespace Runtime.Usecase
{
    public abstract class UsecaseTask<TPar, TRes> where TPar : struct where TRes : struct
    {
        private const string Tag = "UsecaseTask";

        public async UniTask<Usecase<TRes>> Execute(TPar param)
        {
            Log.D(Tag, "Execute");
            return await Task.Run(new Func<Usecase<TRes>>(() =>
            {
                try
                {
                    return new Resolved<TRes>(Call(param)); 
                }
                catch (System.Exception e)
                {
                    return new Rejected<TRes>(e);
                }
            }));
        }

        public void Cancel()
        {
            Log.D(Tag, "Cancel");
        }

        protected abstract TRes Call(TPar param);
    }
}