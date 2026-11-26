using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BookPageManager : MonoBehaviour
{
    [SerializeField] private Transform m_parentPage;
    [SerializeField] List<GameObject> m_prefabPages;
    [SerializeField] private GameObject m_publication;
    private GameObject m_currentPageObj;
    private int m_currentPageIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeToPage(0);
    }

    public void ChangeToPage(int pageIndex)
    {
        if (m_currentPageObj != null)
        {
            Destroy(m_currentPageObj);
        }
        m_currentPageObj = Instantiate(m_prefabPages[pageIndex], m_parentPage);
        m_currentPageIndex = pageIndex;
    }

    public void NextPage()
    {
        if (m_currentPageIndex == m_prefabPages.Count - 1)
        {
            this.gameObject.SetActive(false);
            m_publication.SetActive(true);
            return;
        }
        m_currentPageIndex++;
        ChangeToPage(m_currentPageIndex);
    }

    public void PreviousPage()
    {
        if (m_currentPageIndex == 0) return;
        m_currentPageIndex--;
        ChangeToPage(m_currentPageIndex);
    }
}

