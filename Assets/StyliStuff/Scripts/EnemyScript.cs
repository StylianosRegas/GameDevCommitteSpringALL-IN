using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private bool goingA = true;
    private bool goingB = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingA)
        {
            transform.position = Vector3.MoveTowards(
              transform.position,
              new Vector3(pointA.position.x,transform.position.y, transform.position.z),
              speed * Time.deltaTime
          );

            Debug.Log("imma going");
        }

        else if (goingB)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(pointB.position.x, transform.position.y, transform.position.z),
                speed * Time.deltaTime
          );
        }

        if (transform.position.x == pointA.position.x)
        {
            goingA = false;
            goingB = true;
            
            
        }

        if (transform.position.x == pointB.position.x)
        {
            goingA = true;
            goingB = false;
        }
    }
}
