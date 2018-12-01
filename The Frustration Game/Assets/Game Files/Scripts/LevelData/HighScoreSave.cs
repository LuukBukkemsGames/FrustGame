using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreSave : MonoBehaviour {

	public void LevelFinished(float FinishedTime)
	{
		if (PlayerPrefs.HasKey (SceneManager.GetActiveScene ().name)) {
			if (PlayerPrefs.GetFloat (SceneManager.GetActiveScene ().name) < FinishedTime && PlayerPrefs.GetFloat (SceneManager.GetActiveScene ().name) > 0) {
				return;
			}
			else {
				PlayerPrefs.SetFloat (SceneManager.GetActiveScene ().name, FinishedTime);
			}
		}
		else {
			PlayerPrefs.SetFloat (SceneManager.GetActiveScene ().name, FinishedTime); 
		}
	}
}
