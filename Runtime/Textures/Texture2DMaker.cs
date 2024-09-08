using System.Collections.Generic;
using UnityEngine;

namespace Slax.Utils
{
    public static class Texture2DMaker
    {
        #region Basic Textures

        /// <summary>
        /// Creates a texture with the specified width, height, and color.
        /// </summary>
        public static Texture2D MakeSolidColorTexture(int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(width, height);
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }
            texture.SetPixels(colors);
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// Creates a checkerboard pattern texture with the specified colors, width, height, and cell size.
        /// </summary>
        public static Texture2D MakeCheckerboardTexture(int width, int height, Color color1, Color color2, int cellSize)
        {
            Texture2D texture = new Texture2D(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isEvenCell = ((x / cellSize) + (y / cellSize)) % 2 == 0;
                    texture.SetPixel(x, y, isEvenCell ? color1 : color2);
                }
            }
            texture.Apply();
            return texture;
        }

        #endregion




        #region Gradient Textures

        /// <summary>
        /// Creates a gradient texture horizontally from leftColor to rightColor.
        /// </summary>
        public static Texture2D MakeHorizontalGradientTexture(int width, int height, Color leftColor, Color rightColor)
        {
            Texture2D texture = new Texture2D(width, height);
            for (int x = 0; x < width; x++)
            {
                Color color = Color.Lerp(leftColor, rightColor, (float)x / width);
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// Creates a vertical gradient texture from topColor to bottomColor.
        /// </summary>
        public static Texture2D MakeVerticalGradientTexture(int width, int height, Color topColor, Color bottomColor)
        {
            Texture2D texture = new Texture2D(width, height);
            for (int y = 0; y < height; y++)
            {
                Color color = Color.Lerp(topColor, bottomColor, (float)y / height);
                for (int x = 0; x < width; x++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// Creates a horizontal gradient texture from a list of colors.
        /// The colors will be evenly distributed across the texture's width.
        /// </summary>
        public static Texture2D MakeMultiColorGradientTexture(int width, int height, List<Color> colors)
        {
            Texture2D texture = new Texture2D(width, height);
            int segments = colors.Count - 1;
            float segmentWidth = (float)width / segments;

            for (int x = 0; x < width; x++)
            {
                int currentSegment = Mathf.Min((int)(x / segmentWidth), segments - 1);
                float t = (x % segmentWidth) / segmentWidth;
                Color color = Color.Lerp(colors[currentSegment], colors[currentSegment + 1], t);
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }

        /// <summary>
        /// Creates a horizontal gradient texture from a list of colors with specific steps for each color transition.
        /// </summary>
        public static Texture2D MakeMultiColorGradientWithSteps(int width, int height, List<Color> colors, List<int> steps)
        {
            if (steps.Count != colors.Count - 1)
            {
                Debug.LogError("Steps list must be one less than the colors list.");
                return null;
            }

            Texture2D texture = new Texture2D(width, height);
            int currentX = 0;

            for (int i = 0; i < steps.Count; i++)
            {
                int stepWidth = steps[i];
                for (int x = 0; x < stepWidth; x++)
                {
                    float t = (float)x / stepWidth;
                    Color color = Color.Lerp(colors[i], colors[i + 1], t);
                    for (int y = 0; y < height; y++)
                    {
                        texture.SetPixel(currentX + x, y, color);
                    }
                }
                currentX += stepWidth;
            }

            // Fill remaining width if steps don't cover the entire texture width
            if (currentX < width)
            {
                for (int x = currentX; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        texture.SetPixel(x, y, colors[colors.Count - 1]);
                    }
                }
            }

            texture.Apply();
            return texture;
        }

        #endregion
    }
}
