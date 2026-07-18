using BookCurlPro;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private bool m_startIntro = false;
    [SerializeField] private CameraMovement m_cameraMovement;
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] private GameObject m_buttonLeft;
    [SerializeField] private GameObject m_buttonRight;
    [SerializeField] private AutoFlip m_autoFlip;

    #region Singelton
    private static BookManager instance;
    public static BookManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Player is null");
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one BookManager in the scnene!");
        }

        instance = this;
    }
    #endregion
    private void Start()
    {
        if(m_startIntro)
        {
            m_autoFlip.AutoStartFlip = true;
            m_cameraMovement.enabled = false;
            m_playerMovement.enabled = false;
            m_buttonLeft.SetActive(false);
            m_buttonRight.SetActive(false);
        }
    }

    public void ActivateBookAgain()
    {
        m_cameraMovement.enabled = true;
        m_playerMovement.enabled = true;
        m_buttonLeft.SetActive(true);
        m_buttonRight.SetActive(true);
    }
}
