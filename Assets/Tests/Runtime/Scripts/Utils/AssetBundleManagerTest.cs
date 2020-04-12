﻿using NUnit.Framework;
   using Project.Scripts.Utils;
   using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
   using Zenject;
   
   namespace Tests.Scripts.Utils
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
               const string name = "Assets/AssetBundleResources/man.png";
               var image = AssetBundleManager.Load<Texture2D>(path, name);
               Assert.NotNull(image);
               
               AssetBundleManager.Unload(path);
               Assert.NotNull(image);
           }
       }
   }
   