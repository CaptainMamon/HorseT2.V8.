using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKLookAt : MonoBehaviour
{
    public bool m_automatic = true;
    public Transform m_target;
    public float m_rotataionSpeed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = m_target.position - transform.position; // calcular direccion hacia el target
        targetDirection.y = 0.0f; // ignorar eje Y
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection); // crear direccion
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_rotataionSpeed); //aplicar y suavizar rotacion
    }
}
