using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaskMaterial : MonoBehaviour
{
    [SerializeField] private Material m_material;
    [SerializeField] private Graphic[] m_graphics;

    public void ChangeMask(string maskName, Sprite mask, string maskStrengthName, float duration)
    {
        if (mask == null)
            return;

        m_material.SetTexture(maskName, mask.texture);

        StartCoroutine(Fade(1f, maskStrengthName));
    }

    private IEnumerator Fade(float duration, string maskStrengthName)
    {
        yield return new WaitForEndOfFrame();
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float value = Mathf.Lerp(0f, 1f, elapsed / duration);

            m_material.SetFloat(maskStrengthName, value);

            foreach (Graphic graphic in m_graphics)
            {
                graphic.canvasRenderer.SetMaterial(m_material, 0);
            }

            yield return null;
        }

        m_material.SetFloat(maskStrengthName, 1f);
    }

    private void OnDisable()
    {
        m_material.SetTexture("_Mask2", null);
        m_material.SetFloat("_MaskStrength2", 0f);
        m_material.SetTexture("_Mask", null);
        m_material.SetFloat("_MaskStrength1", 0f);
        m_material.SetTexture("_Mask3", null);
        m_material.SetFloat("_MaskStrength3", 0f); 
    }
}