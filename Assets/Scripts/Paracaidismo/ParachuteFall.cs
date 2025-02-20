using SpatialSys.UnitySDK;
using SpatialSys.UnitySDK.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteFall : MonoBehaviour
{

    private float earthGravity = -9.81f;
    private float moonGravity = -0.5f;
    private bool parachuteBool = false;

    private Vector3 velocity;

    private void Start()
    {
        var localAvatar = SpatialBridge.actorService.localActor.avatar;
        localAvatar.maxJumpCount = 0;
    }

    private void Update()
    {
        
        
    }

    public void OpenParachute()
    {
        parachuteBool = true;
        Physics.gravity = new Vector3(0, moonGravity, 0);
        var localAvatar = SpatialBridge.actorService.localActor.avatar;
    }

    public void CloseParachute()
    {
        parachuteBool = false;
        Physics.gravity = new Vector3(0, earthGravity, 0);
        var localAvatar = SpatialBridge.actorService.localActor.avatar;
    }



}
