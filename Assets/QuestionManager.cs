using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] string[] questions;
    [SerializeField] bool[] answers;
    int currentIdx = 0;
    [SerializeField] Text questionNumber;
    [SerializeField] Text displayQuestion;
    [SerializeField] Animator anim;
    [SerializeField] Animator animPopUp;

    // Start is called before the first frame update
    void Start()
    {
        answers = new bool[13];
    }

    // Update is called once per frame
   
    public void VerdadeiroPress()
    {
        answers[currentIdx] = true;
        anim.Play("ChangeQuestion");

    }
    public void FalsoPress()
    {
        answers[currentIdx] = false;
        anim.Play("ChangeQuestion");
    }

    public void ShowNewMessage()
    {
        currentIdx++;
        displayQuestion.text = questions[currentIdx];
        questionNumber.text = "Pergunta " + (currentIdx + 1).ToString();
    }
    public void PopUpOFF()
    {
        animPopUp.Play("popupOff");
    }

}
