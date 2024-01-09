using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    float t = 0;
    public Light discoLight;
    [SerializeField]
    [Range(0.01f, 100.0f)] float cap;
    void Start()
    {
        // Record the start time when the script is initialized
        t = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - t >= cap)
        {

        discoLight.color = Random.ColorHSV();
            t = Time.time;
        }
    }
}
