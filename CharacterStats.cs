using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    public int[] hpLevels, damageLevels, defenseLevels;
    private HealtManager healtManager;
    private PlayerControler playerControler;
    void Start()
    {
        healtManager = GetComponent<HealtManager>();
        playerControler = GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel >= expToLevelUp.Length)
        {
            return;
        }
        if(currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            healtManager.UpdateMaxHealt(hpLevels[currentLevel]);
            healtManager.UpdateMaxDefense(defenseLevels[currentLevel]);
            playerControler.UpdateDamage(damageLevels[currentLevel]);

        }
    }
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
