using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    bool holdingDown=false;
    [SerializeField] TextMeshPro txtCounter;
    [SerializeField]
    AudioSource aSource;
    [SerializeField] AltifalanteBoy guy;
    
    public GameObject niceParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
        HoldyRotate();
        //ClickyRotate();

        if (cnt == 35)
        {
            congrats.SetActive(true);
            guy.Completed();
        }
        if (Input.GetKeyDown("space"))
        {
            guy.Completed();
        }
    }


    void ChangeMat()
    {
        if (hitting.eulerAngles.y > 90 && hitting.eulerAngles.y < 95)
        {
            cnt++;
            txtCounter.SetText("{0}/35", cnt);
            if (hitting.gameObject.name!="done")
            {
                //Debug.Log("Got here!");
                hitting.gameObject.name = "done";
                hitting.GetComponent<MeshRenderer>().material = mats[1];
                
                Instantiate(niceParticles, new Vector3(hitting.position.x+0.2f, hitting.position.y+0.1f,hitting.position.z), Quaternion.identity);
                aSource.Play();
            }
        }
        else
        {

            if (!hitting.gameObject.name.StartsWith("Cube"))
            {
                //Debug.Log("Got here!");
                hitting.gameObject.name = "Cube";
                hitting.GetComponent<MeshRenderer>().material = mats[0];
                
            }
        }
    }
    void ClickyRotate()
    {
        timeSinceLastClick += Time.deltaTime;

        if (timeSinceLastClick > 0.3f)
            clickCount = 0;
        else if (hasClicked && clickCount > 5)
        {
            if (isLeft)
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
                if (hit.transform.gameObject.tag == "DaCube")
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



        
    }


    void HoldyRotate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "DaCube" )
                    hitting = hit.transform;
                else
                {
                    hitting = Aux;
                }

            }
            holdingDown = true;

            if (Input.GetMouseButtonDown(0))
            {
                isLeft = true;
            }
            else
                isLeft = false;
        }
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            holdingDown = false;
        }

        if(holdingDown)
        {
            if (hitting.gameObject.name != "done")
            {
                if (isLeft)
                    hitting.Rotate(0, 13f * Time.deltaTime, 0, Space.Self);
                else
                    hitting.Rotate(0, -13f * Time.deltaTime, 0, Space.Self);
                ChangeMat();
            }
        }



    }
}
