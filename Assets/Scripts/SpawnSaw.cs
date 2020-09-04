using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSaw : MonoBehaviour
{
    public GameObject saw;

    public Transform target;

    void Start()
    {
        StartCoroutine(spawn());
    }

     IEnumerator spawn()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            float x = target.position.x;
            Instantiate(
                saw,
                new Vector3(Random.Range(x-8, x+8), 6, 89),
                Quaternion.Euler(0, 0 , 0)
            );
            yield return new WaitForSeconds(2.0f);
        }
    }
}
