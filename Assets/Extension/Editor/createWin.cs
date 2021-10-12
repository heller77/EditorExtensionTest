using UnityEditor;
using UnityEngine;

namespace Extension.Editor
{
    public class createWin
    {
        [MenuItem("tools/m44")]
        static void createWindow()
        {
            // GetWindow<MyEditorExtension>("Mywindow");
            EditorWindow.GetWindow<MyEditorExtension2>("test");
        }

    }
}