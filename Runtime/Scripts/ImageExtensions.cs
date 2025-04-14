using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ASPax.Extensions
{
    public static class ImageExtensions
    {
        /// <summary>
        /// returns true if the image is default
        /// </summary>
        public static bool IsDefault(this Image image)
        {
            return image == default;
        }
        /// <summary>
        /// Checks if a Image array is null or empty
        /// </summary>
        public static bool IsNullOrEmpty(this Image[] images)
        {
            if (images == null || images.Length == 0)
                return true;
            else
                return images.All(obj => obj == null);
        }
        /// <summary>
        /// Set the alpha of an image
        /// </summary>
        public static void SetAlpha(this Image image, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            var color = image.color;
            image.color = new(color.r, color.g, color.b, alpha);
        }
        /// <summary>
        /// Set the color animation lerping
        /// </summary>
        /// <param name="time">Time aniamtion</param>
        /// <param name="monoBehaviour">Mono Behaviour referente.</param>
        /// <remarks>Use <see cref="this"/> into class with <see cref="MonoBehaviour"/> inherited</remarks>
        public static void SetColorLerp(this Image image, Color a, Color b, float time, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                var timeRunning = 0f;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    var t = timeRunning / time;
                    image.color = Color.Lerp(a, b, t);
                    yield return null;
                }

                image.color = b;
            }
        }
        /// <summary>
        /// Set the color animation lerping
        /// </summary>
        /// <param name="time">Time aniamtion</param>
        /// <param name="monoBehaviour">Mono Behaviour referente.</param>
        /// <remarks>Use <see cref="this"/> into class with <see cref="MonoBehaviour"/> inherited</remarks>
        public static void SetColorLerp(this Image image, Color color, float time, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                var timeRunning = 0f;
                var originalColor = image.color;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    var t = timeRunning / time;
                    image.color = Color.Lerp(originalColor, color, t);
                    yield return null;
                }

                image.color = color;
            }
        }
        /// <summary>
        /// Set the color animation lerping
        /// </summary>
        /// <param name="time">Time aniamtion</param>
        /// <param name="monoBehaviour">Mono Behaviour referente.</param>
        /// <remarks>Use <see cref="this"/> into class with <see cref="MonoBehaviour"/> inherited</remarks>
        public static void SetAlphaLerp(this Image image, float alpha, float time, MonoBehaviour monoBehaviour)
        {
            alpha = Mathf.Clamp01(alpha);
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                var timeRunning = 0f;
                var originalAlpha = image.color.a;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    var t = timeRunning / time;
                    image.SetAlpha(Mathf.Lerp(originalAlpha, alpha, t));
                    yield return null;
                }

                image.SetAlpha(alpha);
            }
        }
        /// <summary>
        /// Set the fill amount animation lerping
        /// </summary>
        /// <param name="time">Total time of the animation</param>
        /// <param name="isIncreasing">If true is increasing</param>
        /// <param name="monoBehaviour">Mono Behaviour referente.</param>
        /// <remarks>Use <see cref="this"/> into class with <see cref="MonoBehaviour"/> inherited</remarks>
        public static void SetFillAmountLerp(this Image image, float time, bool isIncreasing, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                var timeRunning = 0f;
                var a = isIncreasing ? 0 : 1;
                var b = isIncreasing ? 1 : 0;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    var t = timeRunning / time;
                    image.fillAmount = Mathf.Lerp(a, b, t);
                    yield return null;
                }

                image.fillAmount = b;
            }
        }
        /// <summary>
        /// Set Color from Gradient
        /// </summary>
        /// <param name="time">Gradient Time between 0 and 1 - Is not time animation!</param>
        /// <param name="colors">The colors into gradient</param>
        public static void SetColorFromGradient(this Image image, float alpha, float time, params Color[] colors)
        {
            GradientColorKey[] GCK;
            var length = colors.Length;
            var gradient = new Gradient();
            var GAK = new GradientAlphaKey[1] { new(Mathf.Clamp01(alpha), 0.5f) };

            if (length == 1)
            {
                GCK = new GradientColorKey[2] { new(colors[0], 0), new(colors[0], 1) };
                gradient.SetKeys(GCK, GAK);
                image.color = gradient.Evaluate(Mathf.Clamp01(time));
                return;
            }

            GCK = new GradientColorKey[length];

            for (int i = 0; i < length; i++)
            {
                GCK[i].color = colors[i];
                GCK[i].time = i / (length - 1f);
            }

            gradient.SetKeys(GCK, GAK);
            image.color = gradient.Evaluate(Mathf.Clamp01(time));
            return;
        }
    }
}
