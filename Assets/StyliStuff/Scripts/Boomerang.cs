using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public int direction = 1;
    public float rotationalSpeed = 360f;
    public float moveSpeed = 8f;
    public float distance = 5f;
    public float hoverDuration = 2f;

    private void Start()
    {
        StartCoroutine(BoomerangRoutine());
    }

    private void Update()
    {
        // Rotation runs every frame regardless of phase
        transform.Rotate(Vector3.forward * rotationalSpeed * Time.deltaTime);
    }

    private IEnumerator BoomerangRoutine()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (new Vector3(distance, 0, 0)*direction);

        // --- Phase 1: Throw outward ---
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos; // snap exactly

        // --- Phase 2: Hover in place ---
        yield return new WaitForSeconds(hoverDuration);

        // --- Phase 3: Return ---
        while (Vector3.Distance(transform.position, startPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, startPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // --- Done: destroy ---
        Debug.Log("Boomerang destroyed");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}