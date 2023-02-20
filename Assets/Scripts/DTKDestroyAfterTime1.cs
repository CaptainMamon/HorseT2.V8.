using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKDestryyAfterTime : MonoBehaviour
{
    public float m_lifeTime = 1.0f;
    float m_currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;
        if (m_currentTime >= m_lifeTime)
        {
            Destroy(gameObject);
        }
    }
}