using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyIa3 : MonoBehaviour
{
    private EnemyController enemyController;
    
 
    public float DetectRadius;
    public float attackRadius;
    private Transform target;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", false);

        IaEnemy();
    }

    void IaEnemy()
    {

        if (Vector3.Distance(target.position, transform.position) <= DetectRadius)
        {
            
                animator.SetBool("Walking", true);
                Animation();
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyController.speed * Time.deltaTime);

                if (Vector3.Distance(target.position, transform.position) <= attackRadius)
                {

                    StartCoroutine(knockCo());
                }
                if (Vector3.Distance(target.position, transform.position) > attackRadius)
                {
                    StopCoroutine(knockCo());
                    animator.SetBool("Walking", true);
                    transform.position = Vector2.MoveTowards(transform.position, target.position, enemyController.speed * Time.deltaTime);

                }

            }
        
    }
    private void Animation()
    {
        if (target.position.y < transform.position.y)
        {
           
            animator.SetFloat("Vertical", target.position.y - transform.position.y);
        
        }
        if (target.position.y > transform.position.y)
        {
         
            animator.SetFloat("Vertical", target.position.y - transform.position.y);
      
        }
        if (target.position.x > transform.position.x)
        {
            animator.SetFloat("Horizontal", target.position.x - transform.position.x);
       
        }
        if (target.position.x < transform.position.x)
        {
          
            animator.SetFloat("Horizontal", target.position.x - transform.position.x);
     
        }
    }

    public IEnumerator knockCo() { 

        animator.SetBool("Attacking", true);
        
        yield return new WaitForSeconds(0.5f);
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;     
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, DetectRadius);
    }
}
