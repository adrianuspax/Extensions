using ASPax.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldExtensionsSample : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;
    [SerializeField] private Toggle toggle;

    private void Start()
    {
        button.interactable = false;
        inputField.FixBehaviour((status) => print(status));
        inputField.SetBehaviourByContent((hasContent) => button.interactable = hasContent);
        inputField.KeyboardBehaviour((isOpen) => toggle.isOn = isOpen);
    }
}
