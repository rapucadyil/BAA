using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnIndicatorTextController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mTextComp;
    public TurnBasedManager turnBasedManagerReference;
    void Start() {
        mTextComp = GetComponent<TextMeshProUGUI>();
        turnBasedManagerReference = GameObject.FindGameObjectWithTag("TurnBasedMgr").GetComponent<TurnBasedManager>();
    }

    void Update() {

        if (turnBasedManagerReference.CurrentTurn == Turn.PLAYER_TURN) {
            mTextComp.text = "Player Turn";
        }else{
            mTextComp.text = "Enemy Turn";
        }

    }

}
