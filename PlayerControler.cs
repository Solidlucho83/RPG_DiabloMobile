using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{

    public float speed = 4.0f;
    public bool walking = false;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private Vector2 targetPosition;
    public bool attacking = false ;
    public int MaxDamage;
    public int damage;
    
    public bool playerTalking;
    private SFXManager sFXManager;
    private Inventory inventory;

    private CameraFollow CameraFollow;
   

    void Start()
    {        
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sFXManager = FindObjectOfType<SFXManager>();
        CameraFollow = FindObjectOfType<CameraFollow>();
        damage = MaxDamage;
    }

    void Update()
    {
       
        walking = false;
        Movimiento();
        Animation();
        animator.SetBool("Walking", walking);

        if (playerTalking)
        {
            animator.SetBool("Walking", false);            
            return;
        }
       
    }

  
    private void Movimiento()
    {
        if (playerTalking)
        {
            playerRigidbody.velocity = Vector2.zero;
            return;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

         if (Input.GetMouseButton(0))
         {
            if ((transform.position.y - mousePos.y) < 4.5f)
            {
                targetPosition = new Vector2(mousePos.x, mousePos.y);
                attacking = false;                
            }
         }
         transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

         Vector2 velocity = transform.position * speed * Time.deltaTime;
        

    }
    private void Animation()
    {
        if (targetPosition.y < transform.position.y)
        {
            walking = true;
            animator.SetFloat("Vertical", targetPosition.y - transform.position.y);
            animator.SetFloat("LastVertical", targetPosition.y - transform.position.y);
        }
        if (targetPosition.y > transform.position.y)
        {
            walking = true;
            animator.SetFloat("Vertical", targetPosition.y - transform.position.y);
            animator.SetFloat("LastVertical", targetPosition.y - transform.position.y);
        }
        if (targetPosition.x > transform.position.x)
        {
            walking = true;
            animator.SetFloat("Horizontal", targetPosition.x - transform.position.x);
            animator.SetFloat("LastHorizontal", targetPosition.x - transform.position.x);
        }
        if (targetPosition.x < transform.position.x)
        {
            walking = true;
            animator.SetFloat("Horizontal", targetPosition.x - transform.position.x);
            animator.SetFloat("LastHorizontal", targetPosition.x - transform.position.x);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {                       
                attacking = true;
                animator.SetBool("Attacking", true);
                sFXManager.battle.Play();            
                playerRigidbody.velocity = Vector2.zero;
             
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {       
                attacking = false;
                animator.SetBool("Attacking", false);
                sFXManager.battle.Stop();
        }
    }
    

    public void UpdateDamage(int newMaxDamage)
    {
        MaxDamage = newMaxDamage;
        damage = MaxDamage;

    }

    public void ReturnTeleport()
    {
        //CameraFollow.enabled = !CameraFollow.enabled;
        targetPosition = new Vector2(0f, 0f);
        gameObject.transform.position = new Vector3(targetPosition.x, targetPosition.y);
        playerRigidbody.velocity = Vector2.zero;
        
    }
    public void ChangueLevels()
    {

        targetPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        playerRigidbody.velocity = Vector2.zero;
    }
}
