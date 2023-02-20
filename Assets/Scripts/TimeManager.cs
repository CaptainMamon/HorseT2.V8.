using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviourSingleton<TimeManager>
{
    public float timeEnemyStop = 0.0f;


    public float objectDeltaTime;
    public float enemyDeltaTime;

    public bool enemyStop = false;
    public bool objectStop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            objectStop = !objectStop;

        }

        if (!objectStop)
        {
            objectDeltaTime = Time.deltaTime;

        }
        else
        {
            objectDeltaTime = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            enemyStop = !enemyStop;
        }

        if (enemyStop)
        {
            enemyDeltaTime = 0;
            timeEnemyStop = timeEnemyStop + Time.deltaTime;

            if (timeEnemyStop >= 3.0f)
            {
                enemyStop = false;
                timeEnemyStop = 0.0f;
            }
        }
        else
        {
            enemyDeltaTime = Time.deltaTime;
        }

    }
}