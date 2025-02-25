using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    public GameObject prefab;
    public bool isActivate;
    private Coroutine spawnCoroutine;

    void Update()
    {
        if (isActivate && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnRoutine());
        }
        else if (!isActivate && spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

    }

    public void Activate()
    {
        isActivate = true;
    }
    public void Desactivate()
    {
        isActivate = false;
    }
    IEnumerator SpawnRoutine()
    {
        while (isActivate)
        {
            float tiempoEspera = Random.Range(3f, 6f);
            yield return new WaitForSeconds(tiempoEspera);
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
        spawnCoroutine = null;
    }
}
