using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSEHORSE : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject PauseUI;

    void Start()
    {
        PauseUI = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          

        }
        
        
    }
    public void PauseGame()
    {
        GameUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ResumeGame()
    {
        GameUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;

    }


    // Update is called once per frame
}
