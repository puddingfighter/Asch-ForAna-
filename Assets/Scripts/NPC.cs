using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] ChangeGraf grafs;
    [SerializeField] GameM gm;
    int count;
    // Start is called before the first frame update
    private void OnEnable()
    {
        gm.talk += Talk;
    }

    private void OnDisable()
    {
        gm.talk -= Talk;
    }

    private void Talk (object sender, GameObject npc)
    {
        PlaySound()
    }

    private void PlaySound()
    {
        Debug.Log()
    }

    // Update is called once per frame
}
