using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TarodevController;

public class destroyableObject : MonoBehaviour
{
    public float destroyTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(destroy(destroyTime));
    }

    public IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
   
}
