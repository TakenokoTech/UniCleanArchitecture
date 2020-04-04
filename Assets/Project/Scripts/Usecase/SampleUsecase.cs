using System;
using UniRx;

namespace Project.Scripts.Usecase
{
    public class SampleUsecase : Usecase<SampleUsecase.Param, SampleUsecase.Result>
    {
        protected override SampleUsecase.Result Call(SampleUsecase.Param param) {
             return new Result();
        }

        public struct Param
        {
        }

        public struct Result
        {
        }
    }
}
