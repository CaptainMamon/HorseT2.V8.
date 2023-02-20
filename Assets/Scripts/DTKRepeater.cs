using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DTKRepeater : MonoBehaviour
{
    public float m_minRepeatTime = 1.0f;
    public float m_maxRepeatTime = 4.0f;
    public float m_currentRepeatTime = 0.0f;
    float m_timeCounter = 0.0f;
    public UnityEvent m_functionToRepeat;
    public bool m_isActive = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (m_isActive)
        {
            m_timeCounter += Time.deltaTime;
            if (m_timeCounter > m_currentRepeatTime) 
            {
                m_timeCounter = 0.0f;
                m_currentRepeatTime = Random.Range(m_minRepeatTime, m_maxRepeatTime);
                if (m_functionToRepeat != null)
                {
                    m_functionToRepeat.Invoke();
                }
            }

        }
        
    }
    public void Play()
    {
        m_isActive = true;
    }
    public void Pause()
    {
        m_isActive = false;
    }
}
