using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MapGenData : ScriptableObject
{
    internal const string PathKey = "MapGenPresets";
    
    private const string DefaultPath = "Assets/Map Generator/Editor/Editor Resources";

//    [SerializeField] private string text = "eeeeeee";

//    public string Text
//    {
//        get => text;
//        set => text = value;
//    }



    public static MapGenData ActualData
    {
        get
        {
            string path = EditorPrefs.GetString(PathKey);
            if (string.IsNullOrEmpty(path))
            {
                path = DefaultPath;
                EditorPrefs.SetString(PathKey, path);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, "Map Generator Data.asset");
            
            MapGenData data = AssetDatabase.LoadAssetAtPath<MapGenData>(path);
            if (data == null)
            {
                data = CreateInstance<MapGenData>();
                AssetDatabase.CreateAsset(data, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            return data;
        }
    }
    
}
