[Português](../README.md) | [한국어](README-ko.md)

# ASPax.Extensions

## Overview

`ASPax.Extensions` is a Unity script library that extends the functionality of common Unity Engine classes such as `Component`, `GameObject`, `Animator`, `CanvasGroup`, and others. The library also adds functionality to C# primitive types like `int`, `float`, `bool`, and `string`.

## Objective

The main objective of this library is to simplify and speed up the development of games and applications in Unity by providing extension methods that encapsulate repetitive and complex logic into simple and intuitive method calls.

## Advantages

- **Cleaner and more readable code:** Reduces the amount of boilerplate code.
- **Faster development:** Ready-to-use methods for common tasks.
- **Less prone to errors:** Encapsulated and tested logic.
- **Easy to use:** The extension method syntax makes usage natural and fluid.

## Functionalities

### AnimatorExtensions

Extends the `Animator` class with methods to check if an `Animator` or an array of `Animator` is null, get the duration of an animation clip by name or ID, and sum the duration of multiple clips.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class AnimatorExample : MonoBehaviour
{
    public Animator myAnimator;

    void Start()
    {
        if (myAnimator.IsNull())
        {
            Debug.Log("Animator is null!");
            return;
        }

        float? clipLength = myAnimator.GetClipLength("MyAnimationClip");
        if (clipLength.HasValue)
        {
            Debug.Log($"The clip duration is: {clipLength.Value}");
        }

        float? totalLength = myAnimator.GetSumClipsLength("Clip1", "Clip2");
        if (totalLength.HasValue)
        {
            Debug.Log($"The total duration of the clips is: {totalLength.Value}");
        }
    }
}
```

### CanvasGroupExtensions

Extends the `CanvasGroup` class with methods to control the `alpha` (transparency), perform fade-in and fade-out animations, and create a "ping-pong" effect on the `alpha`.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class CanvasGroupExample : MonoBehaviour
{
    public CanvasGroup myCanvasGroup;

    void Start()
    {
        // Fade-in over 2 seconds
        myCanvasGroup.FadeIn(2f, this);

        // Fade-out over 1.5 seconds
        myCanvasGroup.FadeOut(1.5f, this);

        // Ping-pong effect on alpha
        myCanvasGroup.AlphaPingPong(1f, true, this);
    }
}
```

### ColorExtensions

Extends the `Color` class with methods to get a color with a new `alpha` value and to perform comparative assignments.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ColorExample : MonoBehaviour
{
    public Color myColor = Color.red;

    void Start()
    {
        // Gets the color with 50% transparency
        Color transparentColor = myColor.GetWithAlpha(0.5f);
        Debug.Log($"New color: {transparentColor}");
    }
}
```

### ComponentExtensions

Extends the `Component` class with a variety of useful methods for finding components in children or parents, checking if a component is null, and performing comparative assignments.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ComponentExample : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Gets the Rigidbody component if the rb variable is null
        this.GetComponentIfNull(ref rb);

        if (!rb.IsNull())
        {
            Debug.Log("Rigidbody found!");
        }
    }
}
```

### GameObjectExtensions

Extends the `GameObject` class with methods to find children, check if a `GameObject` is null, and perform comparative assignments.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class GameObjectExample : MonoBehaviour
{
    public GameObject myObject;

    void Start()
    {
        if (myObject.IsNull())
        {
            Debug.Log("GameObject is null!");
        }
    }
}
```

### ImageExtensions

Extends the `Image` (UI) class with methods to set the `alpha`, animate the color and `fillAmount` with interpolation (lerp), and set the color from a gradient.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ImageExample : MonoBehaviour
{
    public Image myImage;

    void Start()
    {
        // Animates the image alpha to 0.5 in 1 second
        myImage.SetAlphaLerp(0.5f, 1f, this);

        // Animates the image fill amount from 0 to 1 in 2 seconds
        myImage.SetFillAmountLerp(2f, true, this);
    }
}
```

### LineRendererExtensions

Extends the `LineRenderer` class with methods to set the texture, the texture `offset`, and animate the texture `offset`.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public Texture2D myTexture;

    void Start()
    {
        // Sets the LineRenderer's texture
        myLineRenderer.SetTexture(myTexture);

        // Animates the texture offset
        myLineRenderer.StartDynamicOffset(new Vector2(0.5f, 0), this);
    }
}
```

### PrimitivesExtensions

Extends C# primitive types like `bool`, `int`, `float`, and `string` with conversion and verification methods.

**Examples:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class PrimitivesExample : MonoBehaviour
{
    void Start()
    {
        bool myBool = true;
        int myInt = myBool.ToInt(); // myInt will be 1
        Debug.Log($"Integer value: {myInt}");

        string myString = "Hello";
        int hash = myString.GetAnimatorHash();
        Debug.Log($"Animator hash: {hash}");
    }
}
```

### StructExtensions

Extends generic `structs` with methods to check if an array of `structs` is null or empty and to perform comparative assignments.

### TextMeshProUGUIExtensions

Extends the `TextMeshProUGUI` class with methods to set the `alpha` and the color from a gradient.

**Examples:**

```csharp
using ASPax.Extensions;
using TMPro;
using UnityEngine;

public class TextMeshProExample : MonoBehaviour
{
    public TextMeshProUGUI myText;

    void Start()
    {
        // Sets the text alpha to 0.5
        myText.SetAlpha(0.5f);
    }
}
```

### UnityObjectExtensions

Extends the `UnityEngine.Object` class with generic methods to check if an object is null and to perform comparative assignments.

### VectorExtensions

Extends the `Vector2` and `Vector3` classes with methods to check if a vector is null, `NaN` (Not a Number), or `default`, and to perform comparative assignments.

## Dependencies

- **Unity Engine:** This project is a library for the Unity Engine and requires a Unity project to be used.
- **TextMeshPro:** The `TextMeshProUGUIExtensions` script requires the TextMeshPro package to be installed in the Unity project (which is standard in most recent versions of Unity).
