using UnityEngine;

namespace ASPax.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Set the alpha of the color
        /// </summary>
        public static void SetAlpha(this Color color, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            Color newColor = color;
            newColor.a = alpha;
            color = newColor;
        }
        /// <summary>
        /// Set the alpha of the colors
        /// </summary>
        public static void SetAlpha(this Color[] colors, float alpha)
        {
            Color newColor;
            alpha = Mathf.Clamp01(alpha);

            for (var i = 0; i < colors.Length; i++)
            {
                newColor = colors[i];
                newColor.a = alpha;
                colors[i] = newColor;
            }
        }
    }
}
