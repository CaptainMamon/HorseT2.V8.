using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum RotationType
{
    kNone,
    kLookAtMoveDir,
    kLookAtMouse,
}

public class PlayerT2V8 : MonoBehaviour
{
    public float m_currSpeed = 1.0f;
    public float m_walkSpeed = 3.0f;
    public float m_runSpeed = 6.0f;
    public float m_rotataionSpeed = 6.0f;
    public float m_pushForce = 1.0f;
    public RotationType m_rotType;
    CharacterController m_cc;
    public LayerMask m_wallLayer;

    public float jumpSpeed = 8.0f;
    public float gravity = 9.8f;
    public bool m_grouded;
    public Vector3 m_jumnpDirection;

    public GameObject m_destroyParticlePrefab;
    public AudioClip m_jumpSound;
    public bool m_canWallJump = true;
    public float m_velocityX;
    public float m_deseleration = 5;

    private Vector3 moveDir = Vector3.zero;
    private bool m_inWall;

    
    
    // Start is called before the first frame update
    void Start()
    {
        m_currSpeed = m_walkSpeed;
        m_cc = GetComponent<CharacterController>();
        if (m_cc == null)
        {
            m_cc = gameObject.AddComponent<CharacterController>();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PLAY");
        }
        //Move section
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_currSpeed = m_runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_currSpeed = m_walkSpeed;
        }
        //moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDir.x = Input.GetAxis("Horizontal") * m_currSpeed + m_velocityX;
        m_velocityX = Mathf.Lerp(m_velocityX, 0, Time.unscaledDeltaTime * m_deseleration);
        //moveDir = moveDir.normalized * m_currSpeed;
        Vector3 rayDir = new Vector3(moveDir.x, 0, 0);
        RaycastHit LowHit;
        Debug.DrawRay(transform.position, rayDir.normalized * 1);
        if (Physics.Raycast(transform.position, rayDir, out LowHit, 1, m_wallLayer))
        {
            m_inWall = true;

        }
        else
        {
            m_inWall = false;
            m_canWallJump = true;

        }

        if (m_cc.isGrounded ||( m_inWall && m_canWallJump))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_inWall)
                {
                    m_canWallJump = false;
                    m_velocityX = jumpSpeed * -rayDir.x;
                }
                
               
                moveDir.y = jumpSpeed;

                DTKAUDIOMANAGER.m_istance.PlayerClipRandomPitch(DTK_AUDIOSOURCE.kSFX, m_jumpSound, 1.0f, 0.7f, 1.3f);
                DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);

            }

        }
        moveDir.y -= gravity * Time.unscaledDeltaTime;

        //transform.position += moveDir.normalized * m_currSpeed * Time.deltaTime;
        m_cc.Move(moveDir * Time.unscaledDeltaTime);

        //Rotation section
        switch (m_rotType)
        {
            case RotationType.kNone:
                break;
            case RotationType.kLookAtMoveDir:
                if (moveDir != Vector3.zero)
                {
                    // calcular rotacion en base a la direccion que nos estamos moviendo
                    Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                    //Interpolar la rotacion actual con la rotacion deseada para dar efecto de suavizado
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.unscaledDeltaTime * m_rotataionSpeed);
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
                Quaternion targetPointRotation = Quaternion.LookRotation(pointDirection); // crear direccion
                transform.rotation = Quaternion.Lerp(transform.rotation, targetPointRotation, Time.unscaledDeltaTime * m_rotataionSpeed); //aplicar y suavizar rotacion
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
        if (collision.gameObject.CompareTag("Pared"))
        {

            
            //Vector3 horizontalVelocity = m_cc.velocity;
            //horizontalVelocity = new Vector3(m_cc.velocity.x, 0, m_cc.velocity.z);
            DTKParticleManager.m_instance.SpawnParicle(m_destroyParticlePrefab, transform.position, Vector3.zero, 1.0f);
        }
    }
    public void ResetButton()
    {
        
            

    }

}