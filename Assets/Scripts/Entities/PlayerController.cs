using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] bool bIsPaused = false;
    [SerializeField] PlayerAttributes mPlayerAttributes;

    public TurnBasedManager turnBasedManagerReference;

    [SerializeField] HealthbarManager hpBar;

    [SerializeField] int mHealth;
    [SerializeField] int mMaxHealth;

    public ParticleSystem hurtParticleSysRef;

    [SerializeField] Dice mCurrentDice;



    // Start is called before the first frame update
    void Start()
    {
        turnBasedManagerReference = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
        hpBar.SetMaxHealth(mMaxHealth);
        print($"Player({mPlayerAttributes.mPlayerClass}) : ({mHealth} / {mMaxHealth}) ");
        /* var list = new List<int>();
        for (int i = 0; i < 10; i++) {
            list.Add(RandomUtils.RollDie(6,3));
        }
        for(int j = 0; j < list.Count; j++) {
            print(list[j]);
        } */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        hurtParticleSysRef.Play();
        mHealth -= damage;
        hpBar.SetHealth(mHealth);
    }
    public bool IsPaused {get => bIsPaused; set => bIsPaused = value; }

    public void OnAttackButtonPressed() {
        if (turnBasedManagerReference.CurrentTurn == Turn.PLAYER_TURN)
        {
            turnBasedManagerReference.NextTurn();
            turnBasedManagerReference.CurrentEnemyReference.TakeDamage(RandomUtils.RollDie(mCurrentDice.numSides,mCurrentDice.numDice));    //hook this up to random generator later
        }
    }

    public void OnStatsButtonPressed() {
        print("Stats button pressed");
        this.bIsPaused = true;
    }
}
