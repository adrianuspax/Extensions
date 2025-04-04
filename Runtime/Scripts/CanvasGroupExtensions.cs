using System.Collections;
using UnityEngine;

namespace ASPax.Extensions
{
    public static class CanvasGroupExtensions
    {
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
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, alpha;
                var runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);
                    canvasGroup.alpha = alpha;
                    yield return null;
                }

                canvasGroup.alpha = 1f;
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="targetAlpha">Alpha target</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup canvasGroup, float totalTime, float targetAlpha, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, runningAlpha;
                var runningTime = 0f;

                targetAlpha = Mathf.Clamp01(targetAlpha);

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    runningAlpha = Mathf.Lerp(0f, targetAlpha, t);
                    canvasGroup.alpha = runningAlpha;
                    yield return null;
                }

                canvasGroup.alpha = targetAlpha;
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
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, alpha;
                var runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);
                    canvasGroups.SetAlpha(alpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(1f);
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroups">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// /// <param name="targetAlpha">Alpha target</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup[] canvasGroups, float totalTime, float targetAlpha, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, runningAlpha;
                var runningTime = 0f;

                targetAlpha = Mathf.Clamp01(targetAlpha);

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    runningAlpha = Mathf.Lerp(0f, targetAlpha, t);
                    canvasGroups.SetAlpha(runningAlpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(targetAlpha);
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
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, alpha;
                var runningTime = 0f;
                var previousAlpha = canvasGroup.alpha;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);

                    canvasGroup.alpha = alpha;
                    yield return null;
                }

                canvasGroup.alpha = 0f;
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
            monoBehaviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                float t, alpha;
                var runningTime = 0f;
                var previousAlpha = 1f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);
                    canvasGroups.SetAlpha(alpha);
                    yield return null;
                }

                canvasGroups.SetAlpha(0f);
            }
        }
        /// <summary>
        /// Start Ping Pong Alpha
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="frequence">frequence of ping pong</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void AlphaPingPong(this CanvasGroup canvasGroup, float frequence, bool isStart, MonoBehaviour monoBehaviour)
        {
            var alpha = canvasGroup.alpha;
            var routine = _routine(canvasGroup, frequence);

            if (isStart)
            {
                monoBehaviour.StartCoroutine(routine);
            }
            else
            {
                monoBehaviour.StopCoroutine(routine);
                canvasGroup.alpha = alpha;
            }

            IEnumerator _routine(CanvasGroup canvasGroup, float frequence)
            {
                var t = 0f;

                do
                {
                    t += Time.deltaTime;
                    canvasGroup.alpha = Mathf.PingPong(t * frequence, 1f);
                    yield return null;
                }
                while (isStart);
            }
        }
    }
}
