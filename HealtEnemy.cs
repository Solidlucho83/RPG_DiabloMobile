using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtEnemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
   
    private Animator _animator;
    private bool atacado;
    private bool stopDealDamage;
    public int Experiencia;
    //    public GameObject particulasMuerte;
    //  private SFXSoundManager SFXSoundManager;

    private PlayerControler playerControler;
    public GameObject Energy;
    public GameObject healtBar;

    public string enemyName;
    private QuestManager manager;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        currentHealth = maxHealth;
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        manager = FindObjectOfType<QuestManager>();
    }

    void Update()
    {   

        if (atacado == true)
        {
            if (stopDealDamage == false)
            {
                stopDealDamage = true;
                StartCoroutine(Damage());
            }
        }
        if (currentHealth <= 0)
        {

            //  SFXSoundManager.GameOver.Play();
            //   gameObject.SetActive(false);
            //manager.enemyKilled = enemyName;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().AddExperience(Experiencia);
            Destroy(gameObject);
           
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;     
    }

    public void UpdateMaxHealt(int newMaxHealt)
    {
        maxHealth = newMaxHealt;
        currentHealth = maxHealth;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Energy.SetActive(true);
            atacado = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Energy.SetActive(false);
            atacado = false;
        }

    }
    
    IEnumerator Damage()
    {
        yield return new WaitForSeconds(1);
        currentHealth -= playerControler.damage;
        stopDealDamage = false;
        healtBar.transform.localScale = new Vector3(currentHealth/maxHealth, healtBar.transform.localScale.y, healtBar.transform.localScale.z);
    }
}
