using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    public event EventHandler <int> onRoundEnd;
    int round = 0;
    int npcidx = 0;
    float timer = 5;

    [SerializeField] GameObject[] nPC;
    public AudioClip[] clips;
    // Update is called once per frame
    void Update()
    {
        if (round <= 17)
        {
            if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                switch(round)
                {
                    case 1:
                        {
                            foreach(GameObject npc in nPC)
                            {
                                
                            }
                             

                            break;
                        }

                    case 2:
                        {
                            break;
                        }
                }
                onRoundEnd?.Invoke(this, round);
                round++;
            }

        }
        else
            Debug.Log("experience ended");

    }
}
