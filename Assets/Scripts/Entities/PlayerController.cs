using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] bool bIsPaused = false;
    [SerializeField] PlayerAttributes mPlayerAttributes;

    public TurnBasedManager turnBasedManagerReference;

    public GameManager gameManagerReference;

    [SerializeField] HealthbarManager hpBar;

    [SerializeField] int mHealth;
    [SerializeField] int mMaxHealth;

    public ParticleSystem hurtParticleSysRef;

    [SerializeField] Dice mCurrentDice;



    // Start is called before the first frame update
    void Start()
    {
        turnBasedManagerReference = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
        gameManagerReference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManagerReference.currentDieInUse = mCurrentDice;
        hpBar.SetMaxHealth(mMaxHealth);

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
    public Dice CurrentDice { get => mCurrentDice; set => mCurrentDice = value; }
    public void OnAttackButtonPressed() {
        if (turnBasedManagerReference.CurrentTurn == Turn.PLAYER_TURN)
        {
            turnBasedManagerReference.NextTurn();
            int dmgRoll = RandomUtils.RollDie(mCurrentDice.numSides,mCurrentDice.numDice);
            print($"Player rolled {dmgRoll}");
            gameManagerReference.attackRollsThisRun[dmgRoll - mCurrentDice.numDice] += 1;
            turnBasedManagerReference.CurrentEnemyReference.TakeDamage(dmgRoll);    
        }
    }

    public void OnStatsButtonPressed() {
        print("Stats button pressed");
        this.bIsPaused = true;
    }
}
