using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public enum GameStates
	{
		GameWaiting,
		GamePaused,
		GameRunning,
		GameRotating,
		GameFinished,
		GameFailed
	}

	public GameStates gameState;

	public float GameTime;

	void Start () {
		gameState = GameStates.GameWaiting;
		GameTime = 0;
	}

	public void SetGameState(GameStates GameState)
	{
		gameState = GameState;
	}


	void Update () {
		if (gameState == GameStates.GameRunning) {
			GameTime += Time.deltaTime;
		}
	}
}
