using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransitionPageManager : MonoBehaviour
{
    [SerializeField] private UnityEvent[] m_transitionEvents;
    private int m_enteredPageCounter = 0;

    private Coroutine[] m_timerBeforeEventRoutine;
    private void Start()
    {
        m_timerBeforeEventRoutine = new Coroutine[m_transitionEvents.Length];
        UpdatePageCounter(); //TEST
    }
    private IEnumerator TimerBeforeEvent(float time, int eventIndex)
    {
        yield return new WaitForSeconds(time);
        m_transitionEvents[eventIndex].Invoke(); //Enables Trigger Zone 1, Lets Text apprear
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void UpdatePageCounter()
    {
        Debug.Log("UpdatePageCounter");
        m_enteredPageCounter++;
        if (m_enteredPageCounter == 2)
        {
            m_timerBeforeEventRoutine[0] = StartCoroutine(TimerBeforeEvent(2f, 0));
            m_timerBeforeEventRoutine[1] = StartCoroutine(TimerBeforeEvent(10f, 1)); //change Village and Sky to Court Mage Page
        }
    }

}
