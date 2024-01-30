using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    float t = 0;
    public Light BlinkLight;
    Color c = Color.white;
    [SerializeField]
    [Range(0.01f, 100.0f)] float cap;
    void Start()
    {
        // Record the start time when the script is initialized
        t = Time.time;
        c = BlinkLight.color;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - t >= cap)
        {
            if (BlinkLight.color == Color.clear)
            {
                BlinkLight.color = c;
            }
            else
            {
                BlinkLight.color = Color.clear;
            }
            t = Time.time;
        }
    }
}
