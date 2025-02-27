using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Get the children of a game object
        /// </summary>
        /// <returns>Transform</returns>
        public static Transform GetChildren(this GameObject gameObject, params int[] children)
        {
            var transform = gameObject.transform;

            if (children.IsEmpty())
                return transform;

            for (var i = 0; i < children.Length; i++)
                transform = transform.GetChild(children[i]);

            return transform;
        }
        /// <summary>
        /// Checks if a Game Object is null
        /// </summary>
        /// <param name="gameObject">component</param>
        /// <returns>true if the gameObject is null</returns>
        public static bool IsNull(this GameObject gameObject)
        {
            return gameObject == null;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <param name="gameObjects">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this GameObject[] gameObjects)
        {
            if (gameObjects == null || gameObjects.Length == 0)
                return false;
            else
                return gameObjects.All(obj => obj == null);
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this GameObject parameter, ref GameObject globalVariable)
        {
            var isEquals = parameter == globalVariable;

            if (isEquals)
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}
