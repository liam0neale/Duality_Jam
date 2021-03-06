using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{ 
    float m_TIME_LIMIT = 1.0f; // seconds
    const float m_WAIT_TIME = 0.1f; // seconds
    float m_currentTime = 0.0f;
    bool isCounting = false;

    IEnumerator CountDown(float _wait)
    {
        while (m_currentTime < m_TIME_LIMIT)
        {
            m_currentTime += 10 * UnityEngine.Time.deltaTime;
            yield return new WaitForSeconds(_wait);
        }
    }

    /* get decimal value for distance thorugh timer
     */
    public float GetDistanceThrough()
    {
        float distance = m_currentTime / (float)m_TIME_LIMIT;
        return distance;
	}

    public void SetTimeLimit(float _time){ m_TIME_LIMIT = _time; }
    public bool IsTimeOver()
    {
        if (m_currentTime >= m_TIME_LIMIT)
            return true;
        return false;
	}
    public bool IsCounting()
    {
        return isCounting;
	}

    /* sets to zero
     * then starts
     */
    public void StartTimer()
    {
        m_currentTime = 0.0f;
        Resume();
    }
    
    /* carrys on from previously left time
     */
    public void Resume()
    {
        isCounting = true;
        StartCoroutine(CountDown(m_WAIT_TIME));
    }

    /* haults timer 
     */
    public void Pause()
    {
        StopCoroutine(CountDown(m_WAIT_TIME));
        isCounting = false;
	}

    /* timer is rest to zero
     */
    public void ResetTimer()
    {
        m_currentTime = 0.0f;
    }
    /* timer is rest to zero and stopeped
     */
    public void Stop()
    {
        Pause();
        ResetTimer();
    }

}
