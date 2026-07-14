using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private float m_timeTillActivateChange = 2f;
    [SerializeField] private bool m_triggerOnce = false;

    [SerializeField] private UnityEvent m_changeEvent;

    private Coroutine m_timerTillActivate;

    #region TriggerChange
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {            
            if(m_timerTillActivate != null)
            {
                StopCoroutine(m_timerTillActivate);
            }
            m_timerTillActivate = StartCoroutine(WaitTillActivatingChange());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_timerTillActivate != null)
        {
            StopCoroutine(m_timerTillActivate);
        }
    }

    private IEnumerator WaitTillActivatingChange()
    {
        yield return new WaitForSeconds(m_timeTillActivateChange);

        m_changeEvent.Invoke();

        //Trigger Change Called
        if (m_triggerOnce)
        {
           GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    #endregion
}
