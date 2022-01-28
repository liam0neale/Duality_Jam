using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{ 
    const uint m_TIME_LIMIT = 10;
    const float m_WAIT_TIME = 0.1f;
    float m_currentTime = 0.0f;
    bool isCounting = false;
    
    IEnumerator CountDown()
    {
        while (m_currentTime < m_TIME_LIMIT)
        {
            m_currentTime += UnityEngine.Time.deltaTime;
            yield return new WaitForSeconds(m_WAIT_TIME);
        }
    }

    /* get decimal value for distance thorugh timer
     */
    public float GetDistanceThrough()
    {
        float distance = m_currentTime / (float)m_TIME_LIMIT;
        return distance;
	}

    public bool IsCounting()
    {
        return isCounting;
	}

    /* sets to zero
     * then starts
     */
    public void Start()
    {
        m_currentTime = 0.0f;
        Resume();
    }
    
    /* carrys on from previously left time
     */
    public void Resume()
    {
        isCounting = true;
        StartCoroutine("CountDown");
    }

    /* haults timer 
     */
    public void Pause()
    {
        StopCoroutine("CountDown");
        isCounting = false;
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
