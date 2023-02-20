using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKDamageTrigger : MonoBehaviour
{
    public float m_damagePoints = 1.0f;
    public bool m_destroyOnTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        DTKHealth otherHealth = other.GetComponent<DTKHealth>();
        if (otherHealth != null)
        {
            otherHealth.Damage(m_damagePoints);
        }

        if (m_destroyOnTrigger)
        {
            Destroy(gameObject);
        }
    }
}
