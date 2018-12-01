using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

	private PlayerInfo playerInfo;

	void Start () {
		playerInfo = this.gameObject.GetComponent<PlayerInfo> ();
	}

	void Update () {
		
	}

	private void OnTriggerStay(Collider other) {

		if (playerInfo.gameState != PlayerInfo.GameStates.GameRunning) 
		{
			return;
		}

			if (other.tag == "Finish") {
			playerInfo.SetGameState (PlayerInfo.GameStates.GameFinished);
				Debug.Log ("Good Shit budd");
			}

			else if (other.tag == "Wall") {
			playerInfo.SetGameState (PlayerInfo.GameStates.GameFailed);
				Debug.Log ("Issa wall");
			}

			else if (other.tag == "GameFire") {
			playerInfo.SetGameState (PlayerInfo.GameStates.GameFailed);
				Debug.Log (" Oof ouch owie");
			}
		}

}
