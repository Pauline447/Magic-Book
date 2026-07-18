using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NoteTracker : MonoBehaviour
{
    [SerializeField] private UnityEvent m_afterNoteRevealedEvent;
    private int m_numberOfNotesRevealed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeNumberOfNotesRevealed(Button currentButton)
    {
        currentButton.enabled = false;
        m_numberOfNotesRevealed++;
        if(m_numberOfNotesRevealed==3)
        {
            m_afterNoteRevealedEvent.Invoke();
        }
    }
}
