using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBoyIn : MonoBehaviour
{
    float timer = 0;
    public GameObject LogBoy;
    public Animator texter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>9)
        {
            LogBoy.SetActive(true);
            GetComponent<AudioSource>().Play();
            texter.Play("FadeIn");
            Destroy(this);
        }
    }
}
