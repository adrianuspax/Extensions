[Português](../README.md) | [English](README-en.md)

# ASPax.Extensions

## 개요

`ASPax.Extensions`는 `Component`, `GameObject`, `Animator`, `CanvasGroup` 등과 같은 일반적인 Unity Engine 클래스의 기능을 확장하는 Unity 스크립트 라이브러리입니다. 이 라이브러리는 또한 `int`, `float`, `bool`, `string`과 같은 C# 기본 형식에도 기능을 추가합니다.

## 목표

이 라이브러리의 주요 목표는 반복적이고 복잡한 로직을 간단하고 직관적인 메소드 호출로 캡슐화하는 확장 메소드를 제공하여 Unity에서 게임 및 애플리케이션 개발을 단순화하고 가속화하는 것입니다.

## 장점

- **더 깨끗하고 읽기 쉬운 코드:** 상용구 코드의 양을 줄입니다.
- **더 빠른 개발:** 일반적인 작업을 위한 바로 사용할 수 있는 메소드.
- **오류 발생 가능성 감소:** 캡슐화되고 테스트된 로직.
- **사용하기 쉬움:** 확장 메소드 구문을 사용하면 자연스럽고 유동적으로 사용할 수 있습니다.

## 기능

### AnimatorExtensions

`Animator` 클래스를 확장하여 `Animator` 또는 `Animator` 배열이 null인지 확인하고, 이름이나 ID로 애니메이션 클립의 길이를 가져오고, 여러 클립의 길이를 합산하는 메소드를 추가합니다.

**예제:**

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

`CanvasGroup` 클래스를 확장하여 `alpha`(투명도)를 제어하고, 페이드 인 및 페이드 아웃 애니메이션을 수행하고, `alpha`에 "핑퐁" 효과를 만드는 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class CanvasGroupExample : MonoBehaviour
{
    public CanvasGroup myCanvasGroup;

    void Start()
    {
        // 2초 동안 페이드 인
        myCanvasGroup.FadeIn(2f, this);

        // 1.5초 동안 페이드 아웃
        myCanvasGroup.FadeOut(1.5f, this);

        // 알파에 핑퐁 효과
        myCanvasGroup.AlphaPingPong(1f, true, this);
    }
}
```

### ColorExtensions

`Color` 클래스를 확장하여 새로운 `alpha` 값으로 색상을 가져오고 비교 할당을 수행하는 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ColorExample : MonoBehaviour
{
    public Color myColor = Color.red;

    void Start()
    {
        // 50% 투명도의 색상을 가져옵니다
        Color transparentColor = myColor.GetWithAlpha(0.5f);
        Debug.Log($"New color: {transparentColor}");
    }
}
```

### ComponentExtensions

`Component` 클래스를 확장하여 자식 또는 부모에서 구성 요소를 찾고, 구성 요소가 null인지 확인하고, 비교 할당을 수행하는 다양한 유용한 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ComponentExample : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // rb 변수가 null인 경우 Rigidbody 구성 요소를 가져옵니다
        this.GetComponentIfNull(ref rb);

        if (!rb.IsNull())
        {
            Debug.Log("Rigidbody found!");
        }
    }
}
```

### GameObjectExtensions

`GameObject` 클래스를 확장하여 자식을 찾고, `GameObject`가 null인지 확인하고, 비교 할당을 수행하는 메소드를 추가합니다.

**예제:**

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

`Image` (UI) 클래스를 확장하여 `alpha`를 설정하고, 보간(lerp)으로 색상 및 `fillAmount`를 애니메이션하고, 그라디언트에서 색상을 설정하는 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ImageExample : MonoBehaviour
{
    public Image myImage;

    void Start()
    {
        // 1초 동안 이미지 알파를 0.5로 애니메이션합니다
        myImage.SetAlphaLerp(0.5f, 1f, this);

        // 2초 동안 이미지 채우기 양을 0에서 1로 애니메이션합니다
        myImage.SetFillAmountLerp(2f, true, this);
    }
}
```

### LineRendererExtensions

`LineRenderer` 클래스를 확장하여 텍스처, 텍스처 `offset`을 설정하고 텍스처 `offset`을 애니메이션하는 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public Texture2D myTexture;

    void Start()
    {
        // LineRenderer의 텍스처를 설정합니다
        myLineRenderer.SetTexture(myTexture);

        // 텍스처 오프셋을 애니메이션합니다
        myLineRenderer.StartDynamicOffset(new Vector2(0.5f, 0), this);
    }
}
```

### PrimitivesExtensions

`bool`, `int`, `float`, `string`과 같은 C# 기본 형식을 변환 및 확인 메소드로 확장합니다.

**예제:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class PrimitivesExample : MonoBehaviour
{
    void Start()
    {
        bool myBool = true;
        int myInt = myBool.ToInt(); // myInt는 1이 됩니다
        Debug.Log($"Integer value: {myInt}");

        string myString = "Hello";
        int hash = myString.GetAnimatorHash();
        Debug.Log($"Animator hash: {hash}");
    }
}
```

### StructExtensions

제네릭 `struct`를 확장하여 `struct` 배열이 null이거나 비어 있는지 확인하고 비교 할당을 수행하는 메소드를 추가합니다.

### TextMeshProUGUIExtensions

`TextMeshProUGUI` 클래스를 확장하여 그라디언트에서 `alpha` 및 색상을 설정하는 메소드를 추가합니다.

**예제:**

```csharp
using ASPax.Extensions;
using TMPro;
using UnityEngine;

public class TextMeshProExample : MonoBehaviour
{
    public TextMeshProUGUI myText;

    void Start()
    {
        // 텍스트 알파를 0.5로 설정합니다
        myText.SetAlpha(0.5f);
    }
}
```

### UnityObjectExtensions

`UnityEngine.Object` 클래스를 확장하여 객체가 null인지 확인하고 비교 할당을 수행하는 제네릭 메소드를 추가합니다.

### VectorExtensions

`Vector2` 및 `Vector3` 클래스를 확장하여 벡터가 null, `NaN`(숫자가 아님) 또는 `default`인지 확인하고 비교 할당을 수행하는 메소드를 추가합니다.

## 종속성

- **Unity Engine:** 이 프로젝트는 Unity Engine용 라이브러리이며 사용하려면 Unity 프로젝트가 필요합니다.
- **TextMeshPro:** `TextMeshProUGUIExtensions` 스크립트를 사용하려면 Unity 프로젝트에 TextMeshPro 패키지가 설치되어 있어야 합니다 (대부분의 최신 Unity 버전에서는 표준임).
