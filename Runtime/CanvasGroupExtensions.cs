using System.Collections;
using UnityEngine;

namespace ASPax.Extensions
{
    public static class CanvasGroupExtensions
    {
        private static readonly Coroutine[] coroutine = new Coroutine[8];
        private static readonly float[] values = new float[2];
        /// <summary>
        /// Set alpha in Canvas Group
        /// </summary>
        /// <param name="canvasGroups">Canvas Group</param>
        /// <param name="alpha">Panel Fade in a range from 0 to 1</param>
        public static void SetAlpha(this CanvasGroup[] canvasGroups, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);

            foreach (CanvasGroup canvasGroup in canvasGroups)
                canvasGroup.alpha = alpha;
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
        {
            if (coroutine[0] == null)
            {
                values[0] = canvasGroup.alpha;
                coroutine[0] = monoBehaviour.StartCoroutine(_fadeIn());
            }

            IEnumerator _fadeIn()
            {
                float runningTime, t, alpha;
                runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);
                    canvasGroup.alpha = alpha;
                    yield return null;
                }

                canvasGroup.alpha = values[0];
                coroutine[0] = null;
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="alpha">Alpha target</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup canvasGroup, float totalTime, float alpha, MonoBehaviour monoBehaviour)
        {
            coroutine[1] ??= monoBehaviour.StartCoroutine(_fadeIn());

            IEnumerator _fadeIn()
            {
                float runningTime, t, runningAlpha;

                runningTime = 0f;
                alpha = Mathf.Clamp01(alpha);

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    runningAlpha = Mathf.Lerp(0f, alpha, t);
                    canvasGroup.alpha = runningAlpha;
                    yield return null;
                }

                canvasGroup.alpha = alpha;
                coroutine[1] = null;
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroups">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup[] canvasGroups, float totalTime, MonoBehaviour monoBehaviour)
        {
            coroutine[2] ??= monoBehaviour.StartCoroutine(_fadeIn());

            IEnumerator _fadeIn()
            {
                float runningTime, t, alpha;
                runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);
                    canvasGroups.SetAlpha(alpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(1f);
                coroutine[2] = null;
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroups">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// /// <param name="alpha">Alpha target</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup[] canvasGroups, float totalTime, float alpha, MonoBehaviour monoBehaviour)
        {
            coroutine[3] ??= monoBehaviour.StartCoroutine(_fadeIn());

            IEnumerator _fadeIn()
            {
                float runningTime, t, runningAlpha;

                runningTime = 0f;
                alpha = Mathf.Clamp01(alpha);

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    runningAlpha = Mathf.Lerp(0f, alpha, t);
                    canvasGroups.SetAlpha(runningAlpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(alpha);
                coroutine[3] = null;
            }
        }
        /// <summary>
        /// Fade out of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeOut(this CanvasGroup canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
        {
            coroutine[4] ??= monoBehaviour.StartCoroutine(_fadeOut());

            IEnumerator _fadeOut()
            {
                float runningTime, t, alpha, previousAlpha;
                runningTime = 0f;
                previousAlpha = canvasGroup.alpha;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);

                    canvasGroup.alpha = alpha;
                    yield return null;
                }

                canvasGroup.alpha = 0f;
                coroutine[4] = null;
            }
        }
        /// <summary>
        /// Fade out of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroups">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeOut(this CanvasGroup[] canvasGroups, float totalTime, MonoBehaviour monoBehaviour)
        {
            coroutine[5] ??= monoBehaviour.StartCoroutine(_fadeOut());

            IEnumerator _fadeOut()
            {
                float runningTime, t, alpha, previousAlpha;
                runningTime = 0f;
                previousAlpha = 1f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);
                    canvasGroups.SetAlpha(alpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(0f);
                coroutine[5] = null;
            }
        }
        /// <summary>
        /// Start Ping Pong Alpha
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="frequence">frequence of ping pong</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void StartAlphaPingPong(this CanvasGroup canvasGroup, float frequence, MonoBehaviour monoBehaviour)
        {
            if (coroutine[6] == null)
            {
                values[1] = canvasGroup.alpha;
                coroutine[6] = monoBehaviour.StartCoroutine(_routine(canvasGroup, frequence));
            }

            IEnumerator _routine(CanvasGroup canvasGroup, float frequence)
            {
                float t = 0;

                do
                {
                    t += Time.deltaTime;
                    canvasGroup.alpha = Mathf.PingPong(t * frequence, 1f);
                    yield return null;
                }
                while (coroutine[6] != null);
                coroutine[6] = null;
            }
        }
        /// <summary>
        /// Stop Ping Pong Alpha
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void StopAlphaPingPong(this CanvasGroup canvasGroup, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StopCoroutine(coroutine[6]);
            coroutine[6] = null;
            canvasGroup.alpha = values[1];
        }
    }
}


