using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBait : MonoBehaviour
{
    public GameObject shark;
    public Transform point;
    public float speed = 5f;
    public float rotationSpeed = 5f;
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
        Vector3 direction = (point.position - shark.transform.position).normalized;
        if (isMoving)
        {
            shark.transform.position = Vector3.MoveTowards(shark.transform.position, point.position, speed * Time.deltaTime);
            if (direction != Vector3.zero) // Evita errores cuando ya está en la posición exacta
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                shark.transform.rotation = Quaternion.Slerp(shark.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    public void Throw()
    {
        isMoving = true;
    }
}
