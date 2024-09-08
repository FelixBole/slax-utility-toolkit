using UnityEngine;

namespace Slax.Utils
{
    public static class Texture2DHelper
    {
        /// <summary>
        /// Scales a Texture2D to a new width and height.
        /// </summary>
        public static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
        {
            RenderTexture rt = RenderTexture.GetTemporary(targetWidth, targetHeight);
            Graphics.Blit(source, rt);
            RenderTexture.active = rt;

            Texture2D result = new Texture2D(targetWidth, targetHeight);
            result.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
            result.Apply();

            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(rt);

            return result;
        }

        /// <summary>
        /// Converts a Texture2D to a sprite.
        /// </summary>
        public static Sprite TextureToSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        /// <summary>
        /// Fills an existing texture with a solid color.
        /// </summary>
        public static void FillTexture(Texture2D texture, Color color)
        {
            Color[] colors = new Color[texture.width * texture.height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }
            texture.SetPixels(colors);
            texture.Apply();
        }
    }
}
