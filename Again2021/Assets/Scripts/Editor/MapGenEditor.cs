using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(MapGenerator))]
public class MapGenEditor : Editor
{
    private SerializedProperty weight;
       
    private SerializedProperty lenght;
    
    private SerializedProperty height;
    
    private SerializedProperty lineMin;
    
    private SerializedProperty lineMax;

    private float perlinNoise;

    private bool genFlag = true;
       
    private void OnEnable()
    {
        weight = serializedObject.FindProperty("weight");
        lenght = serializedObject.FindProperty("lenght");
        height = serializedObject.FindProperty("height");
        lineMax = serializedObject.FindProperty("lineMax");
        lineMin = serializedObject.FindProperty("lineMin");   
    }

    private void OnSceneGUI()
    {
//        Handles.DrawSolidRectangleWithOutline(new Rect(0, lineMax.floatValue, 20, 1), Color.red, Color.black);
//        Handles.DrawSolidRectangleWithOutline(new Rect(0, lineMin.floatValue, 20, 1), Color.red, Color.black);
        if (genFlag)
        {
            lineMax.floatValue = float.MinValue;
            lineMin.floatValue = float.MaxValue;
            Handles.color = Color.red;
            Handles.DrawWireCube(new Vector3(10, lineMax.floatValue), new Vector3(20, 1, 1));
            Handles.DrawWireCube(new Vector3(10, lineMin.floatValue), new Vector3(20, 1, 1));                    
            for (int i = 0; i < weight.floatValue; i++)
            {
                 for (int j = 0; j < lenght.floatValue; j++)
                 {                   
                     perlinNoise = Mathf.PerlinNoise(i / height.floatValue, j / height.floatValue) * 10f;  
                     if (perlinNoise < lineMin.floatValue) lineMin.floatValue = perlinNoise;
                     if (perlinNoise > lineMax.floatValue) lineMax.floatValue = perlinNoise;
                     Handles.color = Color.green;                  
                     Handles.DrawWireCube(new Vector3(1 * i, perlinNoise, 1 * j), new Vector3(1, 1, 1));                  
                 }
            }
            Handles.color = Color.red;
            Handles.DrawWireCube(new Vector3(10, lineMax.floatValue), new Vector3(20, 1, 1));
            Handles.DrawWireCube(new Vector3(10, lineMin.floatValue), new Vector3(20, 1, 1));        
        }        
    }

    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();

        weight.floatValue = EditorGUILayout.Slider("Weight", weight.floatValue, 0f, 50f);
        lenght.floatValue = EditorGUILayout.Slider("Lenght", lenght.floatValue, 0f, 50f);
        height.floatValue = EditorGUILayout.Slider("Height", height.floatValue, 0f, 50f);

        if (GUILayout.Button("Generate"))
        {
            genFlag = false;
            lineMax.floatValue = float.MinValue;
            lineMin.floatValue = float.MaxValue;
            for (int i = 0; i < weight.floatValue; i++)
            {
                for (int j = 0; j < lenght.floatValue; j++)
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    
                    perlinNoise = Mathf.PerlinNoise(i / height.floatValue, j / height.floatValue) * 10f;
                    if (perlinNoise < lineMin.floatValue) lineMin.floatValue = perlinNoise;
                    if (perlinNoise > lineMax.floatValue) lineMax.floatValue = perlinNoise;
                    go.transform.position = new Vector3(1 * i,perlinNoise, 1 * j);
                }
            }
        }
        
        serializedObject.ApplyModifiedProperties();
    }

}
