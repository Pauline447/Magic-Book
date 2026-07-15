using UnityEngine;

public class TriggerMaskChange : MonoBehaviour
{
    [SerializeField] private ChangeMaskMaterial m_changeMaskMaterial;
    [SerializeField] private float m_duration = 1f;
    [SerializeField] private Sprite m_newMask;
    [SerializeField] private string m_maskName = "_Mask2";
    [SerializeField] private string m_maskStrengthName = "_MaskStrength2";

    public void TriggeringChangeMask()
    {
        m_changeMaskMaterial.ChangeMask(m_maskName,m_newMask,m_maskStrengthName, m_duration);
    }

}
