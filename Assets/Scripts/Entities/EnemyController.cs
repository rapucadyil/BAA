using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] int mHealth;
    [SerializeField] int mMaxHealth;

    [SerializeField] int mStrength;
    [SerializeField] int mAgility;  // Maybe used later.

    public TurnBasedManager turnBasedReferenceMgr;

    public HealthbarManager healthbarReferenceMgr;

    public ParticleSystem hurtParticleSysRef;


    [SerializeField] private float countdown = 0;
    [SerializeField] private float coolDown = 5000;
    [SerializeField] private bool canAttack = true;

    public int CurrentHealth { get => mHealth; set => mHealth = value; }


    void Start() {
        turnBasedReferenceMgr = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
        healthbarReferenceMgr = GameObject.FindGameObjectWithTag("EnemyHPBar").GetComponent<HealthbarManager>();
        healthbarReferenceMgr.SetMaxHealth(mMaxHealth);
        mStrength = 5;
        mAgility = 4;
    }


    public void TakeDamage(int damage)
    {
        hurtParticleSysRef.Play();
        mHealth -= damage;
        if (healthbarReferenceMgr != null) {
            healthbarReferenceMgr.SetHealth(mHealth);
        }else{
            healthbarReferenceMgr = GameObject.FindGameObjectWithTag("EnemyHPBar").GetComponent<HealthbarManager>();
            healthbarReferenceMgr.SetHealth(mHealth);
        }
    }


    void Update() {

        if (Input.GetKeyDown(KeyCode.X)) {
            TakeDamage(10);
        }

        if (turnBasedReferenceMgr.CurrentTurn == Turn.ENEMY_TURN)
        {
            if (!canAttack)
            {
                int current = DateTime.Now.Millisecond;
                countdown++;
                if (countdown + current > coolDown)
                {
                    countdown = 0;
                    canAttack = true;
                    turnBasedReferenceMgr.PlayerReference.TakeDamage(RandomUtils.RollDie(12, 2));
                }
            }
            else
            {
                turnBasedReferenceMgr.NextTurn();
                canAttack = false;
                //print("attacked!");
            }
        }

    }

}
