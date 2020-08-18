using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    [SerializeField] ChangeGraf projector;
    int round = 0;

    float timer = 5;
    // Update is called once per frame
    void Update()
    {
        if(timer > 0.0f)
            timer -= Time.deltaTime;
        else
        {
            projector.ChangeSlide(round);
            round++;
            timer = 5;
        }
    }
}
