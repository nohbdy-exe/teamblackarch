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
    [SerializeField] private AudioClip bossAttackAudio;
    [SerializeField] private AudioClip bossHealAudio;
    [SerializeField] private AudioClip bossDeathAudio;
    [SerializeField] private AudioSource bossAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        bossHP = bossMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void bossAttackSFX()
    {
        bossAudioSource.clip = bossAttackAudio;
        bossAudioSource.volume = 100;
        bossAudioSource.Play();
    }
    public void bossDeathSFX()
    {
        bossAudioSource.clip = bossDeathAudio;
        bossAudioSource.Play();
    }
    public void bossHealSFX()
    {
        bossAudioSource.clip = bossHealAudio;
        bossAudioSource.Play();
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
        if (bossHP < bossMaxHP -150)
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
