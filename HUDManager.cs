using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class HUDManager : MonoBehaviour
{
    public Slider playerHealtBar;
    public Text playerHealtText;
    public Text levelText;
    public Text expText;
    public Text damageText;
    public Text defenseText;

    private HealtManager healtManager;
    private PlayerControler playerControler;
    private CharacterStats characterStats;

    private void Start()
    {
        healtManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtManager>();
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    void Update()
    {
        playerHealtBar.maxValue = healtManager.maxHealth;
        playerHealtBar.value = healtManager.currentHealth;
        
        

         StringBuilder sb = new StringBuilder("HP: ");
         sb.Append(healtManager.currentHealth);
         sb.Append("/");
         sb.Append(healtManager.maxHealth);
         playerHealtText.text = sb.ToString();

      
        StringBuilder lv = new StringBuilder("LEVEL: ");
        lv.Append(characterStats.currentLevel);
        levelText.text = lv.ToString();

        StringBuilder exp = new StringBuilder("EXP: ");
        exp.Append(characterStats.currentExp);
        expText.text = exp.ToString();
        
        StringBuilder da = new StringBuilder("DAMAGE: ");
        da.Append(playerControler.damage);
        damageText.text = da.ToString();

        StringBuilder df = new StringBuilder("DEFENSE: ");
        df.Append(healtManager.defense);
        defenseText.text = df.ToString();
    }
}
