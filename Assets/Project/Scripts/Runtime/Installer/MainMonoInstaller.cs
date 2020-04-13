using Project.Scripts.Runtime.Entity;
using Runtime;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Runtime.Installer
{
    public class MainMonoInstaller : MonoInstaller<MainMonoInstaller>
    {
        [SerializeField] private UnityEngine.GameObject characterPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IHuman>().To<Human>().AsCached();
            Container.BindFactory<Character, CharacterFactory>().FromComponentInNewPrefab(characterPrefab);
        }
    }
}