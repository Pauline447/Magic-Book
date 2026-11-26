using BookCurlPro;
using UnityEngine;

public class TrackPagesBook : MonoBehaviour
{
    [SerializeField] BookPro m_book;
    [SerializeField] TransitionPageManager[] m_transitionPageManagers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ChangeValuesWhenFlipped()
    {
        int currentTransitionManager = m_book.CurrentPaper - 1;
       
        if(currentTransitionManager == m_transitionPageManagers.Length-1)
            m_transitionPageManagers[currentTransitionManager].UpdatePageCounter();
    }
}
