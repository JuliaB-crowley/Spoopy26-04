using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class JUB_EnnemyDamage : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth, deathAnimationTime;

    public float knockbackForce, knockbackDuration;
    public Transform playerTransform;
    public Rigidbody2D rb;
    public AIPath AIPath;

    public bool hasLoot;
    public List<GameObject> possibleLoots;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        AIPath = GetComponent<AIPath>();
    }

    // Update is called once per frame

    public void TakeDamage(float damage)
    {
        //animation dégats
        Knockback();
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //animation mort
        //son mort
        if(hasLoot)
        {
            int index = Random.Range(0, possibleLoots.Count - 1);
            Instantiate(possibleLoots[index], transform.position, Quaternion.identity);
        }
        StartCoroutine("DeathCoroutine");
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(deathAnimationTime);
        Destroy(gameObject);
    }

    void Knockback()
    {
        AIPath.canMove = false;
        Vector2 direction = (playerTransform.position - this.transform.position).normalized;
        rb.velocity = (-direction * knockbackForce);
        StartCoroutine(KnockbackCoroutine());
    }
    IEnumerator KnockbackCoroutine()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector2.zero;
        AIPath.canMove = true;
        Debug.LogWarning("knockback was performed");
    }
}
