using UnityEngine;

public class enemyPatrol : MonoBehaviour
{

    public GameObject pointA; 
    public GameObject pointB; 
    public Rigidbody2D rb; 
    public Animator anim;
    public Transform currentPoint; 
    public float speed; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform; 
        anim.SetBool("isRunning", true); 
    }

    // Update is called once per frame
    void FixedUpdate()
{
    Vector2 direction = (currentPoint.position - transform.position).normalized;
    rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

    if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
    {
        flip();
        currentPoint = currentPoint == pointA.transform ? pointB.transform : pointA.transform;
    }
}

    public void flip() 
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; 
    }

    public void OnDrawGizmos () 
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position); 
    }
}
