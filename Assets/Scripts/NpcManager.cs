using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    static public NpcManager instance;
    static System.Random _random = new System.Random();
    [SerializeField] GameM Gamem;
    bool[] mentiras = { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true };
    int count = 0;
    [SerializeField] Npc[] Npcs;
    int idxNPC = 0;

    /// <summary>
    /// Creates a instance of NPCManager
    /// </summary>
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        //audioSources = new List<AudioSource>();
    }

    /// <summary>
    /// Shuffles the list "mentiras"
    /// </summary>
    private void Start()
    {
        //Gamem.onRound += Round_onRoundEnd;
        Shuffle<bool>(mentiras);
    }

    /// <summary>
    /// Attach the method to the event
    /// </summary>
    private void OnEnable()
    {
        Gamem.onRound += Round_onRoundEnd;
        //GameM.onExperienceEnd += On_onExperienceEnd;
    }

    /// <summary>
    /// detach the method from the event
    /// </summary>
    private void OnDisable()
    {
        Gamem.onRound -= Round_onRoundEnd;
    }

    /// <summary>
    /// It will call a method from NPC class and will send the correct answer ,
    /// if the NPC's need to lie or not and if they do need to lie which lie they need to say
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="cartões"> contains the answer</param>
    private void Round_onRoundEnd(object sender, Cartões cartões)
    {
        int num = Lie(cartões.Resposta);
        
        Npcs[idxNPC].Speak(cartões.Resposta, mentiras[count], num );

        
        count++;


    }

    /// <summary>
    /// Ads one to the NPC index
    /// </summary>
    public void Idxcounter()
    {
        idxNPC++;
    }

    /// <summary>
    /// It will give a lie depending of the answer
    /// </summary>
    /// <param name="answer">Correct answer</param>
    /// <returns>The number of the lie</returns>
    private int Lie(int answer)
    {
        int num;
        num = UnityEngine.Random.Range(1, 3);
        if (num == answer)
            return Lie(answer);
        else
            return num;
    }

    /// <summary>
    /// Shuffles the array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    public static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 2; i < (n - 1); i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }


}




