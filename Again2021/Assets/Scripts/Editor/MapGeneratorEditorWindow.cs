using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class MapGeneratorEditorWindow : EditorWindow
{
    
    private static Vector2 Size = new Vector2(375, 300);

    private Vector2 size;
    
    private float weight;
    
    private float lenght;
    
    private float height;
    
    private bool genFlag = true;
    
    private float perlinNoise;
    
    private float minY;
    
    private float maxY;

    private MapGenData data;
    private GenericMenu presetMenu;
    
    [MenuItem("Tools/MapGenerator")]
    public static void Open()
    {
        MapGeneratorEditorWindow window = GetWindow<MapGeneratorEditorWindow>();
        window.titleContent = new GUIContent("Map Generator");
        window.minSize = Size;
        window.maxSize = Size;
        window.Show();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        data = MapGenData.ActualData;
        presetMenu = new GenericMenu();
        presetMenu.AddItem(new GUIContent("Item 1"), false, () =>
        {
            Debug.Log("Item1");
        } );
        presetMenu.AddItem(new GUIContent("Item 2"), false, () =>
        {
            Debug.Log("Item2");
        } );
        presetMenu.AddItem(new GUIContent("Item 3"), false, () =>
        {
            Debug.Log("Item3");
        } );
    }
    
    private void OnFocus()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.RepaintAll();
    }

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        weight = EditorGUILayout.Slider("Weight", weight, 0f, 50f);
        lenght = EditorGUILayout.Slider("Lenght", lenght, 0f, 50f);
        height = EditorGUILayout.Slider("Height", height, 0f, 50f);
        EditorGUI.EndChangeCheck();
        
        

        if (EditorGUI.EndChangeCheck())
        {
            SceneView.RepaintAll();
        }
        
        if (GUILayout.Button("Generate"))
        {
            genFlag = false;
            maxY = float.MinValue;
            minY = float.MaxValue;
            for (int i = 0; i < weight; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    
                    perlinNoise = Mathf.PerlinNoise(i / height, j / height) * 10f;
                    if (perlinNoise < minY) minY = perlinNoise;
                    if (perlinNoise > maxY) maxY = perlinNoise;
                    go.transform.position = new Vector3(1 * i,perlinNoise, 1 * j);
                }
            }
        }

//        Rect presetPathPosition = GUILayoutUtility.GetRect(0, 20);
//        GUI.Label(presetPathPosition, data.Text);
          Rect presetPosition = GUILayoutUtility.GetRect(0, 20);
          presetPosition = EditorGUI.PrefixLabel(presetPosition, new GUIContent("Preset"));
          if (GUI.Button(presetPosition, "Select Preset", EditorStyles.popup))
          {
              presetMenu.DropDown(presetPosition);
          }
    }

    
    private void OnSceneGUI(SceneView sceneView)
    {
        if (genFlag)
        {
            maxY = float.MinValue;
            minY = float.MaxValue;
            Handles.color = Color.green;
            Handles.DrawWireCube(new Vector3(10, maxY), new Vector3(20, 1, 1));
            Handles.DrawWireCube(new Vector3(10, minY), new Vector3(20, 1, 1));                    
            for (int i = 0; i < weight; i++)
            {
                for (int j = 0; j < lenght; j++)
                {                   
                    perlinNoise = Mathf.PerlinNoise(i / height, j / height) * 10f;  
                    if (perlinNoise < minY) minY = perlinNoise;
                    if (perlinNoise > maxY) maxY = perlinNoise;
//                    Handles.color = Color.green; 
                    Handles.DrawWireCube(new Vector3(1 * i, perlinNoise, 1 * j), new Vector3(1, 1, 1));                  
                }
            }
            Handles.color = Color.red;
            Handles.DrawWireCube(new Vector3(10, maxY), new Vector3(20, 1, 1));
            Handles.DrawWireCube(new Vector3(10, minY), new Vector3(20, 1, 1));        
        }        
    }
}
