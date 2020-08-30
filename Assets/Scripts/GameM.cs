using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    static System.Random _random = new System.Random();
    public event EventHandler <Cartões> onRound;
    public event EventHandler onExperienceEnd;
    int round = 0;
    bool playerChoice = true;
    List<Cartões> cartões = new List<Cartões>();

    [SerializeField] Player player;
    [SerializeField] int startShuffle;
    [SerializeField] int endShuffle;
    [SerializeField] Texture[] boards;
    private void Start()
    {
        AddToList(cartões);
    }
    

    /// <summary>
    /// Will run 18 times (all the boards) and activate an even 
    /// </summary>
    void Update()
    {

        if (round <= 17 && playerChoice == true)
        {
            onRound?.Invoke(this, cartões[round]);
            playerChoice = player.Choice();
            round++;
        }
        //Este if é incorreto, mas foi a unica maneira que encontrei para que 
        //o método Update pedisse a escolha ao jogador
        if(round <= 17 && playerChoice == false)
        {
            playerChoice = player.Choice();
        }
        else
            onExperienceEnd?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Shuffles the boards . Default is from 2 to array lenght or you can choose were you want to shuffle
    /// </summary>
    /// <typeparam name="Cartões"></typeparam>
    /// <param name="array"></param>
    /// <param name="startShuffle">Were you want to start the shuffle</param>
    /// <param name="endShuffle">Were you want to end the shuffle</param>
    public static void Shuffle<Cartões>(IList<Cartões> array, int startShuffle, int endShuffle)
    {
        
        if (endShuffle == 0)
             endShuffle = array.Count;
        if (startShuffle == 0)
            startShuffle = 2;
        for (startShuffle = 2; startShuffle < (endShuffle - 1); startShuffle++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = startShuffle + _random.Next(endShuffle - startShuffle);
            Cartões t = array[r];
            array[r] = array[startShuffle];
            array[startShuffle] = t;
        }
    }

    /// <summary>
    /// Creates several Cartões, ads to the list and then shuffles
    /// </summary>
    /// <param name="cartões"></param>
    void AddToList(List<Cartões> cartões)
    {
        int resposta = 1;
        //Corre todas as texturas do array, cria um array e adiciona-o à lista de cartões 
        for (int i = 0; i < boards.Length; i++)
        {
            cartões.Add(new Cartões(boards[i], resposta));
            resposta++;
            if (resposta > 3)
                resposta = 1;
        }
        Shuffle<Cartões>(cartões,startShuffle,endShuffle);
    }
}

/// <summary>
/// This class creates a tuple with a board(texture) and the right answer
/// </summary>
public class Cartões
{
    public Texture Board { get; }
    public int Resposta { get; }
    public Cartões(Texture board, int resposta)
    {
        Board = board;
        Resposta = resposta;
    }
}


