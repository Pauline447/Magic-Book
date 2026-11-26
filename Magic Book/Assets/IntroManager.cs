using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private string[] m_intoText;
    [SerializeField] private TextMeshProUGUI m_intoTextfield;
    [SerializeField] private GameObject m_openBookButton;
    [SerializeField] private GameObject m_skipButton;
    [SerializeField] private GameObject m_hint;

    [SerializeField] private float m_textSpeed = 10f;


    private PlayerController m_player;
    private int m_textInt = 0;
    private bool m_isTyping;
    private Coroutine m_typeDialogueRoutine;

    private const float MAX_TYPE_TIME = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player = PlayerController.Instance;
        m_player.OnInteract += NextText;

        if (!m_isTyping)
            m_typeDialogueRoutine = StartCoroutine(TypeDialogueText(m_intoText[0]));
    }

    private void NextText()
    {
        if(m_intoText.Length>m_textInt+1)
        {
            if (!m_isTyping)
            {
                if (m_hint.activeSelf)
                {
                    m_hint.SetActive(false);
                }
                m_textInt++;
                m_typeDialogueRoutine = StartCoroutine(TypeDialogueText(m_intoText[m_textInt]));
            }
        }
        else
        {
            OpenBookOption();
            m_player.OnInteract -= NextText;
        }
    }

    public void OpenBookOption()
    {
        m_intoTextfield.gameObject.SetActive(false);
        m_openBookButton.SetActive(true);
        m_skipButton.SetActive(false);
    }

    private IEnumerator TypeDialogueText(string text)
    {

        m_intoTextfield.maxVisibleCharacters = 0;

        m_isTyping = true;

        
        m_intoTextfield.text = text;
        m_intoTextfield.ForceMeshUpdate();
        m_intoTextfield.maxVisibleCharacters = 0;
        

        int totalVisibleCharacters = m_intoTextfield.textInfo.characterCount;

        for (int i = 0; i < totalVisibleCharacters; i++)
        {

            
            m_intoTextfield.maxVisibleCharacters = i + 1;

            yield return new WaitForSeconds(MAX_TYPE_TIME / m_textSpeed);
        }

        if(m_textInt == 0)
        {
            m_hint.SetActive(true);
        }

        m_isTyping = false;
    }
   
    public void OpenBook(int index)
    {
        SceneManager.LoadScene(index);
    }

}
