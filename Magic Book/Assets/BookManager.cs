using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private Transform m_pageParent;
    [SerializeField] private List<GameObject> m_pagePrefabs;

    private int m_currentIndex = 0;

    private static BookManager instance;
    public static BookManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("BookManager  is null");
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one BookManager in the scene!");
        }

        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiatePage(1); //Initilize Start Page
    }

    public void InstantiatePage(int nextPageIndex)
    {
        int nextPage = nextPageIndex - 1;
        if (nextPage == m_pagePrefabs.Count) return;

        if(m_currentIndex != 0)
        {
            Destroy(m_pageParent.GetChild(0).gameObject);
        }

        Instantiate(m_pagePrefabs[nextPage], m_pageParent);
        m_currentIndex = nextPage; 
    }
}
