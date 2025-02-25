using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Material lavaMaterial;
    public Vector2 speed = new Vector2(0.1f, 0.1f);

    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        lavaMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += speed * Time.deltaTime;

        lavaMaterial.mainTextureOffset = offset;
    }
}
