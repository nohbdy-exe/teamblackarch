using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleUIScript : MonoBehaviour
{
    [SerializeField] private DamageScript damageScript;
    
    public void playerPhysicalAttack()
    {
        damageScript.PlayerPhysicalAttack();
    }
    public void playerMagicAttack()
    {
        damageScript.PlayerMagicAttack();
    }
    public void playerSelfHeal()
    {
        damageScript.PlayerHeal();
    }
    public void playerRechargeMP()
    {
        damageScript.RechargeMana();
    }
}
