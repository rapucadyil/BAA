using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn {
    PLAYER_TURN,
    ENEMY_TURN,
}

public class TurnBasedManager : MonoBehaviour {

    [SerializeField] Turn mCurrentTurn;

    private void Start() {
        mCurrentTurn = Turn.PLAYER_TURN;
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
        
        switch(mCurrentTurn) {
            case Turn.PLAYER_TURN:
                break;
            case Turn.ENEMY_TURN:
                break;
        }

    }

    public Turn CurrentTurn { get => mCurrentTurn; }
}