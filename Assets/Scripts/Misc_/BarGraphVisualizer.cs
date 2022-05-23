using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
public class BarGraphVisualizer : MonoBehaviour
{

    public Bar barPrefab;
    public int[] inputValues;

    public string[] labels;

    //@HACK - this is a hack to get the bar graph to work with the player controller system
    public GameManager gameManagerReference;

    List<Bar> bars = new List<Bar>();

    [SerializeField] float chartHeight;

    private void Start() {
        
        gameManagerReference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y;

        Visualize(gameManagerReference.attackRollsThisRun, gameManagerReference.graphLabels);
    }


    private void Visualize(int[] vals, string[] labs) {

        int maxVal = vals.Max();
        for (int i = 0; i < vals.Length; i++) {
            Bar b = Instantiate(barPrefab) as Bar;
            b.transform.SetParent(this.transform);
            RectTransform rt = b.bar.GetComponent<RectTransform>();
            float normalizedValue = ((float)vals[i] / (float)maxVal) * 0.95f;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHeight * normalizedValue);

            /*if (gameManagerReference.currentDieInUse.diceType == "3d6") {
                b.barValue.text = vals[i].ToString();
            }*/

            if (vals[i] != 0) {
                b.barValue.text = vals[i].ToString();
            }
            //@HACK - hardcoding upper/lower bound for now.
            //@TODO - Be sure to change this later.
            int hackedLowerBound = 3;
            int hackedUpperBound = 18;
            //int lowerBound = 1*gameManagerReference.currentDieInUse.numDice;
            //int upperBoundForloop = gameManagerReference.currentDieInUse.numDice * gameManagerReference.currentDieInUse.numSides;
            b.barLabel.text = labs[i];
        }

        
    }

}
