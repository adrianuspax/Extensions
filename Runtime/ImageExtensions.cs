using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ASP.Extensions
{
    public static class ImageExtensions
    {
        public static void SetAlpha(this Image image, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            Color oldColor = image.color;
            image.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        }

        public static void SetColorLerp(this Image image, Color a, Color b, float time, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_run());

            IEnumerator _run()
            {
                float timeRunning = 0f;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    float t = timeRunning / time;
                    image.color = Color.Lerp(a, b, t);
                    yield return null;
                }

                image.color = b;
            }
        }

        public static void SetColorLerp(this Image image, Color color, float time, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_run());

            IEnumerator _run()
            {
                float timeRunning = 0f;
                Color originalColor = image.color;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    float t = timeRunning / time;
                    image.color = Color.Lerp(originalColor, color, t);
                    yield return null;
                }

                image.color = color;
            }
        }

        public static void SetAlphaLerp(this Image image, float alpha, float time, MonoBehaviour monoBehaviour)
        {
            if (alpha < 0f || alpha > 1f)
            {
                Debug.LogWarning($"The value of {nameof(alpha)} must be between 0 and 1 but the value is {alpha}!", monoBehaviour);
                return;
            }

            monoBehaviour.StartCoroutine(_run());

            IEnumerator _run()
            {
                float timeRunning = 0f;
                float originalAlpha = image.color.a;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    float t = timeRunning / time;
                    image.SetAlpha(Mathf.Lerp(originalAlpha, alpha, t));
                    yield return null;
                }

                image.SetAlpha(alpha);
            }
        }

        public static void SetFillAmountLerp(this Image image, float time, bool isIncreasing, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_run());

            IEnumerator _run()
            {
                float timeRunning;
                int a, b;

                timeRunning = 0f;
                a = isIncreasing ? 0 : 1;
                b = isIncreasing ? 1 : 0;

                while (timeRunning <= time)
                {
                    timeRunning += Time.deltaTime;
                    float t = timeRunning / time;
                    image.fillAmount = Mathf.Lerp(a, b, t);
                    yield return null;
                }

                image.fillAmount = b;
            }
        }

        public static void SetColorFromGradient(this Image image, float alpha, float time, params Color[] colors)
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
