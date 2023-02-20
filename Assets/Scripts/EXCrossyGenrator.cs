using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXCrossyGenrator : MonoBehaviour
{
    public GameObject m_chunkSpawnerPrefab;
    public int m_chunkCount = 10;
    public float m_chunkSize = 30;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_chunkCount; i++) 
        {
            Instantiate(m_chunkSpawnerPrefab,
                new Vector3 (0,0, m_chunkSize * i),
                Quaternion.identity);
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
