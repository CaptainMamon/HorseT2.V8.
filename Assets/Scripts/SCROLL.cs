using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SCROLL : MonoBehaviour
{
    [SerializeField]
    RawImage scrolling;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector2 direccion;
    Rect rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = scrolling.uvRect;

    }

    // Update is called once per frame
    void Update()
    {
        rect.x += direccion.x * speed * Time.deltaTime;
        rect.y += direccion.y * speed * Time.deltaTime;
        scrolling.uvRect = rect;

    }
}

