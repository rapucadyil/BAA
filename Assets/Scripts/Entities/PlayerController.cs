using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    bool loaded = false;
    [SerializeField] Dice mCurrentDice;

    [SerializeField] Button attackButton;

    public TextMeshProUGUI rollIndicator;

    IEnumerator WaitToLoadCoroutine() {
        print("Starting Load Coroutine");
        loaded = true;
        yield return new WaitForSecondsRealtime(1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonPressed);
        rollIndicator = GameObject.FindGameObjectWithTag("RollIndicator").GetComponent<TextMeshProUGUI>();
        //StartCoroutine(WaitToLoadCoroutine());
        turnBasedManagerReference = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
        gameManagerReference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hpBar = GameObject.FindGameObjectWithTag("PlayerHPBar").GetComponent<HealthbarManager>();
//        gameManagerReference.currentDieInUse = mCurrentDice;
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

    public int CurrentHealth { get => mHealth; set => mHealth = value; } 
    public void OnAttackButtonPressed() {
        if (turnBasedManagerReference.CurrentTurn == Turn.PLAYER_TURN)
        {
            turnBasedManagerReference.NextTurn();
            int dmgRoll = RandomUtils.RollDie(mCurrentDice.numSides,mCurrentDice.numDice);
            print($"Player rolled {dmgRoll}");
            rollIndicator.text = $"You rolled a : {dmgRoll}";
            gameManagerReference.attackRollsThisRun[dmgRoll - mCurrentDice.numDice] += 1;
            turnBasedManagerReference.CurrentEnemyReference.TakeDamage(dmgRoll);    
        }
    }
}
