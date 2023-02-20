using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKRadislPrefabSpawner : DTKPrerfabSpawner
{
    public float m_radius;
    public int m_count = 0;

    void Start()
    {
        if (m_spawnOnStart)
        {
            for (int i = 0; i < m_count; i++)
            {
                SpawnerPrefab();
            }
        }
    }

    public override void SpawnerPrefab()
    {
        int randomIdx = Random.Range(0, m_prebabList.Count);
        if (m_prebabList[randomIdx] == null)
        {
            return;
        }
        Vector2 offset = Random.insideUnitCircle * m_radius;

        GameObject spawnerObject = Instantiate(m_prebabList[randomIdx],
                                               transform.position + new Vector3(offset.x, 0, offset.y),
                                               transform.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "PrefabIcon", true);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }
}

