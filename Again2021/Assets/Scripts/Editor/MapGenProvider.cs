using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenProvider : SettingsProvider
{
    
    private MapGenData data;
    
    public MapGenProvider(string path, SettingsScope scope = SettingsScope.Project) : base(path, scope)
    {
        
    }

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        data = MapGenData.ActualData;
    }

    public override void OnGUI(string searchContext)
    {
        string settingsPath = EditorPrefs.GetString(MapGenData.PathKey);
        settingsPath = EditorGUILayout.DelayedTextField("Settings Path", settingsPath);
        EditorPrefs.SetString(MapGenData.PathKey, settingsPath);
//        EditorGUILayout.TextField("PresetPath", "Folder Path...");
        
    }

    [SettingsProvider]
    public static SettingsProvider CreateProvider()
    {
        MapGenProvider provider = new MapGenProvider("Project/Map Generator", SettingsScope.Project);
        return provider;
    }
}
