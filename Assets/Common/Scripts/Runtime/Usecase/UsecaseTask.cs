﻿using System;
using System.Threading.Tasks;
using Common.Scripts.Runtime.Utils;
using Project.Scripts.Runtime.Entity;
using UniRx.Async;

namespace Common.Scripts.Runtime.Usecase
{
    public abstract class UsecaseTask<TPar, TRes> where TPar : struct where TRes : struct
    {
        private const string Tag = "UsecaseTask";

        public async UniTask<Usecase<TRes>> Execute(TPar param)
        {
            Log.D(Tag, "Execute");
            return await Task.Run(new Func<Task<Usecase<TRes>>>(async () =>
            {
                try
                {
                    return new Resolved<TRes>(await Call(param)); 
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

        protected abstract UniTask<TRes> Call(TPar param);
    }
}