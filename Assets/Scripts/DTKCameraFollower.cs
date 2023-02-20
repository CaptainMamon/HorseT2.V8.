using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKCameraFollower : MonoBehaviour
{
    public Transform m_target;
    public float m_smothness = 5.0f;
    Vector3 m_offset;
 
    // Start is called before the first frame update
    void Start()
    {
        m_offset = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPoat = Vector3.Lerp(transform.position, m_target.position + m_offset, Time.deltaTime * m_smothness);
        transform.position = cameraPoat;
        
    }
}
