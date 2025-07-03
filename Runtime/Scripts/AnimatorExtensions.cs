using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    /// <summary>
    /// Extension methods for Animator
    /// </summary>
    public static class AnimatorExtensions
    {
        /// <summary>
        /// Checks if a Animator is null
        /// </summary>
        public static bool IsNull(this Animator animator)
        {
            return animator == null;
        }
        /// <summary>
        /// Checks if a Animator array is null or empty
        /// </summary>
        public static bool IsNullOrEmpty(this Animator[] animators)
        {
            if (animators == null || animators.Length == 0) return true;
            else return animators.All(obj => obj == null);
        }
        /// <summary>
        /// Returns the time of the animation clip
        /// </summary>
        /// <param name="clipName">Name of the animation clip you want to know the animation time of</param>
        /// <returns>Time in seconds of the animation clip</returns>
        public static float? GetClipLength(this Animator animator, string clipName)
        {
            int clipNameHash2;
            float? length = null;
            var clipNameHash1 = Animator.StringToHash(clipName);

            for (var i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                clipNameHash2 = Animator.StringToHash(animator.runtimeAnimatorController.animationClips[i].name);

                if (clipNameHash1 == clipNameHash2)
                {
                    length = animator.runtimeAnimatorController.animationClips[i].length;
                    break;
                }
            }

            if (length == null)
                Debug.LogWarning($"Could not find an animatorClip whose name is {clipName} in the {animator.name} animation!");
            return length;
        }
        /// <summary>
        /// Returns the time of the animation clip
        /// </summary>
        /// <param name="id">ID of the animation clip you want to know the animation time of</param>
        /// <returns>Time in seconds of the animation clip</returns>
        public static float? GetClipLength(this Animator animator, int id)
        {
            int clipNameHash;
            float? length = null;

            for (var i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                clipNameHash = Animator.StringToHash(animator.runtimeAnimatorController.animationClips[i].name);

                if (id == clipNameHash)
                {
                    length = animator.runtimeAnimatorController.animationClips[i].length;
                    break;
                }
            }

            if (length == null)
                Debug.LogWarning($"Could not find an animatorClip whose id is {id} in the {animator.name} animation!", default);
            return length;
        }
        /// <summary>
        /// Returns the sum of the time of the animations
        /// </summary>
        /// <param name="clipNames">Name of the animation clip you want to know the animation time sum of</param>
        /// <returns>Time in seconds of sum the animation clip</returns>
        public static float? GetSumClipsLength(this Animator animator, params string[] clipNames)
        {
            float? length = null;

            foreach (var clipName in clipNames)
            {
                var value = animator.GetClipLength(clipName);

                if (value == null)
                    return null;

                length += value;
            }

            return length;
        }
        /// <summary>
        /// Returns the sum of the time of the animations
        /// </summary>
        /// <param name="ids">IDs of the animation clip you want to know the animation time sum of</param>
        /// <returns>Time in seconds of sum the animation clip</returns>
        public static float? GetSumClipsLength(this Animator animator, params int[] ids)
        {
            float? length = null;

            foreach (var id in ids)
            {
                var value = animator.GetClipLength(id);

                if (value == null)
                    return null;

                length += value;
            }

            return length;
        }
    }
}
