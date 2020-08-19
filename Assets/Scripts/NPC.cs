using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameM GameM;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameM.onRoundEnd += Round_onRoundEnd;
    }

    private void OnDisable()
    {
        GameM.onRoundEnd -= Round_onRoundEnd;
    }

    private void Round_onRoundEnd(object sender, int round)
    {
        
    }

    private void PlaySound()
    {

    }

    // Update is called once per frame
}
