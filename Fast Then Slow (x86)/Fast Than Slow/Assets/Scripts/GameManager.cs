using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CompleteLevelUI;

    public GameObject DIEUI;

    public PlayerMove PlayerMovement;

    public bool LevelComplete = false;

    [SerializeField]
    string NextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("e");
        }

        if (Input.GetKeyDown("r"))
        {
            RestartLevel();
        }

        if (Input.GetKeyDown("q"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        if (Input.GetKeyDown("g"))
        {
            FindObjectOfType<SlowMo>().SPEEEEEDStart();
            Debug.Log("speed request sent");
        }
        if (Input.GetKeyDown("f"))
        {
            FindObjectOfType<SlowMo>().SPEEEEEDStart();
        }
    }

    public void DieUI()
    {
        if (LevelComplete == false)
        {
            PlayerMovement.enabled = false;
            DIEUI.active = true;
            FindObjectOfType<Timer>().StopTimer();
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        FindObjectOfType<EnemyAI>().destoyEnemys();
        LevelComplete = true;
        PlayerMovement.enabled = false;
        CompleteLevelUI.active = true;
        Invoke("NextLevel", 3.5f);
    }

    public void NextLevel()
    {
        LevelComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
