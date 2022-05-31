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

    public string playerType;

    public Vector3 playerSpawnPosition;
    public Vector3 enemySpawnPosition;

    public GameObject roguePrefab;
    public GameObject warriorPrefab;

    public GameObject lightEnemyPrefab;
    public GameObject medEnemyPrefab;
    public GameObject heavyEnemyPrefab;

    public Dice currentDieInUse;
    public int[] attackRollsThisRun;
    public string[] graphLabels;

    public bool gameLoaded = false;

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
        if (gameLoaded) {
            if (mPlayerControllerReference.CurrentHealth <= 0) {
                SceneManager.LoadScene("Stats Screen");
            }
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        print($"Scene name = {scene.name}");
        if (SceneManager.GetActiveScene().name == "SampleScene") {
            if (playerType == "Rogue") {
                Instantiate(roguePrefab, playerSpawnPosition, Quaternion.identity);
            } else if (playerType == "Warrior") {
                Instantiate(warriorPrefab, playerSpawnPosition, Quaternion.identity);
            }
            mPlayerControllerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            print($"Current Scene = {SceneManager.GetActiveScene().name}");
            currentDieInUse = mPlayerControllerReference.CurrentDice;
            int numElems = currentDieInUse.max - currentDieInUse.min;
            attackRollsThisRun = new int[numElems+1];
            graphLabels = new string[numElems+1];
            for (int i = currentDieInUse.min; i < currentDieInUse.max+1; ++i) {
                graphLabels[i - currentDieInUse.min] = i.ToString();
            }
            gameLoaded = true;
        }
    }


    public void OnPlayButtonPressed() {
        SceneManager.LoadScene("Character Select");
    }

    public void OnQuitButtonPressed() {
        Application.Quit();
    }


}
