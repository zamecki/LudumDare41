using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelListController : MonoBehaviour {


    public GameObject list;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void OpenList() {
        list.SetActive(true);
    }
    public void CloseList()
    {
        list.SetActive(false);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
