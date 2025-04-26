using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manimenu : MonoBehaviour
{
	public void ClickToStart()
	{
		Debug.Log("Start Game!");
		//SceneManager.LoadScene(1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ClickToQuit()
	{
		Debug.Log("Quit Game!");
		Application.Quit();

	}

	public void ClickToHome()
	{
		SceneManager.LoadScene(0);
	}
}
