using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(WorldGenerator))]

public class WorldGeneratorEditor : Editor
{
    private SerializedProperty serializedSize;
    private SerializedProperty serializedTemplate;

    private void OnEnable()
    {
        serializedSize = serializedObject.FindProperty("size");
        serializedTemplate = serializedObject.FindProperty("template");
    }

    private void OnSceneGUI()
    {
        Handles.DrawSolidRectangleWithOutline(new Rect(0, 0, 20, 1), Color.red, Color.black);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Rect sizePosition = GUILayoutUtility.GetRect(0, 40);
        serializedSize.vector3Value = EditorGUI.Vector3Field(sizePosition, "Size", serializedSize.vector3Value);

        Rect templatePosition = GUILayoutUtility.GetRect(0, 20);
        serializedTemplate.objectReferenceValue = EditorGUI.ObjectField(templatePosition, "Template", serializedTemplate.objectReferenceValue, typeof(GameObject), false);

        Rect buttonPosition = GUILayoutUtility.GetRect(0, 20);
        if(GUI.Button(buttonPosition, "Generate"))
        {
            GameObject template = (GameObject)Instantiate(serializedTemplate.objectReferenceValue);
            template.transform.localScale = serializedSize.vector3Value;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
