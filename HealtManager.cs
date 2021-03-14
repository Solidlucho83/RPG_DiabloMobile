using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int MaxDefense = 1;
    public int defense;
   
      
    private PlayerControler _controler;
    private Animator _animator;
    private SpriteRenderer characterRenderer;

    // public GameObject particulasMuerte;
    //  private SFXSoundManager SFXSoundManager;
    //  public AudioSource _pasos;

    private void Awake()
    {

      //  _pasos = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _controler = GetComponent<PlayerControler>();       
    }


    void Start()
    {
       
        currentHealth = maxHealth;
        defense = MaxDefense;
     //   SFXSoundManager = FindObjectOfType<SFXSoundManager>();

    }

    void Update()
    {               
        if (currentHealth <= 0)
        {

       //     SFXSoundManager.GameOver.Play();
            gameObject.SetActive(false);
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
    public void UpdateMaxDefense(int newMaxDefense)
    {
        MaxDefense = newMaxDefense;
        defense = MaxDefense;

    }

}
