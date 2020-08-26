using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc: MonoBehaviour
{
    
    [SerializeField] AudioClip[] answers;
    AudioSource aSource;
    bool isTalking = false;
    float timer = 0;


    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    public void Speak(int answer, bool lies,int lie)
    {
        Debug.Log(name + answer);
        if (!isTalking)
        {
            if (lies == true)
            {
                //SndManager.instance.PlaySound(answers[answer]);

                aSource.clip = answers[answer];
                aSource.Play();
                isTalking = true;
                Debug.Log(answer);
            }
            else
            {
                Debug.Log(lie);
            }
        }

    }
    private void Update()
    {

        if(isTalking)
        {
            timer += Time.deltaTime;

           if(timer +5 > aSource.clip.length)
           {
                NpcManager.instance.Idxcounter();
           }

        }
    }


}
