using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace Editor.MenuItem
{
    public static class BuildAssetBundles
    {
        private const string Tag = "BuildAssetBundles";

        private static readonly List<BuildTargetEntity> BuildTargetEntities = new List<BuildTargetEntity>
        {
            // new BuildTargetEntity {TargetPlatform = BuildTarget.NoTarget, Path = "NoTarget" },
            new BuildTargetEntity {TargetPlatform = BuildTarget.StandaloneWindows, Path = "StandaloneWindows"},
            new BuildTargetEntity {TargetPlatform = BuildTarget.StandaloneWindows64, Path = "StandaloneWindows64"},
            new BuildTargetEntity {TargetPlatform = BuildTarget.Android, Path = "Android"},
            // new BuildTargetEntity(BuildTarget.iOS, "iOS")
        };

        private static readonly List<AssetBundleBuild> AssetBundleBuilds = new List<AssetBundleBuild>
        {
            new AssetBundleBuild
                {assetBundleName = "Image", assetNames = new string[1] {"Assets/AssetBundleResources/Image/man.png"}}
        };

        [UnityEditor.MenuItem("Project/Build Asset Bundles")]
        public static void Build()
        {
            Debug.LogFormat("({0}){1}", Tag, string.Format("Build"));
            foreach (var target in BuildTargetEntities)
            {
                var targetDir = "Assets/AssetBundle/" + target.Path + "/";
                if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);
                BuildPipeline.BuildAssetBundles(targetDir, AssetBundleBuilds.ToArray(),
                    BuildAssetBundleOptions.ChunkBasedCompression, target.TargetPlatform);
            }
        }

        private struct BuildTargetEntity
        {
            public BuildTarget TargetPlatform;
            public string Path;
        }
    }
}