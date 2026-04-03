using UnityEngine;

public class MoneyAttack : MonoBehaviour
{
    public float lifetime = 3f;
    public float launchForce = 150f;
    public float launchAngle = 45f;
    public int direction = 1;
    // degrees above horizontal

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

       


        // Build the launch direction from angle
        float rad = launchAngle * Mathf.Deg2Rad;
        
       
        rb.AddForceX(Mathf.Cos(rad) * launchForce*direction, ForceMode2D.Impulse);
        rb.AddForceY(Mathf.Sin(rad)*launchForce, ForceMode2D.Impulse);

        Debug.Log("launched!");
        Destroy(gameObject, lifetime);
    }
}