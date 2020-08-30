using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRPlayer : MonoBehaviour
{
    public GameObject Head;

    private List<XRNodeState> mNodeStates = new List<XRNodeState>();
    private Vector3 mHeadPos;
    private Quaternion mHeadRot;
    float[] YPositions = new float[50];

    private void Start()
    {
        List<XRInputSubsystem> subsystems = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances<XRInputSubsystem>(subsystems);
        for (int i = 0; i < subsystems.Count; i++)
        {
            subsystems[i].TrySetTrackingOriginMode(TrackingOriginModeFlags.Floor);
        }
    }
    int frames = 0;
    private void Update()
    {
        InputTracking.GetNodeStates(mNodeStates);

        foreach (XRNodeState nodeState in mNodeStates)
        {
            switch (nodeState.nodeType)
            {
                case XRNode.Head:
                    nodeState.TryGetPosition(out mHeadPos);
                    nodeState.TryGetRotation(out mHeadRot);
                    break;
            }
        }
        Head.transform.position = mHeadPos;
        Head.transform.rotation = mHeadRot.normalized;
        Debug.Log(mHeadPos.y);

        //inserting New Pos
        /*float lastY = 0;
        for(int idx=0; idx>YPositions.Length ;idx++)
        {
            if (idx != YPositions.Length + 1)
            {
                lastY = YPositions[idx+1];
                YPositions[idx] = YPositions[idx + 1];
                if(idx==0)
                {
                    YPositions[idx] = mHeadPos.Y;
                }
            }
        }

        //Calcular a média
        float aux = 0;
        for(int idx=0;idx>YPositions.Length; idx++)
        {
            aux+=YPositions[idx];
        }
        Debug.Log(aux/YPositions.Length);
        */
        Debug.Log(YPositions);
        
    }
}
