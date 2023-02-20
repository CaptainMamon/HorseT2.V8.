using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKPrerfabSpawner : MonoBehaviour
{
    public List<GameObject> m_prebabList;
    public bool m_spawnOnStart = true;
    // Start is called before the first frame update
    void Start()
    {
        if (m_spawnOnStart)
        {
            SpawnerPrefab();

        }
        
    }

    // Update is called once per frame
    public virtual void SpawnerPrefab() 
    {
        int randomIdx = Random.Range(0, m_prebabList.Count);
        if (m_prebabList[randomIdx]==null)
        {
            return;
        }
        GameObject spawnerObject = Instantiate(m_prebabList[randomIdx], 
                                               transform.position, 
                                               transform.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "PrefabIcon", true);
    }
}
