using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Extension.Editor
{
    public class TextureGenerator
    {
        public void createTexture(string path,string filename,Color color)
        {
            Texture2D texture = CreateOneColorTexture(100, 100, color);
            path = "Assets/"+path+"/"+filename+".png";
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
            Debug.Log("画像出来た");
            AssetDatabase.Refresh();
        }

        private static Texture2D CreateOneColorTexture(int width, int height, Color color)
        {
            var texture = new Texture2D(width, height, TextureFormat.RGB24, false);

            for (int x = 0;  x< texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    texture.SetPixel(x,y,color);
                }
            }
            return texture;
        }

        public void createNoiseTexture(string path,string filename)
        {
            Texture2D texture = createWhiteNoise(100, 100);
            path = "Assets/"+path+"/"+filename+".png";
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
            Debug.Log("ノイズ画像出来た");
            AssetDatabase.Refresh();
        }
        private static Texture2D createWhiteNoise(int width, int height)
        {
            Debug.Log("noise start");
            var texture = new Texture2D(width, height,TextureFormat.RGB24,false);
            System.Random ra = new System.Random();
            for (int x = 0;  x< texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    var color = (float)ra.NextDouble();
                    texture.SetPixel(x,y,new Color(color,color,color));
                }

            }

            return texture;
        }
    }
}