using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGraf : MonoBehaviour
{

    [SerializeField] GameM GameM;
    [SerializeField] Material material;
    Cartões materials;


    private void OnEnable()
    {
        GameM.onRound += Round_onRoundEnd;
        GameM.onExperienceEnd += On_onExperienceEnd;
    }

    private void OnDisable()
    {
        GameM.onRound -= Round_onRoundEnd;
    }





    /// <summary>
    /// É ativado quando houve um evento vai dar a ronda e daí vai chamar uma função para mudar o gráfico no screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="round"></param>
    private void Round_onRoundEnd(object sender, Cartões cartões)
    {
        ChangeBoard(cartões);
    }


  

    /// <summary>
    /// method that will change thw texture/albedo of the material
    /// </summary>
    /// <param name="round">a ronda serve de index da lista</param>
    private void ChangeBoard(Cartões cartão)
    {
        materials = cartão;
        material.mainTexture = materials.Board;
    }

    private void On_onExperienceEnd(object sender, EventArgs e)
    {
        material.SetColor("White", Color.white);
    }
}



