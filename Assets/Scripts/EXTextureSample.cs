using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXTextureSample : MonoBehaviour
{
    public float m_degreesPerSecond = 60; // cuantos angulos por segundo se aplicarán a la rotacion.
    public bool m_automatic = true;
    public Transform m_target;
    public float m_rotataionSpeed = 6.0f;
    public GameObject m_bulletPrefab;
    public GameObject m_bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_automatic)
        {
            Vector3 targetDirection = m_target.position - transform.position; // calcular direccion del la torreta hacia el target
            targetDirection.y = 0.0f; // ignorar eje Y
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection); // crear direccion
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_rotataionSpeed); //aplicar y suavizar rotacion
        }
        else
        {
            Vector3 newAngles = transform.localEulerAngles; // inicializar con los angulos actuales

            if (Input.GetKey(KeyCode.Q)) // izquierda
            {
                newAngles.y -= Time.deltaTime * m_degreesPerSecond; // restar angulos
            }
            if (Input.GetKey(KeyCode.E)) // derecha
            {
                newAngles.y += Time.deltaTime * m_degreesPerSecond; // sumar angulos
            }

            //newAngles.y += Input.mouseScrollDelta.y * 10;

            transform.localEulerAngles = newAngles; // aplicar nuevos angulos
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(m_bulletPrefab, m_bulletSpawnPoint.transform.position, m_bulletSpawnPoint.transform.rotation);
        }

    }
}
