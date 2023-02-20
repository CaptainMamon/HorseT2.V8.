using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rbPlayer : MonoBehaviour
{
    public float m_currSpeed = 1.0f;
    public float m_walkSpeed = 3.0f;
    public float m_runSpeed = 6.0f;
    public float m_rotataionSpeed = 6.0f;
    public float m_pushForce = 1.0f;
    public RotationType m_rotType;
    Rigidbody m_rb;
    public Transform m_rayOrigins;
    public float m_rayDistance = 0.1f;
    public LayerMask m_floorLayer;
    bool m_grounded = false;

    public float jumpSpeed = 8.0f;
    public float gravity = 0.1f;
    public AudioClip m_jumpSound;

    private Vector3 moveDir = Vector3.zero;

    public GameObject m_destroyParticlePrefab;
    public ParticleSystem m_polvo;

    // Start is called before the first frame update
    void Start()
    {
        m_currSpeed = m_walkSpeed;
        m_rb = GetComponent<Rigidbody>();
        if (m_rb == null)
        {
            m_rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move section
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_currSpeed = m_runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_currSpeed = m_walkSpeed;
        }
        if (Physics.Raycast(m_rayOrigins.position, Vector3.down, m_rayDistance, m_floorLayer))
        {
            m_grounded = true;


        }
        else
        {
            m_grounded = false;
        }
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDir = inputDir;
        moveDir = moveDir.normalized * m_currSpeed;
 
        


        if (m_grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            
            {
                DTKAUDIOMANAGER.m_istance.PlayerClipRandomPitch(DTK_AUDIOSOURCE.kSFX, m_jumpSound, 1.0f, 0.7f, 1.3f);
                m_rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

                DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);
 
                
            }
        }
        moveDir.y = m_rb.velocity.y;

        //transform.position += moveDir.normalized * m_currSpeed * Time.deltaTime;
        m_rb.velocity = moveDir;

        //Rotation section
        switch (m_rotType)
        {
            case RotationType.kNone:
                break;
            case RotationType.kLookAtMoveDir:
                if (inputDir != Vector3.zero)
                {
                    // calcular rotacion en base a la direccion que nos estamos moviendo
                    Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                    //Interpolar la rotacion actual con la rotacion deseada para dar efecto de suavizado
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_rotataionSpeed);
                }
                break;
            case RotationType.kLookAtMouse:
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // obtener rayo
                Plane plane = new Plane(Vector3.up, Vector3.zero); // crear plano
                float collisionDistance;
                Vector3 point = Vector3.zero;
                if (plane.Raycast(ray, out collisionDistance)) // si el rayo choca con el plano, obtener distancia de choque
                {
                    point = ray.GetPoint(collisionDistance); //obtener punto a la distancia en que choco el rayo con el plano
                }
                Vector3 pointDirection = point - transform.position; // calcular direccion del personaje hacia el punto de choque
                pointDirection.y = 0.0f;
                Quaternion targetPointRotation = Quaternion.LookRotation(inputDir); // crear direccion
                transform.rotation = Quaternion.Lerp(transform.rotation, targetPointRotation, Time.deltaTime * m_rotataionSpeed); //aplicar y suavizar rotacion
                break;
            default:
                break;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody hitRb = hit.gameObject.GetComponent<Rigidbody>();
        if (hitRb != null)
        {
            hitRb.AddForce(-hit.normal * m_pushForce, ForceMode.Impulse);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            DTKAUDIOMANAGER.m_istance.PlayerClipRandomPitch(DTK_AUDIOSOURCE.kSFX, m_jumpSound, 1.0f, 0.7f, 1.3f);
            DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);

        }
    }

}

