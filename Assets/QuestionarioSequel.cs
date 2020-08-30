using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionarioSequel : MonoBehaviour
{
    [SerializeField] string[] questions;
    [SerializeField] int[] answers;
    int currentIdx = 0;
    [SerializeField] Text questionNumber;
    [SerializeField] Text displayQuestion;
    [SerializeField] Animator anim;
    [SerializeField] Animator animPopUp;

    // Start is called before the first frame update
    void Start()
    {
        answers = new int[13];
    }

    // Update is called once per frame

    public void ChoicePress(int value)
    {
        answers[currentIdx] = value;
        anim.Play("change15");

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
