using UnityEngine;
using Zenject;

namespace Project.Scripts.Runtime
{
    public class MainScript : MonoBehaviour
    {
        [Inject] private CharacterFactory _factory;
        
        // Start is called before the first frame update
        void Start()
        {
            _factory.Create();
            _factory.Create();
            _factory.Create();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
