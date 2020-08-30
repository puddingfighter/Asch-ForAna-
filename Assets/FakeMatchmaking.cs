using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMatchmaking : MonoBehaviour
{
    float timer;
    public GameObject idleText;
    public GameObject startText;
    public float searchTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>searchTime)
        {
            idleText.SetActive(false);
            startText.SetActive(true);
            
        }
        if(timer>searchTime+5)
        GetComponent<ChangeScene>().ChangeToScene("Espera");
    }
}
