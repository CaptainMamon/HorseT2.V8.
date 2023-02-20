using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKSpawnerInBox : DTKPrerfabSpawner
{
    public Vector3 m_size;
    public float m_radius;
    public int m_count = 0;
    // Start is called before the first frame update
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

    // Update is called once per frame
    public override void SpawnerPrefab()
    {
        int randomIdx = Random.Range(0, m_prebabList.Count);
        if (m_prebabList[randomIdx] == null)
        {
            return;
        }
        Vector3 offset = Vector3.zero;
        

        GameObject SpawnerObject = Instantiate(m_prebabList[randomIdx],
                                               transform.position + new Vector3(offset.x, offset.y, offset.z),
                                               transform.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "PrefabIcon", true);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, m_size);
    }


}
