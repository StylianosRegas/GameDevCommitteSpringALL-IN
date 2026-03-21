using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 3f;
    public float launchForce = 15f;
    public float launchAngle = 45f;   // degrees above horizontal

    private void Start()
    {
        // Schedule destruction — no coroutine needed
        Destroy(gameObject, lifetime);

        // Build the launch direction from angle
        float rad = launchAngle * Mathf.Deg2Rad;
        Vector3 launchDir = new Vector3(
            Mathf.Cos(rad),   // forward
            Mathf.Sin(rad),   // upward
            0f
        );

        GetComponent<Rigidbody>().AddForce(launchDir * launchForce, ForceMode.Impulse);
    }
}