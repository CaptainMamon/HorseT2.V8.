using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMIEEXPLOSION : MonoBehaviour
{
    public GameObject m_destroyParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);


    }
}
