using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dice", menuName = "BAA/Dice")]
public class Dice : ScriptableObject {
    
    public string diceType;

    public int min;

    public int max;

    public int numDice;
    public int numSides;
}

