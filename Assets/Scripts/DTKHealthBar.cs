using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTKHealthBar : MonoBehaviour
{
    public Image m_bar;
    public DTKHealth m_health;

    // Start is called before the first frame update
    void Start()
    {
        m_health.OnHealthChangedEvent.AddListener(UpdateBar);
    }

    void UpdateBar()
    {
        m_bar.fillAmount = m_health.m_currentHealth / m_health.m_maxHealth;
    }





}
