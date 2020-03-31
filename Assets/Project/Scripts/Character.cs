using ModestTree;
   using UnityEngine;
   using Zenject;
   
   namespace Project.Scripts
   {
       public class Character : MonoBehaviour
       {
           [Inject] private IHuman human;
   
           // Start is called before the first frame update
           void Start()
           {
               Log.Debug("name = %s", human.GetName());
           }
   
           // Update is called once per frame
           void Update()
           {
           }
       }
       
       // ReSharper disable once ClassNeverInstantiated.Global
       public class CharacterFactory : PlaceholderFactory<Character> {}
   }