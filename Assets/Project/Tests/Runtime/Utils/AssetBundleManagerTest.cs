using NUnit.Framework;
using Project.Scripts.Runtime.Utils;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Project.Tests.Runtime.Utils
{
    [TestFixture]
    public class AssetBundleManagerTest : ZenjectUnitTestFixture
    {
        private const string Tag = "AssetBundleManagerTest";

        [SetUp]
        public void Init()
        {
            Log.D(Tag, "ActiveBuildTarget: " + EditorUserBuildSettings.activeBuildTarget);
        }

        [Test]
        public void ExecuteTest()
        {
            var path = "Assets/AssetBundle/" + EditorUserBuildSettings.activeBuildTarget + "/image";
            
            const string name1 = "Assets/AssetBundleResources/Image/man.png";
            var image1 = AssetBundleManager.Load<Texture2D>(path, name1);

            Assert.NotNull(image1);
            Assert.AreEqual(AssetBundleManager.GetRefCount(path), 1);
            
            const string name2 = "Assets/AssetBundleResources/Image/woman.png";
            var image2 = AssetBundleManager.Load<Texture2D>(path, name2);
            
            Assert.NotNull(image2);
            Assert.AreEqual(AssetBundleManager.GetRefCount(path), 2);

            AssetBundleManager.Unload(path);
            Assert.AreEqual(AssetBundleManager.GetRefCount(path), 1);
            
            AssetBundleManager.Unload(path);
            Assert.AreEqual(AssetBundleManager.GetRefCount(path), null);
        }
    }
}
