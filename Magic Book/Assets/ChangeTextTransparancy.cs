using System.Collections;
using TMPro;
using UnityEngine;

public class ChangeTextTransparancy : MonoBehaviour
{
    [SerializeField] float m_fadeDuration = 1f;
    private Coroutine m_fadeRoutine;
    public void ChangeText(float endValue)
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>(); 

        if(m_fadeRoutine != null)
        {
            StopCoroutine(m_fadeRoutine);
        }
        m_fadeRoutine = StartCoroutine(Fade(text, endValue, m_fadeDuration));
    }

    private IEnumerator Fade(TextMeshProUGUI text, float endAlpha, float duration)
    {
        float startValue = text.alpha;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            text.alpha = Mathf.Lerp(startValue, endAlpha, elapsed / duration);
            yield return null;
        }

        text.alpha = endAlpha;
    }
}
