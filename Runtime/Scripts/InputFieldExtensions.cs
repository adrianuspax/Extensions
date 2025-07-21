using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ASPax.Extensions
{
    /// <summary>
    /// Represents the various states or events associated with an input field.
    /// </summary>
    /// <remarks>This enumeration is typically used to identify specific input field events, such as when the field is
    /// selected, its value changes, or text selection occurs.<br/>
    /// It can be used in event handling logic to determine the current  state or action related to the input field.</remarks>
    public enum InputFieldStatus
    {
        NONE = 0,
        onSelect = 1,
        onValueChanged = 2,
        onDeselect = 3,
        onTextSelection = 4,
        onEndTextSelection = 5,
        onSubmit = 6,
        onEndEdit = 7
    }
    /// <summary>
    /// Provides extension methods for configuring and enhancing the behavior of <see cref="TMP_InputField"/> instances.
    /// </summary>
    /// <remarks>These methods allow developers to modify the behavior of <see cref="TMP_InputField"/> components,
    /// such as handling placeholder visibility, managing input events, and invoking custom callbacks for specific input
    /// field states.</remarks>
    public static class InputFieldExtensions
    {
        /// <summary>
        /// Adjusts the behavior of the specified <see cref="TMP_InputField"/> to ensure proper functionality.
        /// </summary>
        /// <param name="inputField">The <see cref="TMP_InputField"/> instance to modify. Cannot be <see langword="null"/>.</param>
        public static void FixBehaviour(this TMP_InputField inputField)
        {
            FixBehaviour(inputField, null);
        }
        /// <summary>
        /// Configures keyboard behavior for a <see cref="TMP_InputField"/> by invoking a callback when the input field is selected or editing ends.
        /// </summary>
        /// <remarks>This method adds listeners to the <see cref="TMP_InputField.onSelect"/> and <see cref="TMP_InputField.onEndEdit"/> events.<br/>
        /// Ensure that the provided callback handles both states appropriately.</remarks>
        /// <param name="inputField">The <see cref="TMP_InputField"/> to which the keyboard behavior is applied. Cannot be null.</param>
        /// <param name="call">A callback that is invoked with a <see langword="true"/> value when the input field is selected, and with a <see langword="false"/> value when editing ends.<br/>
        /// Can be <see langword="null"/> if no action is required.</param>
        public static void KeyboardBehaviour(this TMP_InputField inputField, UnityAction<bool> call)
        {
            inputField.onSelect.AddListener(_ => call?.Invoke(true));
            inputField.onDeselect.AddListener(_ => call?.Invoke(false));
            inputField.onEndEdit.AddListener(_ => call?.Invoke(false));
        }
        /// <summary>
        /// Attaches event listeners to a <see cref="TMP_InputField"/> to handle various input field events and invokes a
        /// callback with the corresponding <see cref="InputFieldStatus"/>.
        /// </summary>
        /// <remarks>This method manages placeholder visibility and restores the input field's state if the input
        /// is canceled. It listens to the following events: <list type="bullet"> <item><description><see
        /// cref="TMP_InputField.onSelect"/></description></item> <item><description><see
        /// cref="TMP_InputField.onValueChanged"/></description></item> <item><description><see
        /// cref="TMP_InputField.onDeselect"/></description></item> <item><description><see
        /// cref="TMP_InputField.onTextSelection"/></description></item> <item><description><see
        /// cref="TMP_InputField.onEndTextSelection"/></description></item> <item><description><see
        /// cref="TMP_InputField.onSubmit"/></description></item> <item><description><see
        /// cref="TMP_InputField.onEndEdit"/></description></item> </list> The placeholder's alpha value is adjusted based
        /// on the input field's content and state.</remarks>
        /// <param name="inputField">The <see cref="TMP_InputField"/> to which the event listeners will be attached.</param>
        /// <param name="call">A callback of type <see cref="UnityAction{InputFieldStatus}"/> that is invoked with the appropriate <see
        /// cref="InputFieldStatus"/> when an input field event occurs.</param>
        public static void FixBehaviour(this TMP_InputField inputField, UnityAction<InputFieldStatus> call)
        {
            TextMeshProUGUI placeholderTMP = null; // Placeholder for the TMP component of the input field's placeholder.
            var storedContent = string.Empty; // Variable to store the content of the input field for restoration.
            var storedAlpha = 0.5019608f; // Default alpha value for the placeholder text, used to restore its visibility.

            inputField.onSelect.AddListener(_select);
            inputField.onValueChanged.AddListener(_valueChanged);
            inputField.onDeselect.AddListener(_deselect);
            inputField.onTextSelection.AddListener(_textSelection);
            inputField.onEndTextSelection.AddListener(_endTextSelection);
            inputField.onSubmit.AddListener(_submit);
            inputField.onEndEdit.AddListener(_editEnd);

            if (inputField.placeholder.TryGetComponent(out placeholderTMP)) storedAlpha = placeholderTMP.alpha;
            // Handles the select in the input field.
            void _select(string content)
            {
                _setStoredContent(content);
                _placeholder(content, false);
                call?.Invoke(InputFieldStatus.onSelect);
            }
            // Handles the change of value in the input field.
            void _valueChanged(string content)
            {
                _setStoredContent(content);
                call?.Invoke(InputFieldStatus.onValueChanged);
            }
            // Handles the deselection of the input field.
            void _deselect(string content)
            {
                _setStoredContent(content);
                call?.Invoke(InputFieldStatus.onDeselect);
            }
            // Handles the submission of the input field.
            void _submit(string content)
            {
                _setStoredContent(content);
                call?.Invoke(InputFieldStatus.onSubmit);
            }
            // Handles the end of editing in the input field.
            void _editEnd(string content)
            {
                _setStoredContent(content);
                if (inputField.wasCanceled) inputField.text = storedContent;
                EventSystem.current.SetSelectedGameObject(null);
                _placeholder(content, true);
                call?.Invoke(InputFieldStatus.onEndEdit);
            }
            // Handles the text selection in the input field.
            void _textSelection(string content, int value1, int value2)
            {
                _setStoredContent(content);
                call?.Invoke(InputFieldStatus.onTextSelection);
            }
            // Handles the end of text selection in the input field.
            void _endTextSelection(string content, int value1, int value2)
            {
                _setStoredContent(content);
                call?.Invoke(InputFieldStatus.onEndTextSelection);
            }
            // Placeholder Text beahviour fix
            void _placeholder(string content, bool isEnabled)
            {
                if (placeholderTMP != null && string.IsNullOrEmpty(content))
                    placeholderTMP.alpha = isEnabled ? storedAlpha : 0f;
            }
            // Stores the content of the input field to restore it later if needed.
            void _setStoredContent(string content)
            {
                if (!string.IsNullOrEmpty(content)) storedContent = content;
            }
        }
        /// <summary>
        /// Configures the behavior of the input field based on whether its content is empty or not.
        /// </summary>
        /// <remarks>This method adds a listener to the <see cref="TMP_InputField.onValueChanged"/> event, which triggers the provided callback whenever the content of the input field changes.</remarks>
        /// <param name="inputField">The <see cref="TMP_InputField"/> to which the behavior will be applied.</param>
        /// <param name="call">A callback that is invoked with <see langword="true"/> if the input field contains content; otherwise, <see langword="false"/>.</param>
        public static void SetBehaviourByContent(this TMP_InputField inputField, UnityAction<bool> call)
        {
            inputField.onValueChanged.AddListener((content) => call?.Invoke(!string.IsNullOrEmpty(content)));
        }
    }
}

