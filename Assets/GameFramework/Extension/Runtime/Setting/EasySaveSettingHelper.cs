using System;
using System.Collections.Generic;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public class EasySaveSettingHelper : SettingHelperBase
    {
        public override int Count
        {
            get
            {
                if (!ES3.FileExists())
                {
                    return 0;
                }

                string[] keys = ES3.GetKeys();
                return keys?.Length ?? 0;
            }
        }

        public override bool Load()
        {
            try
            {
                ES3.Init();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Save()
        {
            return true;
        }

        public override string[] GetAllSettingNames()
        {
            return !ES3.FileExists() ? null : ES3.GetKeys();
        }

        public override void GetAllSettingNames(List<string> results)
        {
            if (results == null)
            {
                throw new GameFrameworkException($"Invalid setting name list '{null}'.");
            }

            results.Clear();
            if (!ES3.FileExists())
            {
                return;
            }

            string[] keys = ES3.GetKeys();
            if (keys != null && keys.Length > 0)
            {
                results.AddRange(keys);
            }
        }

        public override bool HasSetting(string settingName)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            return ES3.FileExists() && ES3.KeyExists(settingName);
        }

        public override bool RemoveSetting(string settingName)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            if (!ES3.FileExists())
            {
                return false;
            }

            ES3.DeleteKey(settingName);
            return true;
        }

        public override void RemoveAllSettings()
        {
            if (!ES3.FileExists())
            {
                return;
            }

            ES3.DeleteFile();
        }

        public override bool GetBool(string settingName)
        {
            return GetBool(settingName, false);
        }

        public override bool GetBool(string settingName, bool defaultValue)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            return !ES3.FileExists() ? defaultValue : ES3.Load(settingName, defaultValue);
        }

        public override void SetBool(string settingName, bool value)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            ES3.Save(settingName, value);
        }

        public override int GetInt(string settingName)
        {
            return GetInt(settingName, 0);
        }

        public override int GetInt(string settingName, int defaultValue)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            return !ES3.FileExists() ? defaultValue : ES3.Load(settingName, defaultValue);
        }

        public override void SetInt(string settingName, int value)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            ES3.Save(settingName, value);
        }

        public override float GetFloat(string settingName)
        {
            return GetFloat(settingName, 0f);
        }

        public override float GetFloat(string settingName, float defaultValue)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            return !ES3.FileExists() ? defaultValue : ES3.Load(settingName, defaultValue);
        }

        public override void SetFloat(string settingName, float value)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            ES3.Save(settingName, value);
        }

        public override string GetString(string settingName)
        {
            return GetString(settingName, null);
        }

        public override string GetString(string settingName, string defaultValue)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            return !ES3.FileExists()
                ? defaultValue
                : ES3.Load(settingName, ES3Settings.defaultSettings.path, defaultValue, ES3Settings.defaultSettings);
        }

        public override void SetString(string settingName, string value)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            ES3.Save(settingName, value);
        }

        public override T GetObject<T>(string settingName)
        {
            return GetObject<T>(settingName, default);
        }

        public override object GetObject(Type objectType, string settingName)
        {
            return GetObject(objectType, settingName, default);
        }

        public override T GetObject<T>(string settingName, T defaultObj)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            if (!ES3.FileExists())
            {
                return defaultObj;
            }

            string json = GetString(settingName, null);
            // string <-> object 之间的转换有时会出现 'NULL' 的问题，强制进行转换。
            return string.IsNullOrEmpty(json) ? defaultObj : Utility.Json.ToObject<T>(json);
        }

        public override object GetObject(Type objectType, string settingName, object defaultObj)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            if (!ES3.FileExists())
            {
                return defaultObj;
            }

            string json = GetString(settingName, null);
            // string <-> object 之间的转换有时会出现 'NULL' 的问题，强制进行转换。
            return string.IsNullOrEmpty(json) ? defaultObj : Utility.Json.ToObject(objectType, json);
        }

        public override void SetObject<T>(string settingName, T obj)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            // string <-> object 之间的转换有时会出现 'NULL' 的问题，强制进行转换。
            SetString(settingName, obj == null ? "" : Utility.Json.ToJson(obj));
        }

        public override void SetObject(string settingName, object obj)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new GameFrameworkException($"Invalid setting name '{settingName}'.");
            }

            // string <-> object 之间的转换有时会出现 'NULL' 的问题，强制进行转换。
            SetString(settingName, obj == null ? "" : Utility.Json.ToJson(obj));
        }
    }
}