using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Custom object used to keep from a designer a dictionary of what UI each State has to load.
[System.Serializable]
public struct UIView
{
    //Game State key, from Game manager
    public GameState key;
    //List of resources ui to be loaded. 
    public GameObject[] resource;
}

//UI Manager class. EVERY TIME that you must use this class you'll use it through UIManager.Isntance
public class UIManager : MonoBehaviourSingleton<UIManager>
{
    //List filled by an designer to load each needed ui for each level.
    [SerializeField]
    private List<UIView> m_uis;

    //Previous list will be converted to this disctionary and will get ereased.
    private Dictionary<GameState, GameObject[]> m_uisMap;

    //These are all the already loaded UIs fopr the already opened level.
    private List<Canvas> m_loadedUIs;

    // Start is called before the first frame update
    void Start()
    {
        //Copy all info from list to a map
        m_uisMap = new Dictionary<GameState, GameObject[]>();
        m_loadedUIs = new List<Canvas>();

        //Here we transfer the information from a list to a dictionary to make it faster to access.
        foreach (var uiview in m_uis)
        {
            m_uisMap.Add(uiview.key, uiview.resource);
        }

        //Clear and delete memory for that previous list.
        m_uis.Clear();
        m_uis = null;

        //Subscribe to the On Game State Change so this Manager is notified every time a state changes.
        GameManager.Instance.SubscribeOnStateChange(OnGameStateChange);
        OnGameStateChange((GameState)SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        //Think on adding a dirty flag here
        //Short timer to show ui
    }

    //State Machine Like function
    public void OnGameStateChange(GameState newGameState)
    {
        //Clear previously loaded uis
        foreach (var ui in m_loadedUIs)
        {
            Destroy(ui.gameObject);
        }

        //Clear previously loaded uis
        m_loadedUIs.Clear();

        GameObject[] UIPrefabs = m_uisMap[newGameState];
        foreach (var uiPrefab in UIPrefabs)
        {
            var canvas = Instantiate(uiPrefab, transform, true).GetComponent<Canvas>();
            m_loadedUIs.Add(canvas);
        }

        /*foreach (var ui in m_loadedUIs)
        {
            ui.enabled = false;
        }*/
    }

    //Show Player stats in scene.

    public void UpdateHealthBar(float healthPercentage)
    {
        if (GameManager.Instance.CurrentState == GameState.kGAME)
        {
            Image image = GetComponentInChildren<Image>();
            image.fillAmount = healthPercentage;
        }
    }
}