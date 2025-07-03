using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    /// <summary>
    /// Color Extensions
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Checks if colors array is empty or null
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static bool IsEmptyOrNull(this Color[] colors)
        {
            if (colors == null || colors.Length == 0) return true;
            else return colors.All(obj => obj == null);
        }
        /// <summary>
        /// Return the color with the new alpha value
        /// </summary>
        /// <param name="alpha">Alpha value in a range from 0 to 1</param>
        public static Color GetWithAlpha(this Color color, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            return new(color.r, color.g, color.b, alpha);
        }
        /// <summary>
        /// Return the color array with the new alpha value
        /// </summary>
        /// <param name="alpha">Alpha value in a range from 0 to 1</param>
        public static Color[] GetWithAlpha(this Color[] colors, float alpha)
        {
            var ncolors = new Color[colors.Length];
            alpha = Mathf.Clamp01(alpha);

            for (var i = 0; i < ncolors.Length; i++)
                ncolors[i] = new Color(colors[i].r, colors[i].g, colors[i].b, alpha);
            return ncolors;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Color parameter, ref Color globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this Color[] parameter, ref Color[] globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}
