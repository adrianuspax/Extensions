using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Get the children of a component
        /// </summary>
        /// <returns>Transform</returns>
        public static Transform GetChildren(this Component component, params int[] children)
        {
            var transform = component.transform;

            if (children.IsEmpty())
                return transform;

            for (var i = 0; i < children.Length; i++)
                transform = transform.GetChild(children[i]);

            return transform;
        }
        /// <summary>
        /// Checks if a component is null
        /// </summary>
        /// <param name="component">component</param>
        /// <returns>true if the component is null</returns>
        public static bool IsNull(this Component component)
        {
            return component == null;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="components">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsNullOrEmpty(this Component[] components)
        {
            if (components == null || components.Length == 0)
                return false;
            else
                return components.All(obj => obj == null);
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Type of parameter and variable</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>true if the component was assign</returns>
        public static bool ComparativeAssignment(this Component parameter, ref Component globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Assign a component of an object that has it from the object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the child that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentIfNull<T>(this Component component, ref T variable, params int[] childrenIndexes) where T : Component
        {
            if (variable.IsNull())
            {
                Transform transform = component.transform;

                if (childrenIndexes.IsEmpty())
                {
                    variable = transform.GetComponent<T>();
                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variable = transform.GetComponent<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentInChildrenIfNull<T>(this Component component, ref T variable, params int[] childrenIndexes) where T : Component
        {
            if (variable.IsNull())
            {
                Transform transform = component.transform;

                if (childrenIndexes.IsEmpty())
                {
                    variable = transform.GetComponentInChildren<T>();
                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variable = transform.GetComponentInChildren<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function (And children's children)
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variables">Enter the array variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentsInAllChildrenIfNull<T>(this Component component, ref T[] variables, params int[] childrenIndexes) where T : Component
        {
            if (variables.IsNullOrEmpty())
            {
                var transform = component.transform;

                if (childrenIndexes.IsEmpty())
                {
                    variables = transform.GetComponentsInChildren<T>();
                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variables = transform.GetComponentsInChildren<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function (No children of children)
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variables">Enter the array variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentsInChildrenHeadersIfNull<T>(this Component component, ref T[] variables, params int[] childrenIndexes) where T : Component
        {
            if (variables.IsNullOrEmpty())
            {
                var header = component.transform;

                if (childrenIndexes.IsEmpty())
                {
                    variables = new T[header.childCount];

                    for (var i = 0; i < variables.Length; i++)
                    {
                        variables[i] = header.GetChild(i).GetComponentInChildren<T>();
                    }

                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                {
                    header = header.GetChild(childrenIndexes[i]);
                }

                variables = new T[header.childCount];

                for (var i = 0; i < variables.Length; i++)
                {
                    variables[i] = header.GetChild(i).GetComponentInChildren<T>();
                }

                return true;
            }

            return false;
        }
    }
}