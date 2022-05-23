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


    List<Bar> bars = new List<Bar>();

    [SerializeField] float chartHeight;

    private void Start() {

        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y;

        Visualize(inputValues);
    }


    private void Visualize(int[] vals) {

        int maxVal = vals.Max();

        for (int i = 0; i < vals.Length; i++) {
            Bar b = Instantiate(barPrefab) as Bar;
            b.transform.SetParent(this.transform);
            RectTransform rt = b.bar.GetComponent<RectTransform>();
            float normalizedValue = ((float)vals[i] / (float)maxVal) * 0.95f;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHeight * normalizedValue);
            b.barValue.text = vals[i].ToString();
            if (labels.Length == vals.Length) {
                b.barLabel.text = labels[i];
            }else{
                b.barLabel.text = "UNDEFINED";
            }
        }
    }

}
