﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGraf : MonoBehaviour
{
    [SerializeField] GameM GameM;
    [SerializeField] Material material;
    [SerializeField] Texture [] boards;

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
        material.mainTexture = boards[round];
    }
}
