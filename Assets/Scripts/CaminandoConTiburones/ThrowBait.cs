using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBait : MonoBehaviour
{
    public GameObject shark;
    public Transform point;
    public float speed = 5f;
    private bool isMoving;
    private void Update()
    {
        if (Vector3.Distance(shark.transform.position, point.position) < 0.1f)
        {
            isMoving = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
        if (isMoving)
        {
            shark.transform.position = Vector3.MoveTowards(shark.transform.position, point.position, speed * Time.deltaTime);
        }
    }
    public void Throw()
    {
        isMoving = true;
    }
}
