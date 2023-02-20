using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKParticleManager : MonoBehaviour
{
    public static DTKParticleManager m_instance;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public ParticleSystem SpawnParicle(GameObject prefab, 
                                       Vector3 position, 
                                       Vector3 eulerAngles, 
                                       float scaleMult, 
                                       bool destroOnFinish = true, 
                                       Transform parent = null)
    {
        ParticleSystem particle = Instantiate(prefab, position, Quaternion.Euler(eulerAngles), parent).GetComponent<ParticleSystem>();
        particle.transform.localScale *= scaleMult;
        
        if (destroOnFinish)
        {
            Destroy(particle.gameObject, particle.main.duration);
        }
        return particle;
    }
}
