using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public float health;
    public FloatValue maxHealth;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        takeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

}
