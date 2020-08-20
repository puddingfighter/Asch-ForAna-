using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    public event EventHandler <int> onRound;
    public event EventHandler <GameObject> talk;
    int round = 0;
    int npcidx = 0;
    float timer = 5;
    // Respostas : 1, 2, 3, 1, 2, 3, 1, 2, 3,
    // Fazer um tuplo com o cartão e com o valor certo exem - (A.1.1;1) e depois dar random aos valores.
    [SerializeField] Texture[] boards;
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
                                talk?.Invoke(this, npc);
                                
                            }
                             

                            break;
                        }

                    case 2:
                        {
                            break;
                        }
                }
                onRound?.Invoke(this, round);
                round++;
                timer = 5;
            }

        }
        else
            Debug.Log("experience ended");

    }

    //Fazer metodo para fazer lista de boards
    //Fazer shuffle do board
}
