using UnityEditor;
using UnityEngine;

namespace Extension.Editor
{
    public class createWin
    {
        [MenuItem("tools/my")]
        static void createWindow()
        {
            // GetWindow<MyEditorExtension>("Mywindow");
            EditorWindow.GetWindow<MyEditorExtension>("test");
        }

    }
}