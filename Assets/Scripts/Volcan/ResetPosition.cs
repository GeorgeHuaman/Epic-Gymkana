using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Animator animator;
    public Transform initialPos;


    public void ResetPos()
    {
        SpatialBridge.actorService.localActor.avatar.position = initialPos.position;
        animator.SetBool("LavaMoving", true);
    }
}
