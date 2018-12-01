using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private PlayerInfo playerInfo;
	private PlayerMovement playerMovement;
	private MapMovement mapMovement;

	private PlayerInfo.GameStates gameState;

	private bool Started;

	void Start () {
		playerInfo = this.gameObject.GetComponent<PlayerInfo> ();
		playerMovement = this.gameObject.GetComponent<PlayerMovement> ();
		mapMovement = this.gameObject.GetComponent<MapMovement> ();
		Started = false;
	}

	void Update () {

		if (playerInfo.gameState == PlayerInfo.GameStates.GameWaiting && Started == false) {
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
				playerInfo.SetGameState (PlayerInfo.GameStates.GameRunning);
				Started = true;
			}
		} 
			
		if (Started == false) {
			return;
		}

		if (playerInfo.gameState == PlayerInfo.GameStates.GameRunning) {

			if (Input.GetKeyDown (KeyCode.A)) {
				playerMovement.MoveLeft ();
			}

			if (Input.GetKeyDown (KeyCode.D)) {
				playerMovement.MoveRight ();
			}

			if (Input.GetKeyDown (KeyCode.W)) {
				playerMovement.MoveUp ();
			}

			if (Input.GetKeyDown (KeyCode.S)) {
				playerMovement.MoveDown ();
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				mapMovement.RotateLeft ();
				playerInfo.SetGameState (PlayerInfo.GameStates.GameRotating);
			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				mapMovement.RotateRight ();
				playerInfo.SetGameState (PlayerInfo.GameStates.GameRotating);
			}
		}
	}
}
