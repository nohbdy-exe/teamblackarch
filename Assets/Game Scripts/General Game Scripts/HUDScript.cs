using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HUDScript : MonoBehaviour
{
    public PlayerData playerdata;
    [Header("Player HUD Info:")]
    [SerializeField] public GameObject PlayerLevelHUD;
    [SerializeField] public GameObject PlayerSkillPointsHUD;
    [SerializeField] public Scrollbar PlayerHealthHUD;
    //[SerializeField] public GameObject PlayerHpHUD;
    [SerializeField] public Scrollbar PlayerManaHUD;
    [SerializeField] public Scrollbar PlayerExpHUD;
    [SerializeField] public TextMeshProUGUI playerHealthText;
    [SerializeField] public TextMeshProUGUI playerManaText;
    [SerializeField] public TextMeshProUGUI playerExpText;
    [SerializeField] public TextMeshProUGUI playerLevelText;
    [SerializeField] public TextMeshProUGUI playerSkillPointsText;
    

    public void UpdateHUDInfo()
    {
        playerHealthText.text = (playerdata.playerHealth + " / " + playerdata.playerMaxHealth);
        playerManaText.text = (playerdata.playerMana + " / " + playerdata.playerMaxMana);
        playerExpText.text = ("XP: " + playerdata.playerExp + " / " + playerdata.playerExpMax);
        playerLevelText.text = (": " + playerdata.playerLevel);
        playerSkillPointsText.text = (": " + playerdata.playerSP);

        //Move Player HP Bar
        if (playerdata.playerHealth > 0)
        {
            PlayerHealthHUD.size = playerdata.playerHealth / playerdata.playerMaxHealth;
        }
        else
        {
            PlayerHealthHUD.size = playerdata.playerHealth / playerdata.playerMaxHealth;

            //Implement dying system and dying UI for this
        }

        //Move Player MP Bar
        if (playerdata.playerHealth > 0)
        {
            PlayerManaHUD.size = playerdata.playerMana / playerdata.playerMaxMana;
        }
        else
        {
            PlayerManaHUD.size = playerdata.playerMana / playerdata.playerMaxMana;

            //Implement empty MP system and empty MP UI for this
        }

        //Move Player XP Bar
        if (playerdata.playerHealth > 0)
        {
            PlayerExpHUD.size = playerdata.playerExp / playerdata.playerExpMax;
        }
        else
        {
            PlayerExpHUD.size = playerdata.playerExp / playerdata.playerExpMax;

            //Implement empty MP system and empty MP UI for this
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUDInfo();
    }
}
