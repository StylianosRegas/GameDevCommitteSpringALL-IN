using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAtk;
    public float startTimeBetweenAtk;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;
    private Health enemyHealth;
    public Animator anim;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenAtk <= 0)
        {
            //then attack
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(animTimer(0.5f));
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                }

                timeBetweenAtk = startTimeBetweenAtk;
                

            }
            
        }
        else
        {
            timeBetweenAtk -= Time.deltaTime;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public IEnumerator animTimer(float activeTime)
    {
        anim.SetBool(IsAttacking, true);
        yield return new WaitForSeconds(activeTime);
        anim.SetBool(IsAttacking, false);
    }
}
