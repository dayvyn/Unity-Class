using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    [SerializeField] string charName;
    [Range(-5, 5)]
    [SerializeField] int dexMod;
    [Range(-5, 5)]
    [SerializeField] int strMod;
    [Range(0, 5)]
    [SerializeField] int profBonus;
    [SerializeField] bool finesseWeapon;
    char mod1;
    char mod2;
    int toHit;
    int hitModS;
    int hitModD;
    int enemyAC;
    string[] hitMessages = {" attack lands with a large clash!", " attack sends your opponent flying!", " attack pierces their defenses!"};
    string[] missMessages = { " attack bounces off their armor!", " attack is sidestepped!", " attack is blocked!" };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press space or 'W' to execute the code.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.W))
        {
            DiceRoller();
        }
    }

    [ContextMenu("Roll the Die")]
    void DiceRoller()
    {
        int diceRoll = Random.Range(0,21);
        hitModS = strMod + profBonus;
        hitModD = dexMod + profBonus;
        mod1 = (strMod >= 0) ? '+' : ' ';
        mod2 = (dexMod >= 0) ? '+' : ' ';
        if (finesseWeapon == true)
        {
            if (strMod > dexMod)
            {
                hitModS = strMod + profBonus;
                toHit = diceRoll + hitModS;
                Debug.Log(charName.Trim() + "'s to hit is: " + diceRoll + " + "+ mod1 + hitModS + " = " + toHit);
            }
            else
            {
                hitModD = dexMod + profBonus;
                toHit = diceRoll + hitModD;
                Debug.Log(charName.Trim() + "'s to hit is: " + diceRoll + " + " + mod2 + hitModD + " = " + toHit);
            }
        }
        else
        {
            hitModS = strMod + profBonus;
            toHit = diceRoll + hitModS;
            Debug.Log(charName.Trim() + "'s to hit is: " + diceRoll + " + " + mod1 + hitModS + " = " + toHit);
        }
        EnemyAttack(toHit);
    }

    void EnemyAttack(int toHit)
    {
        enemyAC = Random.Range(10, 21);
        Debug.Log("The enemies AC is: " + enemyAC);
        if (toHit >= enemyAC)
        {
            Debug.Log(charName.Trim()+ "'s" + hitMessages[Random.Range(0, 3)]);
        }
        else
        {
            Debug.Log(charName.Trim() + "'s" + missMessages[Random.Range(0, 3)]);
        }
    }
}
