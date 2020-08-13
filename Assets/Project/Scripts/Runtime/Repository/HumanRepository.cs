using Common.Scripts.Runtime.Utils;
using UniRx.Async;
using Zenject;

namespace Project.Scripts.Runtime.Repository
{
    public class HumanRepository
    {
        
        [Inject] private IApiBuilder _apiBuilder;

        public UniTask<string> GetName()
        {
            return _apiBuilder.GetAsync("http://localhost:8080");
        }
    }
}