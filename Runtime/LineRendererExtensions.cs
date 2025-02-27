using System.Collections;
using UnityEngine;

namespace ASP.Extensions
{
    public static class LineRendererExtensions
    {
        private static Coroutine _coroutine = null;
        private static MonoBehaviour _monoBehaviour = null;
        private static readonly MaterialPropertyBlock _materialPropertyBlock = new();
        private const string TEXTURE = "_MainTex";
        private const string TEXTURE_ST = "_MainTex_ST";
        /// <summary>
        /// Set texture in line renderer
        /// </summary>
        /// <param name="lineRenderer">line renderer</param>
        /// <param name="texture">texture to line renderer (use sprite.texture)</param>
        /// <param name="materialIndex">Indexes of the materials to be changed</param>
        public static void SetTexture(this LineRenderer lineRenderer, Texture texture, params int[] materialIndex)
        {
            if (materialIndex == default)
            {
                _set(0);
                return;
            }

            foreach (int index in materialIndex)
            {
                _set(index);
            }

            void _set(int index)
            {
                if (lineRenderer.materials[index].HasProperty(TEXTURE))
                {
                    lineRenderer.GetPropertyBlock(_materialPropertyBlock, index);
                    _materialPropertyBlock.SetTexture(TEXTURE, texture);
                    lineRenderer.SetPropertyBlock(_materialPropertyBlock, index);
                }
            }
        }
        /// <summary>
        /// Set offset in line renderer
        /// </summary>
        /// <param name="lineRenderer">Line renderer</param>
        /// <param name="offset">Vector2 to change offset</param>
        /// <param name="materialIndex">Indexes of the materials to be changed</param>
        public static void SetOffset(this LineRenderer lineRenderer, Vector2 offset, params int[] materialIndex)
        {
            if (materialIndex == default)
            {
                _set(0);
                return;
            }

            foreach (int index in materialIndex)
            {
                _set(index);
            }

            void _set(int index)
            {
                if (lineRenderer.materials[index].HasProperty(TEXTURE_ST))
                {
                    Vector4 value = new(1f, 1f, offset.x, offset.y);
                    lineRenderer.GetPropertyBlock(_materialPropertyBlock, index);
                    _materialPropertyBlock.SetVector(TEXTURE_ST, value);
                    lineRenderer.SetPropertyBlock(_materialPropertyBlock, index);
                }
            }
        }
        /// <summary>
        /// Set Animation Offset
        /// </summary>
        /// <param name="lineRenderer">Line renderer</param>
        /// <param name="speed">speed of animation in axis</param>
        /// <param name="monoBehaviour">MonoBehaviour to coroutine (use this)</param>
        /// <param name="materialIndex">Indexes of the materials to be changed</param>
        public static void StartDynamicOffset(this LineRenderer lineRenderer, Vector2 speed, MonoBehaviour monoBehaviour, params int[] materialIndex)
        {
            if (materialIndex == default)
            {
                _set(0);
                return;
            }

            foreach (int index in materialIndex)
            {
                _set(index);
            }

            void _set(int index)
            {
                if (lineRenderer.materials[index].HasProperty(TEXTURE_ST))
                {
                    _monoBehaviour = monoBehaviour;
                    _coroutine ??= monoBehaviour.StartCoroutine(_run());
                }
            }

            IEnumerator _run()
            {
                float time = 0f;

                do
                {
                    time += Time.deltaTime;
                    lineRenderer.SetOffset(speed * time, materialIndex);
                    yield return null;
                }
                while (speed != Vector2.zero);
                _coroutine = null;
            }
        }
        /// <summary>
        /// Stop animation Line Renderer Offset
        /// </summary>
        /// <param name="lineRenderer">Line Renderer</param>
        /// <param name="materialIndex">Indexes of the materials to be changed</param>
        public static void StopDynamicOffset(this LineRenderer lineRenderer, params int[] materialIndex)
        {
            if (materialIndex == default)
            {
                _set(0);
                return;
            }

            foreach (int index in materialIndex)
            {
                _set(index);
            }

            void _set(int index)
            {
                if (_monoBehaviour == null || _coroutine == null)
                    return;

                lineRenderer.SetOffset(Vector2.zero, index);
                _monoBehaviour.StopCoroutine(_coroutine);
                _monoBehaviour = null;
            }
        }
    }
}
