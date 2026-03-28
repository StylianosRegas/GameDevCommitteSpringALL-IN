using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbit : MonoBehaviour
{
    public Transform player;
    public float radius = 1.5f;
    public float speed = 2f;

    private float angle;
    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = player.position + new Vector3(x, y, 0);
    }
}
