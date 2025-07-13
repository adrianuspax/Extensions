using System.Linq;
using UnityEngine;

namespace ASPax.Extensions
{
    /// <summary>
    /// Component Extensions
    /// </summary>
    public static class ComponentExtensions
    {
        private static bool _isAssigmentsForced = false;
        /// <summary>
        /// Retrieves a child <see cref="Transform"/> from the hierarchy of the specified <see cref="Component"/> based on the provided sequence of child indices.
        /// </summary>
        /// <param name="component">The <see cref="Component"/> whose child hierarchy is traversed.</param>
        /// <param name="children">An array of indices representing the path to the desired child. Each index corresponds to the position of a child in the hierarchy at the current level.<br/>
        /// If the array is empty, the method returns the <see cref="Transform"/> of the specified <paramref name="component"/>.</param>
        /// <returns>The <see cref="Transform"/> of the child located at the specified path of indices.<br/>
        /// If <paramref name="children"/> is empty, the <see cref="Transform"/> of the <paramref name="component"/> is returned.</returns>
        public static Transform GetChildFromChildren(this Component component, params uint[] children)
        {
            var transform = component.transform;
            if (children.IsNullOrEmpty()) return transform;
            for (var i = 0; i < children.Length; i++) transform = transform.GetChild((int)children[i]);
            return transform;
        }
        /// <summary>
        /// Retrieves the ancestor transform at the specified parent index relative to the current component's transform.
        /// </summary>
        /// <param name="component">The component whose transform hierarchy is traversed.</param>
        /// <param name="parentIndex">The number of levels to traverse up the transform hierarchy. Must be a non-negative value.</param>
        /// <returns>The <see cref="Transform"/> at the specified parent index.<br/>
        /// Returns <see langword="null"/> if the hierarchy does not contain enough parent levels to satisfy the specified <paramref name="parentIndex"/>.</returns>
        public static Transform GetChildFromParent(this Component component, uint parentIndex)
        {
            var transform = component.transform;
            for (var i = 0; i <= parentIndex; i++) transform = transform.parent;
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
            if (components == null || components.Length == 0) return true;
            else return components.All(obj => obj == null);
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
        public static bool GetComponentIfNull<T>(this Component component, ref T variable, params uint[] childrenIndexes) where T : Component
        {
            if (variable.IsNull() || _isAssigmentsForced)
            {
                var transform = component.transform;

                if (childrenIndexes.IsNullOrEmpty())
                {
                    variable = transform.GetComponent<T>();
                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                    transform = transform.GetChild((int)childrenIndexes[i]);

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
        public static bool GetComponentInChildrenIfNull<T>(this Component component, ref T variable, params uint[] childrenIndexes) where T : Component
        {
            if (variable.IsNull() || _isAssigmentsForced)
            {
                var transform = component.transform;

                if (childrenIndexes.IsNullOrEmpty())
                {
                    variable = transform.GetComponentInChildren<T>(true);
                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                    transform = transform.GetChild((int)childrenIndexes[i]);

                variable = transform.GetComponentInChildren<T>(true);
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
        public static bool GetComponentsInAllChildrenIfNull<T>(this Component component, ref T[] variables, params uint[] childrenIndexes) where T : Component
        {
            if (variables.IsNullOrEmpty() || _isAssigmentsForced)
            {
                var transform = component.transform;

                if (childrenIndexes.IsNullOrEmpty())
                {
                    variables = transform.GetComponentsInChildren<T>(true);
                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                    transform = transform.GetChild((int)childrenIndexes[i]);

                variables = transform.GetComponentsInChildren<T>(true);
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
        public static bool GetComponentsInChildrenHeadersIfNull<T>(this Component component, ref T[] variables, params uint[] childrenIndexes) where T : Component
        {
            if (variables.IsNullOrEmpty() || _isAssigmentsForced)
            {
                var header = component.transform;

                if (childrenIndexes.IsNullOrEmpty())
                {
                    variables = new T[header.childCount];

                    for (var i = 0; i < variables.Length; i++)
                        variables[i] = header.GetChild(i).GetComponentInChildren<T>(true);

                    return true;
                }

                for (var i = 0; i < childrenIndexes.Length; i++)
                    header = header.GetChild((int)childrenIndexes[i]);

                variables = new T[header.childCount];

                for (var i = 0; i < variables.Length; i++)
                    variables[i] = header.GetChild(i).GetComponentInChildren<T>(true);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Attempts to assign a component of type <typeparamref name="T"/> to the specified variable if the variable is null.<br/>
        /// Optionally searches for the component in a specific parent level.
        /// </summary>
        /// <remarks>This method searches for a component of type <typeparamref name="T"/> starting from the specified <paramref name="component"/>  and traversing up the hierarchy.<br/>
        /// If <paramref name="parentIndex"/> is specified, the search is limited to the specified number  of parent levels.<br/>
        /// If <paramref name="variable"/> is already assigned, no search is performed.</remarks>
        /// <typeparam name="T">The type of the component to search for.</typeparam>
        /// <param name="component">The starting component from which the search begins.</param>
        /// <param name="variable">The variable to assign the found component to.<br/>
        /// If the variable is not null, no assignment is performed.</param>
        /// <param name="parentIndex">The number of parent levels to traverse when searching for the component.<br/>
        /// If <see langword="null"/>, searches all parent levels.</param>
        /// <returns><see langword="true"/> if a component of type <typeparamref name="T"/> was assigned to <paramref name="variable"/>;  otherwise, <see langword="false"/>.</returns>
        public static bool GetComponentInParentIfNull<T>(this Component component, ref T variable, uint? parentIndex = null) where T : Component
        {
            if (variable.IsNull() || _isAssigmentsForced)
            {
                var transform = component.transform;

                if (parentIndex == null)
                {
                    variable = transform.GetComponentInParent<T>(true);
                    return true;
                }

                for (var i = 0; i < parentIndex; i++)
                    transform = transform.parent;

                variable = transform.GetComponent<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assigns a reference to the first object of type <typeparamref name="T"/> found in the scene  to the specified variable if the variable is null or assignments are forced.
        /// </summary>
        /// <remarks>This method uses <see cref="Object.FindAnyObjectByType{T}(FindObjectsInactive)"/> to locate objects in the scene, including inactive objects.</remarks>
        /// <typeparam name="T">The type of object to search for. Must derive from <see cref="Object"/>.</typeparam>
        /// <param name="monoBehaviour">The <see cref="MonoBehaviour"/> instance invoking this method.<br/>
        /// This parameter is not used but is required for extension method syntax.</param>
        /// <param name="variable">A reference to the variable to assign.<br/>
        /// If the variable is null or assignments are forced, it will be updated with the first object of type <typeparamref name="T"/> found in the scene.</param>
        /// <returns><see langword="true"/> if the variable was assigned a new value; otherwise, <see langword="false"/>.</returns>
        public static bool FindAnyObjectByTypeIfNull<T>(this MonoBehaviour monoBehaviour, ref T variable) where T : Object
        {
            if (variable.IsNull() || _isAssigmentsForced)
            {
                variable = Object.FindAnyObjectByType<T>(FindObjectsInactive.Include);
                return true;
            }

            _ = monoBehaviour;
            return false;
        }
        /// <summary>
        /// Attempts to find and assign objects of the specified type to the provided array if the array is null or empty.
        /// </summary>
        /// <remarks>This method uses <see cref="Object.FindObjectsByType{T}(FindObjectsInactive, FindObjectsSortMode)"/> to locate objects of the specified type.<br/>
        /// If the array is already populated and assignments are not forced, no changes are made.</remarks>
        /// <typeparam name="T">The type of objects to find.<br/>Must derive from <see cref="Object"/>.</typeparam>
        /// <param name="monoBehaviour">The <see cref="MonoBehaviour"/> instance used for context. This parameter is not utilized in the method logic.</param>
        /// <param name="variables">A reference to the array that will be populated with objects of type <typeparamref name="T"/> if it is null or empty.</param>
        /// <returns><see langword="true"/> if the array was null or empty and objects were successfully assigned; otherwise, <see langword="false"/>.</returns>
        public static bool FindObjectsByTypeIfNull<T>(this MonoBehaviour monoBehaviour, ref T[] variables) where T : Object
        {
            if (variables.IsNullOrEmpty() || _isAssigmentsForced)
            {
                variables = Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                return true;
            }
            _ = monoBehaviour;
            return false;
        }
        /// <summary>
        /// If true, the assigments will be forced
        /// </summary>
        public static bool IsAssigmentsForced
        {
            get => _isAssigmentsForced;
            set => _isAssigmentsForced = value;
        }
    }
}