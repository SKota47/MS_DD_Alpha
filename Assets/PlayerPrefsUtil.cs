using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsUtil
{
    public static bool GetBool(string key, bool defaultValue)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return defaultValue;
        }
        return GetBool(key);
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) != 0;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static T GetObject<T>(string key, T defaultValue)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return defaultValue;
        }
        return GetObject<T>(key);
    }

    public static T GetObject<T>(string key)
    {
        string json = PlayerPrefs.GetString(key, "{}");
        return JsonUtility.FromJson<T>(json);
    }

    public static void SetObject<T>(string key, T value)
    {
        string json = JsonUtility.ToJson(value);
        PlayerPrefs.SetString(key, json);
    }

}