using System.Threading.Tasks;
using Common.Scripts.Runtime.Usecase;
using Common.Scripts.Runtime.Utils;
using Project.Scripts.Runtime.Repository;
using UniRx.Async;
using Zenject;

namespace Project.Scripts.Runtime.Usecase
{
    public class LoadHumanUsecase : UsecaseTask<LoadHumanUsecase.Param, LoadHumanUsecase.Result>
    {
        private const string Tag = "SampleUsecase";

        [Inject] private HumanRepository _humanRepository;

        protected override async UniTask<Result> Call(Param param)
        {
            var name = await Task.Run(_humanRepository.GetName).Result;
            Log.D(Tag, name);
            return new Result() {Name = "name"};
        }


        public struct Param
        {
        }

        public struct Result
        {
            public string Name;
        }
    }
}