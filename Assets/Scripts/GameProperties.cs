using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProperties : MonoBehaviour {

	public static float Speed;
	public static int PlayerHealth;
	public static int PlayerScore;
	GameObject[] gameOverButtons;
	public Button restartButton;
	public Button quitButton;
	public GUIText finalScore;

	void Start() 
	{
		Time.timeScale = 1;
		Speed = 3f;

		PlayerHealth = 3;
		PlayerScore = 0;
		
		gameOverButtons = GameObject.FindGameObjectsWithTag("GameOver");
		hideGameOver();
	}

	void Update()
	{
		Speed += Time.deltaTime * 0.1f;
		if (PlayerHealth <= 0)
		{
			Time.timeScale = 0;
			showGameOver();
			finalScore.text = PlayerScore.ToString();
		}
	}

	public void showGameOver()
	{
		foreach(GameObject button in gameOverButtons)
		{
			button.SetActive(true);
		}
	}

	public void hideGameOver()
	{
		foreach(GameObject button in gameOverButtons)
		{
			button.SetActive(false);
		}
	}

}
