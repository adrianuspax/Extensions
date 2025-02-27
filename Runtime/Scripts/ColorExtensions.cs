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
            Color newColor;
            alpha = Mathf.Clamp01(alpha);

            newColor = color;
            newColor.a = alpha;
#pragma warning disable IDE0059
            color = newColor;
#pragma warning restore IDE0059
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
