using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TheFallenData : MonoBehaviour
{
    public float bossHP;
    public float bossMaxHP = 350;
    public bool bossDeath = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bossHP = bossMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void UpdateBossHPfromDamage(float incomingDamage)
    {
        if (incomingDamage != 0)
        {
            //Check to see if boss can sustain hit
            if (bossHP > incomingDamage)
            {
                bossHP -= incomingDamage;
                bossDeath = false;
            }
            if (bossHP <= incomingDamage)
            {
                bossHP = 0;
                bossDeath = true;
            }
        }
    }
    public void UpdateBossHPfromHeal(float incomingHeal)
    {
        if (bossHP != bossMaxHP)
        {
            if (incomingHeal != 0)
            {
                if (incomingHeal + bossHP > bossMaxHP)
                {
                    bossHP = bossMaxHP;
                }
                if (incomingHeal + bossHP <= bossMaxHP)
                {
                    bossHP += incomingHeal;
                }
            }
        }
        else
        {
            Debug.Log("Boss is at max health");
        }
    }

    
    public int rndSelection()
    {
        int rndSelection = 0;
        if (bossHP < bossMaxHP)
        {
            rndSelection = Random.Range(1, 4);
        }
        else
        {
            rndSelection = Random.Range(1, 3);
        }
        
        return rndSelection;
    }


}
