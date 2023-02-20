using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DTK_SHAKE_TYPE
{
    kPosition,
    kScale,
    kRotation
}

public class DTKPositionShake : MonoBehaviour
{
    public DTK_SHAKE_TYPE m_type;
    public Vector3 m_shakeAmount;
    public float m_shakeCycles = 1;
    public float m_shakeDuration = 0.5f;
    float m_shakeTimeCounter = 0.0f;

    public bool m_isActive = false;
    Vector3 m_currentOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayShake();
        }

        if (m_type == DTK_SHAKE_TYPE.kPosition)
        {
            transform.localPosition -= m_currentOffset;
        }
        
        else if (m_type == DTK_SHAKE_TYPE.kScale)
        {
            transform.localScale -= m_currentOffset;
        }
        else if (m_type == DTK_SHAKE_TYPE.kRotation)
        {
            transform.localEulerAngles -= m_currentOffset;
        }

        if (m_isActive)
        {
            m_shakeTimeCounter += Time.deltaTime;
            m_currentOffset = Mathf.Sin(m_shakeTimeCounter / m_shakeDuration * Mathf.PI * 2 * m_shakeCycles)* m_shakeAmount;
            
            if (m_shakeTimeCounter >= m_shakeDuration) 
            {
                m_isActive = false;
                m_currentOffset = Vector3.zero;
            }
        }

        if (m_type == DTK_SHAKE_TYPE.kPosition)
        {
            transform.localPosition += m_currentOffset;
        }
        
        else if (m_type == DTK_SHAKE_TYPE.kScale)
        {
            transform.localScale += m_currentOffset;
        }

        else if (m_type == DTK_SHAKE_TYPE.kRotation)
        {
            transform.localEulerAngles += m_currentOffset;
        }
    }

    public void PlayShake()
    {
        if(m_isActive == false)
        {
            m_isActive = true;
            m_shakeTimeCounter = 0.0f;
        }
    }
}
