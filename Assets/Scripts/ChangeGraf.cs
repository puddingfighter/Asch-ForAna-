using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGraf : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Texture [] boards;
    

    public void ChangeSlide (int round)
    {
        material.mainTexture = boards[round];
    }
}
