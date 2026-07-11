using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] int m_pageIndex;

    public int PageIndex { get => m_pageIndex; set => m_pageIndex = value; }

    public void TurnPageLeft()
    {
        if (m_pageIndex == 1) return;
        BookManager.Instance.InstantiatePage(m_pageIndex-1);
    }

    public void TurnPageRight()
    {
        BookManager.Instance.InstantiatePage(m_pageIndex+1);
    }

}
