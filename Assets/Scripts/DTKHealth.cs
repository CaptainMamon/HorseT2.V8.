using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DTKHealth : MonoBehaviour
{
    public AudioClip m_hurtSound;
    public float m_maxHealth = 10.0f;
    public float m_currentHealth = 10.0f;
    public UnityEvent OnHealthChangedEvent;
    public UnityEvent OnDieEvent;
    public UnityEvent OnHealEvent;
    // Start is called before the first frame update
    void Start()
    {
        m_currentHealth = m_maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damageAmount)
    {
        m_currentHealth -= damageAmount;
        OnHealthChanged();
        if (m_currentHealth <= 0)
        {
            Kill();
        }
        if (m_hurtSound != null)
        {
            DTKAUDIOMANAGER.m_istance.PlayerClipRandomPitch(DTK_AUDIOSOURCE.kSFX, m_hurtSound, 1.0f, 0.7f, 1.3f);
        }
    }

    public void Heal(float healthAmount)
    {
        m_currentHealth += healthAmount;
        OnHealthChanged();
        if (OnHealEvent != null) 
        {
            OnHealEvent.Invoke(); 
        }

    }
    public void Kill()
    {
        m_currentHealth = 0;
        OnHealthChanged();

    }
    void OnHealthChanged()
    {
        OnDieEvent.Invoke();
    }

}
