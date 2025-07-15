[English](Documentation~/README-en.md) | [한국어](Documentation~/README-ko.md)

# ASPax.Extensions

## Visão Geral

`ASPax.Extensions` é uma biblioteca de scripts para Unity que estende as funcionalidades de classes comuns do Unity Engine, como `Component`, `GameObject`, `Animator`, `CanvasGroup`, e outras. A biblioteca também adiciona funcionalidades a tipos primitivos do C# como `int`, `float`, `bool` e `string`.

## Objetivo

O objetivo principal desta biblioteca é simplificar e agilizar o desenvolvimento de jogos e aplicações em Unity, fornecendo métodos de extensão que encapsulam lógicas repetitivas e complexas em chamadas de método simples e intuitivas.

## Vantagens

- **Código mais limpo e legível:** Reduz a quantidade de código boilerplate.
- **Desenvolvimento mais rápido:** Métodos prontos para tarefas comuns.
- **Menos propenso a erros:** Lógica encapsulada e testada.
- **Fácil de usar:** A sintaxe de métodos de extensão torna a utilização natural e fluida.

## Funcionalidades

### AnimatorExtensions

Estende a classe `Animator` com métodos para verificar se um `Animator` ou um array de `Animator` é nulo, obter a duração de um clipe de animação pelo nome ou ID, e somar a duração de múltiplos clipes.

**Exemplos:**

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
            Debug.Log("Animator é nulo!");
            return;
        }

        float? clipLength = myAnimator.GetClipLength("MyAnimationClip");
        if (clipLength.HasValue)
        {
            Debug.Log($"A duração do clipe é: {clipLength.Value}");
        }

        float? totalLength = myAnimator.GetSumClipsLength("Clip1", "Clip2");
        if (totalLength.HasValue)
        {
            Debug.Log($"A duração total dos clipes é: {totalLength.Value}");
        }
    }
}
```

### CanvasGroupExtensions

Estende a classe `CanvasGroup` com métodos para controlar o `alpha` (transparência), realizar animações de fade-in e fade-out, e criar um efeito de "ping-pong" no `alpha`.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class CanvasGroupExample : MonoBehaviour
{
    public CanvasGroup myCanvasGroup;

    void Start()
    {
        // Fade-in em 2 segundos
        myCanvasGroup.FadeIn(2f, this);

        // Fade-out em 1.5 segundos
        myCanvasGroup.FadeOut(1.5f, this);

        // Efeito de ping-pong no alpha
        myCanvasGroup.AlphaPingPong(1f, true, this);
    }
}
```

### ColorExtensions

Estende a classe `Color` com métodos para obter uma cor com um novo valor de `alpha` e para realizar atribuições comparativas.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ColorExample : MonoBehaviour
{
    public Color myColor = Color.red;

    void Start()
    {
        // Obtém a cor com 50% de transparência
        Color transparentColor = myColor.GetWithAlpha(0.5f);
        Debug.Log($"Nova cor: {transparentColor}");
    }
}
```

### ComponentExtensions

Estende a classe `Component` com uma variedade de métodos úteis para buscar componentes em filhos ou pais, verificar se um componente é nulo, e realizar atribuições comparativas.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class ComponentExample : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Obtém o componente Rigidbody se a variável rb for nula
        this.GetComponentIfNull(ref rb);

        if (!rb.IsNull())
        {
            Debug.Log("Rigidbody encontrado!");
        }
    }
}
```

### GameObjectExtensions

Estende a classe `GameObject` com métodos para buscar filhos, verificar se um `GameObject` é nulo, e realizar atribuições comparativas.

**Exemplos:**

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
            Debug.Log("GameObject é nulo!");
        }
    }
}
```

### ImageExtensions

Estende a classe `Image` (UI) com métodos para definir o `alpha`, animar a cor e o `fillAmount` com interpolação (lerp), e definir a cor a partir de um gradiente.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ImageExample : MonoBehaviour
{
    public Image myImage;

    void Start()
    {
        // Anima o alpha da imagem para 0.5 em 1 segundo
        myImage.SetAlphaLerp(0.5f, 1f, this);

        // Anima o preenchimento da imagem de 0 a 1 em 2 segundos
        myImage.SetFillAmountLerp(2f, true, this);
    }
}
```

### LineRendererExtensions

Estende a classe `LineRenderer` com métodos para definir a textura, o `offset` da textura, e animar o `offset` da textura.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public Texture2D myTexture;

    void Start()
    {
        // Define a textura do LineRenderer
        myLineRenderer.SetTexture(myTexture);

        // Anima o offset da textura
        myLineRenderer.StartDynamicOffset(new Vector2(0.5f, 0), this);
    }
}
```

### PrimitivesExtensions

Estende tipos primitivos do C# como `bool`, `int`, `float`, e `string` com métodos de conversão e verificação.

**Exemplos:**

```csharp
using ASPax.Extensions;
using UnityEngine;

public class PrimitivesExample : MonoBehaviour
{
    void Start()
    {
        bool myBool = true;
        int myInt = myBool.ToInt(); // myInt será 1
        Debug.Log($"Valor inteiro: {myInt}");

        string myString = "Hello";
        int hash = myString.GetAnimatorHash();
        Debug.Log($"Hash do Animator: {hash}");
    }
}
```

### StructExtensions

Estende `structs` genéricos com métodos para verificar se um array de `structs` é nulo ou vazio e para realizar atribuições comparativas.

### TextMeshProUGUIExtensions

Estende a classe `TextMeshProUGUI` com métodos para definir o `alpha` e a cor a partir de um gradiente.

**Exemplos:**

```csharp
using ASPax.Extensions;
using TMPro;
using UnityEngine;

public class TextMeshProExample : MonoBehaviour
{
    public TextMeshProUGUI myText;

    void Start()
    {
        // Define o alpha do texto para 0.5
        myText.SetAlpha(0.5f);
    }
}
```

### UnityObjectExtensions

Estende a classe `UnityEngine.Object` com métodos genéricos para verificar se um objeto é nulo e para realizar atribuições comparativas.

### VectorExtensions

Estende as classes `Vector2` e `Vector3` com métodos para verificar se um vetor é nulo, `NaN` (Not a Number), ou `default`, e para realizar atribuições comparativas.

## Dependências

- **Unity Engine:** Este projeto é uma biblioteca para o Unity Engine e requer um projeto Unity para ser utilizado.
- **TextMeshPro:** O script `TextMeshProUGUIExtensions` requer que o pacote TextMeshPro esteja instalado no projeto Unity (o que é padrão na maioria das versões recentes do Unity).