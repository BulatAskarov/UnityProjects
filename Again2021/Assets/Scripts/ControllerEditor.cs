using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Controller))]
public class ControllerEditor : Editor
{

    private SerializedProperty walkSpeed;
       
    private SerializedProperty runSpeed;
    
    private SerializedProperty jumpSpeed;
       
    private SerializedProperty jumpForce;

    private bool isWalkSpeedExpanded;
    
    private bool isJumpSpeedExpanded;
    

    private void OnEnable()
    {
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        runSpeed = serializedObject.FindProperty("runSpeed");
        jumpSpeed = serializedObject.FindProperty("jumpSpeed");
        jumpForce = serializedObject.FindProperty("jumpForce");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
//        EditorGUILayout.PropertyField(walkSpeed); 
//        EditorGUILayout.PropertyField(runSpeed);

        walkSpeed.floatValue = EditorGUILayout.Slider("Walk Speed Slider", walkSpeed.floatValue, 0, runSpeed.floatValue);
        runSpeed.floatValue = EditorGUILayout.Slider("Run Speed Slider", runSpeed.floatValue, walkSpeed.floatValue, 50);
        
        EditorGUILayout.HelpBox("Helpful information", MessageType.Info);
        
        
        GUILayout.BeginVertical(EditorStyles.helpBox);
        {
            GUILayout.BeginVertical(EditorStyles.helpBox);
            {
                isWalkSpeedExpanded = EditorGUILayout.Foldout(isWalkSpeedExpanded, "Walk Speed");
                            if (isWalkSpeedExpanded)
                            {
                                walkSpeed.floatValue = EditorGUILayout.FloatField(walkSpeed.floatValue);
                                runSpeed.floatValue = EditorGUILayout.FloatField(runSpeed.floatValue);
                            }
            }   
            GUILayout.EndVertical();
            
            GUILayout.BeginVertical(EditorStyles.helpBox);
            {
                isJumpSpeedExpanded = EditorGUILayout.Foldout(isJumpSpeedExpanded, "JumpSpeed");
                if (isJumpSpeedExpanded)
                {
                    jumpSpeed.floatValue = EditorGUILayout.FloatField(jumpSpeed.floatValue);
                    jumpForce.floatValue = EditorGUILayout.FloatField(jumpForce.floatValue);
                }
            }   
            GUILayout.EndVertical();

        }  
        GUILayout.EndVertical();

        if (walkSpeed.floatValue < 0f)
        {
            walkSpeed.floatValue = 0f;
        }
        
        if (runSpeed.floatValue > 50f)
        {
            runSpeed.floatValue = 50f;
        }
        
//        if (runSpeed.floatValue < walkSpeed.floatValue)
//        {
//            runSpeed.floatValue = walkSpeed.floatValue;
//        }
//        
        
        serializedObject.ApplyModifiedProperties();
    }
}
