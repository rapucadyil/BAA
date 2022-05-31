using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn {
    PLAYER_TURN,
    ENEMY_TURN,
}

public class TurnBasedManager : MonoBehaviour {

    [SerializeField] Turn mCurrentTurn;

    [SerializeField] PlayerController mPlayerReference;

    [SerializeField] EnemyController mCurrentEnemyReference;

    [SerializeField] GameObject[] mAvailableEnemies;

    public int currentEnemyIndex;

    private void Start() {
        mPlayerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mCurrentTurn = Turn.PLAYER_TURN;
        currentEnemyIndex = 0;
    }

    /**
    Publicly exposed function to allow switching turns from outside of this class.

    @param: None
    @return: void
     */
    public void NextTurn() {
        if (mCurrentTurn == Turn.PLAYER_TURN) {
            mCurrentTurn = Turn.ENEMY_TURN;
        }
        else {
            mCurrentTurn = Turn.PLAYER_TURN;
        }
    }

    private void Update() {
        if (mCurrentEnemyReference == null) {
            mCurrentEnemyReference = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        }
        
        if (mCurrentEnemyReference.CurrentHealth <= 0) {
            if (currentEnemyIndex >= mAvailableEnemies.Length) {
                currentEnemyIndex = 0;
            }
            currentEnemyIndex++;
            GameObject new_enemy = mAvailableEnemies[currentEnemyIndex];
            Instantiate(new_enemy, mCurrentEnemyReference.transform.position, Quaternion.identity);
            DestroyImmediate(mCurrentEnemyReference.gameObject, true);
            mCurrentEnemyReference = GameObject.Find(new_enemy.name + "(Clone)").GetComponent<EnemyController>();
        }

    }

    public Turn CurrentTurn { get => mCurrentTurn; }

    public PlayerController PlayerReference {get => mPlayerReference;}

    public EnemyController CurrentEnemyReference {get => mCurrentEnemyReference;}
}
