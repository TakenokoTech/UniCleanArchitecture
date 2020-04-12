using UnityEngine;

namespace Runtime.Utils
{
    public static class Prefs
    {
        private const string SamplePrefKey = "SamplePrefKey";
        public static string Sample
        {
            set => SetString(SamplePrefKey, value);
            get => GetString(SamplePrefKey, "");
        }

        private static int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
        private static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
        
        private static float? GetFloat(string key, float defaultValue) => PlayerPrefs.GetFloat(key, defaultValue);
        private static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }
        
        private static string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);
        private static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }
        
        public static void ClearAll() => PlayerPrefs.DeleteAll();
    }
}