using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDR : MonoBehaviour
{
    [SerializeField] float time = 0;
    [SerializeField] bool go = false;
    Coroutine timerCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("storyTime");
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 1;
        //    print("CD");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true) { 
            yield return new WaitForSeconds(time);
        print("hello");
         }
        //yield return null;

    }
    IEnumerator storyTime()
    {
        print("HELLO");
        yield return new WaitForSeconds(1);
        print("WELCOME");
        yield return new WaitForSeconds(1);
        print("TIME TO DIE");

        StopCoroutine(timerCoroutine);

        yield return null;
    }
    IEnumerator waitAction()
    {

        print(go);
        yield return null;
    }
}
