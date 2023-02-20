using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DTK_AUDIOSOURCE
{
    kMusic,
    kSFX,
    kAmbient,
    kUI

}

public class DTKAUDIOMANAGER : MonoBehaviour
{
    public static DTKAUDIOMANAGER m_istance;
    public List<AudioSource> m_audioSource;
    public float m_masterVolumen = 1.0f;
    public List<float> m_volume;
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_istance == null)
        {
            m_istance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlayClip(DTK_AUDIOSOURCE source, AudioClip clip, float volume)
    {
        m_audioSource[(int)source].PlayOneShot(clip, volume * m_volume[(int)source] * m_masterVolumen);
    }
    public void PlayerClipRandomPitch(DTK_AUDIOSOURCE source, AudioClip clip, float volume, float minPitch, float maxPitch)
    {
        AudioSource tempSource = gameObject.AddComponent<AudioSource>();
        tempSource.pitch = Random.Range(minPitch, maxPitch);
        tempSource.PlayOneShot(clip, volume * m_volume[(int)source] * m_masterVolumen);
        Destroy(tempSource, clip.length / tempSource.pitch);
    }

    public void SetPitch(DTK_AUDIOSOURCE source, float newPitch)
    {
        m_audioSource[(int)source].pitch = newPitch;

    }
    public void Pause(DTK_AUDIOSOURCE source)
    {
        m_audioSource[(int)source].Pause();
    }
    public void SetClip(DTK_AUDIOSOURCE source, AudioClip clip, float volume)
    {
        m_audioSource[(int)source].Stop();
        m_audioSource[(int)source].volume = volume * m_volume[(int)source] * m_masterVolumen;
        m_audioSource[(int)source].clip = clip;
        m_audioSource[(int)source].Play();
    }

}
