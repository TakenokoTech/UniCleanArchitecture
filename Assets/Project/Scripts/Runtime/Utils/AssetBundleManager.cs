using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Scripts.Runtime.Utils
{
    public class AssetBundleManager : MonoBehaviour
    {
        private const string Tag = "AssetBundleManager";
        private static readonly Dictionary<string, Asset> Dic = new Dictionary<string, Asset>();

        public static T Load<T>(string path, string name) where T : Object
        {
            Log.D(Tag, "Load");
            if (!Dic.ContainsKey(path))
            {
                Log.D(Tag, "Newly loaded.");
                Dic.Add(path, new Asset {RefCount = 1, Bundle = AssetBundle.LoadFromFile(path)});
            }
            else
            {
                Log.D(Tag, "Already loaded.");
                Dic[path].RefCount++;
            }

            return Dic[path].Bundle.LoadAsset<T>(name);
        }

        public static void Unload(string path)
        {
            Log.D(Tag, "Unload");
            if (--Dic[path].RefCount > 0)
            { 
                Log.D(Tag, "Still using.");
                return;
            }

            Dic[path].Bundle.Unload(false);
            Dic.Remove(path);
        }
        
        public static int? GetRefCount(string path)
        {
            Log.D(Tag, "GetRefCount");
            Dic.TryGetValue(path, out var asset);
            return asset?.RefCount;
        }
        
        private class Asset
        {
            public int RefCount;
            public AssetBundle Bundle;
        }
    }
}