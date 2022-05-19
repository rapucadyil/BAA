using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerClass {
    Warrior,
    Rogue,
    Archer
}

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Player Attributes")]
public class PlayerAttributes : ScriptableObject
{
    public int mStrength;

    public PlayerClass mPlayerClass;
}
