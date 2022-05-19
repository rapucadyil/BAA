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


    // Start is called before the first frame update
    void Start()
    {
        turnBasedManagerReference = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
        hpBar.SetMaxHealth(mMaxHealth);
        print($"Player({mPlayerAttributes.mPlayerClass}) : ({mHealth} / {mMaxHealth}) ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
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
        }
        else
        {
        }
    }

    public void OnStatsButtonPressed() {
        print("Stats button pressed");
        this.bIsPaused = true;
    }
}
