using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltifalanteBoy : MonoBehaviour
{
    float timer = 0;
    float timer2 = 0;
    bool showing = false;
    bool showing2 = false;
    public AudioSource aSource;
    public Animator screen;
    public bool transitions = false;
    public float timeToTalk = 0;
    bool completed = false;
    float timeSinceCompleted=0;
    [SerializeField] AudioClip completedClip;
    // Start is called before the first frame update
    void Start()
    {
        //aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

       // Debug.Log(timer);
        if(timer>timeToTalk && !showing)
        {
            showing = true;
            GetComponent<MeshRenderer>().enabled=true;
            aSource.Play();
        }
        if(showing)
        {
            timer2 += Time.deltaTime;
        }

        if (timer2 > aSource.clip.length)
        {
            if(transitions)
                screen.Play("ScreenFadeOut");
            GetComponent<MeshRenderer>().enabled = false;
            showing = false;
        }


        if(completed && !showing)
        {

            showing = true;
            GetComponent<MeshRenderer>().enabled = true;
            aSource.clip = completedClip;
            aSource.time = 0;
            aSource.Play();
        }

        if(completed)
        {
            
            timeSinceCompleted += Time.deltaTime;
            if(timeSinceCompleted>aSource.clip.length)
            {
                Debug.Log("Nicedudee");
            }
        }

        
        
            




    }

    public void Completed()
    {
        completed = true;
        showing = false;
    }


    public void Concordo()
    {

    }
    public void Discordo()
    {

    }
}
