using System.Threading.Tasks;
using Runtime.Utils;
using UniRx.Async;
using Zenject;

namespace Runtime.Repository
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