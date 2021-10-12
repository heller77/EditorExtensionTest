using UnityEditor;
using UnityEngine;
  
public class TextureResizeWindow : EditorWindow
{
    [MenuItem("Tools/Texture/Resize")]
    private static void Show()
    {
        var window = GetWindow<TextureResizeWindow>("Resize");
    }
  
    private Texture2D _texture;
    private Vector2Int _size;
 
    private void OnGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            _texture = (Texture2D) EditorGUILayout.ObjectField("Texture", _texture, typeof(Texture2D), false);
            if (check.changed)
            {
                _size = new Vector2Int(_texture.width, _texture.height);
            }
        }
        _size = EditorGUILayout.Vector2IntField("Size", _size);
        if (GUILayout.Button("Resize"))
        {
            Resize(_texture, _size);
        }
    }
    private static void Resize(Texture2D src, Vector2Int size)
    {
        var texture = new Texture2D(size.x, size.y, src.format, src.mipmapCount == -1);
        var path = AssetDatabase.GetAssetPath(src);
        var importer = AssetImporter.GetAtPath(path) as TextureImporter;
 
        var isChange = !importer.isReadable;
        if (isChange)
        {
            importer.isReadable = true;
            importer.SaveAndReimport();
            AssetDatabase.Refresh();
        }
 
        var pixels = texture.GetPixels(0);
        for(var i = 0; i < pixels.Length; i++)
        {
            pixels[i] = src.GetPixelBilinear(
                i % size.x * (1 / (float) size.x),
                Mathf.Floor(i / (float)size.x) * (1 / (float) size.y)
            );
        }
 
        texture.SetPixels(pixels, 0);
        texture.Apply();
        System.IO.File.WriteAllBytes(path.Replace('/', System.IO.Path.DirectorySeparatorChar), texture.EncodeToPNG());
        AssetDatabase.Refresh();
        if (isChange)
        {
            var importer2 = AssetImporter.GetAtPath(path) as TextureImporter;
            importer2.isReadable = false;
            importer2.SaveAndReimport();
        }
    }
}