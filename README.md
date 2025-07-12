# ASPax Extensions for Unity

Uma coleção abrangente de métodos de extensão C# para Unity, projetada para simplificar tarefas comuns, reduzir código repetitivo e melhorar a legibilidade e a manutenibilidade do seu projeto.

## Visão Geral

Esta biblioteca oferece uma variedade de métodos de extensão para muitas das classes mais comuns da Unity, como `Component`, `GameObject`, `Animator`, `CanvasGroup`, e tipos primitivos. O objetivo é fornecer atalhos úteis e funcionalidades adicionais que não estão presentes na API padrão da Unity, permitindo que você escreva um código mais limpo e eficiente.

## Principais Vantagens

*   **Código Conciso:** Reduza a verbosidade do seu código com métodos de atalho para operações comuns.
*   **Atribuição Inteligente de Componentes:** Atribua referências de componentes de forma segura e eficiente com a família de métodos `GetComponentIfNull`.
*   **Manipulação de UI Simplificada:** Controle `CanvasGroup`, `Image` e `TextMeshProUGUI` com facilidade, incluindo animações de fade e manipulação de cores.
*   **Segurança contra Nulos:** Métodos `IsNull` e `IsNullOrEmpty` para a maioria dos tipos da Unity, ajudando a evitar `NullReferenceException`.
*   **Performance:** Métodos como `ComparativeAssignment` ajudam a evitar atribuições desnecessárias, o que pode ser útil em loops de `Update`.

## Funcionalidades e Exemplos

Aqui está uma visão detalhada das funcionalidades oferecidas, com exemplos de como usá-las.

---

### ComponentExtensions

Esta é uma das classes mais poderosas da biblioteca, oferecendo métodos para buscar e atribuir componentes de forma inteligente.

#### `GetComponentIfNull<T>()`

Atribui um componente a uma variável somente se a variável for `null`. Isso é extremamente útil no `Awake` ou `Start` para garantir que as referências sejam configuradas.

```csharp
using ASPax.Extensions;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        // Em vez de:
        // if (rb == null)
        //  {
        //     rb = thanform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Rigidbody>();
        // }
        
        // Use:
        this.GetComponentIfNull(ref rb, 0, 1, 2);
    }
}
```

#### `GetComponentInChildrenIfNull<T>()` e `GetComponentsInAllChildrenIfNull<T>()`

Funciona de forma semelhante, mas busca por componentes nos filhos do objeto.

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Button[] allButtons;

    void Awake()
    {
        // Pega todos os componentes Button em todos os filhos e descendentes.
        this.GetComponentsInAllChildrenIfNull(ref allButtons);
    }
}
```

#### `GetComponentInParentIfNull<T>()`

Busca por um componente nos pais do objeto.

```csharp
using ASPax.Extensions;
using UnityEngine;

public class CharacterPart : MonoBehaviour
{
    private CharacterRoot characterRoot;

    void Start()
    {
        // Encontra o componente CharacterRoot no objeto pai ou em qualquer ancestral.
        this.GetComponentInParentIfNull(ref characterRoot);
    }
}
```

#### `FindAnyObjectByTypeIfNull<T>()` e `FindObjectsByTypeIfNull<T>()`

Encontra objetos na cena.

```csharp
using ASPax.Extensions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        // Encontra o primeiro AudioManager na cena.
        this.FindAnyObjectByTypeIfNull(ref audioManager);
    }
}
```

---

### CanvasGroupExtensions

Facilita o controle de `CanvasGroup`, especialmente para animações de UI.

#### `FadeIn()` e `FadeOut()`

Realiza animações de fade in e fade out de forma simples.

```csharp
using ASPax.Extensions;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup menuPanel;

    void Start()
    {
        // Esconde o painel instantaneamente
        menuPanel.alpha = 0;
    }

    public void ShowMenu()
    {
        // Anima o fade in do painel ao longo de 0.5 segundos.
        menuPanel.FadeIn(0.5f, this);
    }

    public void HideMenu()
    {
        // Anima o fade out do painel ao longo de 0.3 segundos.
        menuPanel.FadeOut(0.3f, this);
    }
}
```

---

### AnimatorExtensions

Métodos úteis para trabalhar com o componente `Animator`.

#### `GetClipLength()`

Obtém a duração de um clipe de animação pelo nome ou ID (hash).

```csharp
using ASPax.Extensions;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        float? attackDuration = animator.GetClipLength("Attack");
        if (attackDuration.HasValue)
        {
            Debug.Log($"A animação 'Attack' dura {attackDuration.Value} segundos.");
        }
    }
}
```

---

### ColorExtensions

Extensões para a struct `Color`.

#### `GetWithAlpha()`

Retorna uma nova cor com um valor de alfa modificado.

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class GhostEffect : MonoBehaviour
{
    public Image characterSprite;

    void SetTransparency(float alpha)
    {
        // Define a transparência da imagem sem alterar sua cor base.
        characterSprite.color = characterSprite.color.GetWithAlpha(alpha);
    }
}
```

---

### ImageExtensions

Métodos de extensão para o componente `Image` da UI.

#### `SetAlphaLerp()`

Anima o alfa de uma imagem ao longo do tempo.

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class FadingImage : MonoBehaviour
{
    public Image myImage;

    void Start()
    {
        // Anima o alfa da imagem para 0 (transparente) em 2 segundos.
        myImage.SetAlphaLerp(0f, 2f, this);
    }
}
```

#### `SetFillAmountLerp()`

Anima a propriedade `fillAmount` de uma imagem, útil para barras de progresso ou timers radiais.

```csharp
using ASPax.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthFillImage;

    public void AnimateDamage(float duration)
    {
        // Anima a barra de vida diminuindo.
        healthFillImage.SetFillAmountLerp(duration, isIncreasing: false, this);
    }
}
```

---

### PrimitivesExtensions

Extensões para tipos primitivos como `bool`, `int`, `float` e `string`.

#### `ToInt()` e `ToBool()`

Converte entre `bool` e `int`.

```csharp
bool isEnabled = true;
int intValue = isEnabled.ToInt(); // Retorna 1

int value = 0;
bool boolValue = value.ToBool(); // Retorna false
```

#### `Truncation()`

Trunca um `float` para um número específico de casas decimais, oferecendo diferentes métodos de arredondamento.

```csharp
float value = 3.14159f;
var truncated = value.Truncation(2);

Debug.Log(truncated.Round); // 3.14
Debug.Log(truncated.Floor); // 3.14
Debug.Log(truncated.Ceil);  // 3.15
```

#### `GetAnimatorHash()`

Converte uma string diretamente para um hash de animador, melhorando a legibilidade.

```csharp
// Em vez de:
// int hash = Animator.StringToHash("MyTrigger");

// Use:
int hash = "MyTrigger".GetAnimatorHash();
```

---

### ComparativeAssignment

Disponível para a maioria dos tipos, este método atribui um valor a uma variável apenas se os valores forem diferentes. Retorna `true` se a atribuição ocorreu. Isso é útil para evitar operações custosas no `Update` quando os dados não mudaram.

```csharp
using ASPax.Extensions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    public Transform model;

    void Update()
    {
        // O método só será chamado se a posição realmente mudar.
        if (transform.position.ComparativeAssignment(ref lastPosition))
        {
            UpdateVisuals();
        }
    }

    void UpdateVisuals()
    {
        // Lógica custosa de atualização visual
    }
}
```
