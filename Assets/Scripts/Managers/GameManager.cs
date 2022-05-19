using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<string> mSceneNames;

    [SerializeField] string mCurrentSceneName;

    PlayerController mPlayerControllerReference;
    private void Awake() {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start() {
        mPlayerControllerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

        if (mPlayerControllerReference.IsPaused) {
            print("Game is paused");
            Time.timeScale = 0;
        }

        
    }
}
