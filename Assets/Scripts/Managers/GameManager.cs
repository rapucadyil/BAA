using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    [SerializeField] List<string> mSceneNames;

    [SerializeField] string mCurrentSceneName;

    PlayerController mPlayerControllerReference;

    public Dice currentDieInUse;
    public int[] attackRollsThisRun;
    public string[] graphLabels;

    private void Awake() {
        DontDestroyOnLoad(this);
        print("GameManager awake");
    }

    // Start is called before the first frame update
    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Stats Screen");
            Screen.SetResolution (Screen.width, Screen.height, Screen.fullScreen);
        }
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        print($"Scene name = {scene.name}");
        if (SceneManager.GetActiveScene().name == "SampleScene") {
            mPlayerControllerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            print($"Current Scene = {SceneManager.GetActiveScene().name}");
            currentDieInUse = mPlayerControllerReference.CurrentDice;
            int numElems = currentDieInUse.max - currentDieInUse.min;
            attackRollsThisRun = new int[numElems+1];
            graphLabels = new string[numElems+1];
            for (int i = currentDieInUse.min; i < currentDieInUse.max+1; ++i) {
                graphLabels[i - currentDieInUse.min] = i.ToString();
            }
        }
    }


    public void OnPlayButtonPressed() {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButtonPressed() {
        Application.Quit();
    }

}
