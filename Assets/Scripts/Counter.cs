using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{ 
    const uint m_TIME_LIMIT = 10;
    const float m_WAIT_TIME = 0.1f;
    float m_currentTime = 0.0f;
    
    IEnumerator CountDown()
    {
        while (m_currentTime < m_TIME_LIMIT)
        {
            m_currentTime += UnityEngine.Time.deltaTime;
            yield return new WaitForSeconds(m_WAIT_TIME);
        }
    }

    /* sets to zero
     * then starts
     */
    public void Start()
    {
        m_currentTime = 0.0f;
        StartCoroutine("CountDown");
    }
    
    /* carrys on from previously left time
     */
    public void Resume()
    {
        StartCoroutine("CountDown");
    }
    /* haults timer 
     */
    public void Pause()
    {
        StopCoroutine("CountDown");
	}
    /* timer is rest to zero
     */
    public void Reset()
    {
        m_currentTime = 0.0f;
    }
    /* timer is rest to zero and stopeped
     */
    public void Stop()
    {
        Pause();
        Reset();
    }

}
