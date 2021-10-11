using System;
using UnityEditor;
using UnityEngine;

namespace Extension.Editor
{
    public class MyEditorExtension : EditorWindow
    {
        private static TextureGenerator TG;

        public static TextureGenerator _TextureGenerator
        {
            get
            {
                if (TG is null)
                {
                    TG = new TextureGenerator();
                }

                return TG;
            }
        }

        private Color _color;
        private string filepath = "";
        private string filename = "tex";
        private Vector2Int filesize = new Vector2Int(100, 100);

        [MenuItem("tools/mywindow")]
        static void createWindow()
        {
            GetWindow<MyEditorExtension>("Mywindow");
        }

        private void OnGUI()
        {
            GUI.backgroundColor = Color.white;
            EditorGUILayout.LabelField("共通設定");

            EditorGUILayout.BeginVertical();
            {
                _color = EditorGUILayout.ColorField("色", _color);


                filepath = EditorGUILayout.TextField("ファイルパス", filepath);
                filename = EditorGUILayout.TextField("ファイル名", filename);
                filesize = EditorGUILayout.Vector2IntField("ファイルサイズ", filesize);
            }
            EditorGUILayout.EndVertical();

            GUI.backgroundColor = Color.black;
            EditorGUILayout.Space(10);


            EditorGUILayout.LabelField("テクスチャ作成");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("単色テクスチャ生成", GUILayout.MinHeight(100)))
            {
                _TextureGenerator.createTexture(filepath, filename, _color);
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(2);

            EditorGUILayout.LabelField("ランダムテクスチャ生成");
            EditorGUILayout.BeginHorizontal(GUI.skin.box);
            {
                if (GUILayout.Button("ホワイトノイズ生成", GUILayout.MinHeight(100)))
                {
                    _TextureGenerator.createNoiseTexture(filepath, filename,filesize.x,filesize.y);
                }

                if (GUILayout.Button("ブロックノイズ生成", GUILayout.MinHeight(100)))
                {
                }

                if (GUILayout.Button("パーリンノイズ生成", GUILayout.MinHeight(100)))
                {
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}