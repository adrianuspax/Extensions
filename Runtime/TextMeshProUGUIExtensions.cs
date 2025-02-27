using TMPro;
using UnityEngine;

namespace ASP.Extensions
{
    /// <summary>
    /// Code extension for Text Mesh Pro UGUI
    /// </summary>
    public static class TextMeshProUGUIExtensions
    {
        /// <summary>
        /// Set Text Mesh Pro's alpha directly
        /// </summary>
        /// <param name="textMeshPro">Text Mesh Pro UGUI</param>
        /// <param name="alpha">Text Mesh Pro alpha value between 0 and 1</param>
        public static void SetAlpha(this TextMeshProUGUI textMeshPro, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
        /// <summary>
        /// Set a Color From a Gradient Colors
        /// </summary>
        /// <param name="tmp">Text Mesh Pro</param>
        /// <param name="alpha">Text Mesh Pro Alpha</param>
        /// <param name="time">Time of evaluation gradient (0 ~ 1)</param>
        /// <param name="colors">colors of gradient</param>
        public static void SetColorFromGradient(this TextMeshProUGUI tmp, float alpha, float time, params Color[] colors)
        {
            int length = colors.Length;
            GradientColorKey[] GCK;
            GradientAlphaKey[] GAK;
            Gradient gradient = new();

            GAK = new GradientAlphaKey[1]
            {
                new(Mathf.Clamp01(alpha), 0.5f)
            };

            if (length == 1)
            {
                GCK = new GradientColorKey[2]
                {
                    new(colors[0], 0), new(colors[0], 1)
                };

                gradient.SetKeys(GCK, GAK);
                tmp.color = gradient.Evaluate(Mathf.Clamp01(time));
                return;
            }

            GCK = new GradientColorKey[length];

            for (int i = 0; i < length; i++)
            {
                GCK[i].color = colors[i];
                GCK[i].time = i / (length - 1f);
            }

            gradient.SetKeys(GCK, GAK);
            tmp.color = gradient.Evaluate(Mathf.Clamp01(time));
            return;
        }
    }
}
