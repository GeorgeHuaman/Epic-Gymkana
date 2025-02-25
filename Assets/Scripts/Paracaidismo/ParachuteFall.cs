using SpatialSys.UnitySDK;
using SpatialSys.UnitySDK.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteFall : MonoBehaviour
{
    public GameObject parachute;

    private float earthGravity = -9.81f;
    private float moonGravity = -0.5f;
    private bool parachuteBool = false;
    private bool impulseEnable = true;
    private float timer;
    private Vector3 velocity;

    private void Start()
    {
        var localAvatar = SpatialBridge.actorService.localActor.avatar;
        localAvatar.maxJumpCount = 0;
    }

    private void Update()
    {
        var localAvatar = SpatialBridge.actorService.localActor.avatar;

        parachute.transform.position = localAvatar.position;
        parachute.transform.rotation = localAvatar.rotation;

        parachute.SetActive(parachuteBool);

        if (!impulseEnable)
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                impulseEnable = true;
                timer = 0f;
            }
        }

        velocity.y = Mathf.Abs(SpatialBridge.actorService.localActor.avatar.velocity.y) + 0.5f;


    }

    public void OpenParachute()
    {
        parachuteBool = true;
        Physics.gravity = new Vector3(0, moonGravity, 0);
        if (impulseEnable)
        {
            SpatialBridge.actorService.localActor.avatar.AddForce(new Vector3(0f, velocity.y));
            impulseEnable = false;
        }
        
    }

    public void CloseParachute()
    {
        parachuteBool = false;
        Physics.gravity = new Vector3(0, earthGravity, 0);
    }



}
