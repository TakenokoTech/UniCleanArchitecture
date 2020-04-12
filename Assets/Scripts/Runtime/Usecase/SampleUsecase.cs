using System;
using System.Threading;
using Runtime.Utils;

namespace Runtime.Usecase
{
    public class SampleUsecase : Usecase<SampleUsecase.Param, SampleUsecase.Result>
    {
        private const string Tag = "SampleUsecase";

        protected override void Call(Param param, Action<Result> resolved, Action<System.Exception> rejected)
        {
            Log.D(Tag, "Call. param:{0}", param.Dump());
            Thread.Sleep(100);
            resolved(new Result {Value = "OK"});
            Thread.Sleep(100);
            rejected(new System.Exception("sample error."));
            Thread.Sleep(100);
            resolved(new Result {Value = "OK"});
        }

        public struct Param
        {
            public string param1;
        }

        public struct Result
        {
            public string Value;
        }
    }
    
    public class SampleUsecaseTask : UsecaseTask<SampleUsecaseTask.Param, SampleUsecaseTask.Result>
    {
        private const string Tag = "SampleUsecase";

        protected override Result Call(Param param)
        {
            Log.D(Tag, "Call. param:{0}", param.Dump());
            Thread.Sleep(100);
            return new Result {Value = "OK"};
        }

        public struct Param
        {
            public string param1;
        }

        public struct Result
        {
            public string Value;
        }
    }
}