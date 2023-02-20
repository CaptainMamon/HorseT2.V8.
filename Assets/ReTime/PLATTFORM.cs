using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATTFORM : MonoBehaviour
{
    Rigidbody m_rigidbody;
    ReTime m_reTime;
    public bool m_isRecording = false;
    public GameObject m_destroyParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_reTime = GetComponent<ReTime>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rigidbody.velocity == Vector3.zero)
        {
            m_isRecording = false;
            if (m_reTime != null)
            {
                m_reTime.StopFeeding();

            }
            
        }
        else if (!m_isRecording)
        {
            m_isRecording = true;
            if (m_reTime != null)
            {
                m_reTime.StartFeeding();

            } 
        }
        //operadro org | 
        //operador and &

        if (TimeManager.Instance.objectStop)
        {
            m_rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            m_rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
          
        }
        

        
    }
    public void OnCollisionEnter(Collision collision)
    {
        DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);
        
    }
}
