using System;
using Project.Scripts.Utils;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Usecase
{
    public class SampleUsecase : Usecase<SampleUsecase.Param, SampleUsecase.Result>
    {
        private const string Tag = "SampleUsecase";

        protected override Result Call(Param param)
        {
            Log.D(Tag, "Call. param:{0}", param.Dump());
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