using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{

    public GameManager gameManagerReference;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerReference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnRogueButtonPressed() {
        gameManagerReference.playerType = "Rogue";
        SceneManager.LoadScene("SampleScene");
    }

    public void OnWarriorButtonPressed() {
        gameManagerReference.playerType = "Warrior";
        SceneManager.LoadScene("SampleScene");
    }
}
