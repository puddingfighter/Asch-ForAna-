using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooshy : MonoBehaviour
{


    [SerializeField]
    private GameObject[] _avatars;

    GameObject lookAt;
    int idx = 0;
    
    void Start()
    {
        lookAt = _avatars[0];
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            idx++;
            if(idx>_avatars.Length-1)
            {
                idx = 0;
            }
            lookAt = _avatars[idx];

        }

        float Dist = Vector3.Distance(transform.position, _avatars[idx].transform.position);

        transform.position= Vector3.Lerp(transform.position, _avatars[idx].transform.position, (Dist*5)*Time.deltaTime);

        //Vector3 targetDirection = lookAt.transform.parent.transform.position - transform.position;

        //float angle = Quaternion.Angle(transform.rotation, lookAt.transform.rotation);
        

        float coolerAngle=Vector3.AngleBetween(transform.forward, transform.position - lookAt.transform.position);
        Vector3 _direction = (lookAt.transform.parent.transform.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 5);

    }

}
