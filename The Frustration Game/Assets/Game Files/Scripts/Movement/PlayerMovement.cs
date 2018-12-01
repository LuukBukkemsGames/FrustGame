using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	private GameObject MyPlayer;
	private PlayerInfo playerInfo;

	private Vector3 movement;
	private float speed;


	void Start () {
		MyPlayer = this.gameObject;
		playerInfo = MyPlayer.GetComponent<PlayerInfo> ();

		movement = Vector3.zero;
		speed = 2;
	}

	public void Update()
	{
		if (playerInfo.gameState == PlayerInfo.GameStates.GameRunning ) {
			MyPlayer.GetComponent<CharacterController> ().Move (movement * speed * Time.deltaTime);
		} 
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,0);
	}

		public void MoveUp()
	{		movement.y = 1;}

	public void MoveDown()
	{		movement.y = -1;}

	public void MoveLeft()
	{		movement.x = -1;}

	public void MoveRight()
	{		movement.x = 1;}
}
