using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.UIElements;

public class GameController : MonoBehaviour {

    public bool showStartCanvas;
    public GameObject startCanvas;
    public GameObject deadCanvas;
    public GameObject endLevelCanvas;
    public Text textRestart;
    public Text textNextLevel;
    public float timeToRestart = 2;
    private float timer;
    private bool playerDead = false;
    private bool hasFinished = false;
    private void Start()
    {
        startCanvas.SetActive(showStartCanvas);
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.002f;
    }
    public void EndLevel()
    {        
        endLevelCanvas.SetActive(true);
        hasFinished = true;
    }
    public void PlayerDied()
    {
        deadCanvas.SetActive(true);
        playerDead = true;
    }
    private void Update()
    {
        if (playerDead)
        {
            timer += Time.deltaTime;
            textRestart.text = "Restarting in : " + (timeToRestart - timer).ToString("F2") + "!";
            if (timer >= timeToRestart)
            {                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }
        }
        if (hasFinished)
        {
            timer += Time.deltaTime;
            textNextLevel.text = "Next level in : " + (timeToRestart - timer).ToString("F2") + "!";
            if (timer >= timeToRestart)
            {
                int next = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(next, LoadSceneMode.Single);
            }
        }
    }
    public void StartLevel()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        startCanvas.SetActive(false);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
