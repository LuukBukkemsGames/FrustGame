using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour {

	public GameObject RotateMap;
	private PlayerInfo playerInfo;

	private bool _Halfway;
	private Quaternion _RotHalf;
	private Quaternion _RotEnd;
	private float _RotateSpeed;
	private float _StartTime;

	void Start () {
		playerInfo = this.gameObject.GetComponent<PlayerInfo> ();
		_Halfway = false;
		_RotateSpeed = 2.5f;
		}
	
	public void RotateLeft()
	{
		_RotHalf = Quaternion.Euler(RotateMap.transform.rotation.eulerAngles + (new Vector3 (0, 0, 45)));
		_RotEnd = Quaternion.Euler(RotateMap.transform.rotation.eulerAngles + (new Vector3 (0, 0, 90)));
		playerInfo.SetGameState(PlayerInfo.GameStates.GameRotating);
		_RotateSpeed = 2.5f;
		_StartTime = Time.time;

	}

	public void RotateRight()
	{
		_RotHalf = Quaternion.Euler(RotateMap.transform.rotation.eulerAngles + (new Vector3 (0, 0, -45)));
		_RotEnd = Quaternion.Euler(RotateMap.transform.rotation.eulerAngles + (new Vector3 (0, 0, -90)));
		playerInfo.SetGameState(PlayerInfo.GameStates.GameRotating);
		_RotateSpeed = 2.5f;
		_StartTime = Time.time;

	}

	private void FixedUpdate()
	{
		if (playerInfo.gameState == PlayerInfo.GameStates.GameRotating) {

			if (!_Halfway) 
			{
				RotateMap.transform.rotation = Quaternion.RotateTowards (RotateMap.transform.rotation, _RotHalf, _RotateSpeed * Time.fixedDeltaTime);
				_RotateSpeed = (Time.time - _StartTime) + _RotateSpeed;

				if (_RotHalf == RotateMap.transform.rotation) {
					_Halfway = true;

				}
			} 

			if (_Halfway)
			{
				RotateMap.transform.rotation = Quaternion.RotateTowards (RotateMap.transform.rotation, _RotEnd, _RotateSpeed * Time.fixedDeltaTime);
				_RotateSpeed =  _RotateSpeed - .64f * (Time.time - _StartTime);
				if (_RotateSpeed <= 2.5f)
					_RotateSpeed = 2.5f;
			}
			if (_RotEnd == RotateMap.transform.rotation) {
				RotateMap.transform.rotation = _RotEnd;
				_Halfway = false;
				playerInfo.SetGameState(PlayerInfo.GameStates.GameRunning);	
			}
		}
	}
}
