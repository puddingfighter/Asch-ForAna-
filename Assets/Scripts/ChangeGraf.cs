using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGraf : MonoBehaviour
{
    static System.Random _random = new System.Random();

    [SerializeField] GameM GameM;
    [SerializeField] Material material;
    
    List<Cartões> cartões;
    Cartões materials;


    private void OnEnable()
    {
        GameM.onRound += Round_onRoundEnd;
    }

    private void OnDisable()
    {
        GameM.onRound -= Round_onRoundEnd;
    }

    /// <summary>
    /// Cria uma lista de cartões e dá shuffle à ordem
    /// </summary>

    private void Awake()
    {
        
        AddToList();
    }




    /// <summary>
    /// É ativado quando houve um evento vai dar a ronda e daí vai chamar uma função para mudar o gráfico no screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="round"></param>
    private void Round_onRoundEnd(object sender, int round)
    {

        Debug.Log("yeah");
        ChangeBoard(round);
        //material.mainTexture = boards[round];
    }



    /// <summary>
    /// Server para dar shuffle da lista 
    /// </summary>
    /// <typeparam name="Cartões">Tipo da lista</typeparam>
    /// <param name="array">a lista que vai ser dada</param>
    public static void Shuffle<Cartões>(IList<Cartões> array)
    {
        int n = array.Count;
        for (int i = 0; i < (n - 1); i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            Cartões t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }

    private void AddToList()
    {
        Debug.Log(boards.Length);
        int resposta = 1;
        //Corre todas as texturas do array, cria um array e adiciona-o à lista de cartões 
        for (int i = 0; i <= boards.Length; i++)
        {
            Debug.Log(i);
            cartões.Add(new Cartões(boards[i], resposta));
            resposta++;
            if (resposta > 3)
                resposta = 1;
            Debug.Log(resposta);
        }
        Shuffle<Cartões>(cartões);
    }

    /// <summary>
    /// método que vai mudar a textura/albedo do material
    /// </summary>
    /// <param name="round">a ronda serve de index da lista</param>
    private void ChangeBoard(int round)
    {
        Debug.Log("banana");
        materials = cartões[round];
        material.mainTexture = materials.Board;
    }
}
/// <summary>
/// Esta classe cria um tuplo com uma textura e a resposta certa
/// </summary>
public class Cartões
{
    public Texture Board { get;}
    public int Resposta { get; }
    public Cartões(Texture board, int resposta)
    {
        Board = board;
        Resposta = resposta;
    }
}

