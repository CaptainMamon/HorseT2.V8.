using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKTestTestingManager : MonoBehaviour
{
    public AudioClip m_music;
    public AudioClip m_ambient;
    // Start is called before the first frame update
    void Start()
    {
        DTKAUDIOMANAGER.m_istance.SetClip(DTK_AUDIOSOURCE.kMusic, m_music, 1.0f);
        DTKAUDIOMANAGER.m_istance.SetClip(DTK_AUDIOSOURCE.kAmbient, m_ambient, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Time.timeScale = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Time.timeScale += 0.1f;
        }
        Time.fixedDeltaTime = Time.timeScale * .02f;
        DTKAUDIOMANAGER.m_istance.SetPitch(DTK_AUDIOSOURCE.kMusic, Time.timeScale);
        DTKAUDIOMANAGER.m_istance.SetPitch(DTK_AUDIOSOURCE.kAmbient, Time.timeScale);
        DTKAUDIOMANAGER.m_istance.SetPitch(DTK_AUDIOSOURCE.kSFX, Time.timeScale);

    }
}
