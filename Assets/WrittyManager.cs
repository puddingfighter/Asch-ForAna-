using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrittyManager : MonoBehaviour
{

    [SerializeField] InputField txtMessage;
    [SerializeField] Text lblCount;
    [SerializeField] Animator anim;
    int cnt=0;
    // Start is called before the first frame update
    bool helpOn = false;
    public void UpdateTextCount()
    {
        cnt = txtMessage.text.Length;
        lblCount.text = "Atual " + cnt.ToString() + "/250";
    }

    public void ButtonPress()
    {
        if(!helpOn)
        {

        }
    }

    public void HelpPress()
    {
        if (!helpOn)
        {
            helpOn = true;
            anim.Play("HelpPopUp");
        }
    }
    public void HelpClose()
    {
        if (helpOn)
        {
            helpOn = false;
            anim.Play("HelpPopDown");
        }
    }
  
}
