using System;
using UnityEditor;
using UnityEngine;

namespace Extension.Editor
{
    public class MyEditorExtension : EditorWindow
    {
        [MenuItem("tools/mywindow")]
        static void createWindow()
        {
            GetWindow<MyEditorExtension>("Mywindow");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("hello world");

            GUILayout.Label("hogho");
            if (GUILayout.Button("button"))
            {
                Debug.Log("button on");
            }
        }
    }
}