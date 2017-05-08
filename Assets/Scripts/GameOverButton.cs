using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeToStartScene()
    {
        SnakeMove.scores = 0;
        SceneManager.LoadScene(0);
        
    }
    public void ChangeToGameScene()
    {
        SnakeMove.scores = 0;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
