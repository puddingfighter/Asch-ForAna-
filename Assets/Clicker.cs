using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public Camera cam;
    int clickCount=0;
    float timeSinceLastClick;
    Transform hitting;
    bool hasClicked = false;
    bool isLeft = true;
    public Transform Aux;
    public Material[] mats;
    public GameObject congrats;
    int cnt = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cnt);
        timeSinceLastClick += Time.deltaTime;

        if (timeSinceLastClick > 0.3f)
            clickCount = 0;
        else if(hasClicked && clickCount>5)
        {
            if(isLeft)
                hitting.Rotate(0, 0.2f, 0, Space.Self);
            else
                hitting.Rotate(0, -0.2f, 0, Space.Self);
            
            ChangeMat();
        }
        

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        { // if left button pressed...

           

            hasClicked = true;
            clickCount++;
            //if(timeSinceLastClick<0.3f && clickCount>5)
           // {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.gameObject.tag=="DaCube")
                        hitting = hit.transform;
                    else
                    {
                        hitting = Aux;
                    }
                   
                }

            //}

            if (Input.GetMouseButtonDown(0))
            {
                isLeft = true;
                if (timeSinceLastClick > 0.3f)
                {
                    hitting.Rotate(0, 1.5f, 0, Space.Self);
                }
            }
            else
            {
                isLeft = false;
                if (timeSinceLastClick > 0.3f)
                {
                    hitting.Rotate(0, -1.5f, 0, Space.Self);
                }
            }

            ChangeMat();
            

            timeSinceLastClick = 0;
        }



        if(cnt==35)
        {
            congrats.SetActive(true);
        }

    }


    void ChangeMat()
    {
        if (hitting.eulerAngles.y > 85 && hitting.eulerAngles.y < 95)
        {
            if (hitting.gameObject.name!="done")
            {
                hitting.gameObject.name = "done";
                hitting.GetComponent<MeshRenderer>().material = mats[1];
                cnt++;
            }
        }
        else
        {

            if (!hitting.gameObject.name.StartsWith("Cube"))
            {
                hitting.gameObject.name = "Cube";
                hitting.GetComponent<MeshRenderer>().material = mats[0];
                cnt--;
            }
        }
    }
}
