using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manimenu : MonoBehaviour
{
  public void PlayGame()
  {
	  SceneManager.LoadSceneAsync("Lagomorph LVL 1");
  }
}
