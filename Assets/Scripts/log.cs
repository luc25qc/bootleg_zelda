using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Rigidbody2D myRigidbody;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkDistance();
    }

    void checkDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                myRigidbody.MovePosition(temp);
                changeAnim(temp - transform.position);
                changeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }

        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    private void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }

    private void changeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

}
