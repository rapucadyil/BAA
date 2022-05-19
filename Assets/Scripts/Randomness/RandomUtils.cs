using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class RandomUtils
{
    
    public static int RollDie (int numSides, int numDice) {
        var rand = new System.Random();
        var sum = 0;
        var rollResuts = new List<int>();
        for (int i = 0; i < numDice; ++i ) {
            var roll =  rand.Next(0, numSides) + 1;
            rollResuts.Add(roll);
        }

        for (int j = 0; j < rollResuts.Count; ++j) {
            sum += rollResuts[j];
        }
        return sum;
    }


}
