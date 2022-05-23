using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
    }

    // Start is called before the first frame update
    void Start() {
        mPlayerControllerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        int numElems = currentDieInUse.max - currentDieInUse.min;
        attackRollsThisRun = new int[numElems+1];
        graphLabels = new string[numElems+1];
        for (int i = currentDieInUse.min; i < currentDieInUse.max+1; ++i) {
            graphLabels[i - currentDieInUse.min] = i.ToString();
        }
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Stats Screen");
            Screen.SetResolution (Screen.width, Screen.height, Screen.fullScreen);
        }

        if (mPlayerControllerReference.IsPaused) {
            print("Game is paused");
            Time.timeScale = 0;
        }

        
    }



}
