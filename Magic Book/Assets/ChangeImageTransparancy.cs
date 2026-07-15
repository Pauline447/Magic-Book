using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageTransparancy : MonoBehaviour
{
    [SerializeField] float m_fadeDuration = 1f;
    private Coroutine m_fadeRoutine;
    public void ChangeImage(float endValue)
    {
        Image image = GetComponent<Image>();

        if (m_fadeRoutine != null)
        {
            StopCoroutine(m_fadeRoutine);
        }
        m_fadeRoutine = StartCoroutine(Fade(image, endValue, m_fadeDuration));
    }

    private IEnumerator Fade(Image image, float endAlpha, float duration)
    {
        Color color = image.color;

        float startValue = color.a;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startValue, endAlpha, elapsed / duration);
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
    }
}
