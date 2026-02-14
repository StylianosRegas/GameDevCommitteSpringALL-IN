using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;
    private Health playerHealth;
    private Health enemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<Health>();
            }
            playerHealth.TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            if (enemyHealth == null)
            {
                enemyHealth = collision.gameObject.GetComponent<Health>();
            }
            enemyHealth.TakeDamage(damage);
        }
    }
}
