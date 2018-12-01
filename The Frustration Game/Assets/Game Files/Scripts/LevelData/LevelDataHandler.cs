using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelDataHandler : MonoBehaviour {

	private LevelData levelData;
	private List<LevelData> LevelDataList = new List<LevelData>();

	public static LevelDataHandler dataHandler;

	void Awake () {

		if (dataHandler == null) {
			DontDestroyOnLoad (this.gameObject);
			dataHandler = this.GetComponent<LevelDataHandler>();
			levelData = new LevelData ();
			InitGameData ();
		} 
		else if (dataHandler != this) {
			Destroy (gameObject);
		}
	}

	public LevelData GetData()
	{
		for (int i = 0; i < LevelDataList.Count; i++) {
			if (LevelDataList [i].LevelNumber == SceneManager.GetActiveScene().name) {
				return LevelDataList [i];
			} 
		}
		return null;
	}

	private void InitGameData()
	{
		SetupDataType ("Level 1","The Beginning",6f,8f,10f);
		SetupDataType ("Level 2","The Beginning",6.5f,8f,10f);
		SetupDataType ("Level 3","The Beginning",6.5f,8f,10f);
		SetupDataType ("Level 4","The Beginning",6.5f,8f,10f);
		SetupDataType ("Level 5","The Beginning",6.5f,8f,10f);
		SetupDataType ("Level 6","The Beginning",6.5f,8f,10f);
		SetupDataType ("Level 7","The Beginning",6.5f,8f,10f);

	}

	private void SetupDataType(string Number, string Name, float Gold, float Silver, float Bronze)
	{

		for (int i = 0; i < LevelDataList.Count; i++) {
			if (LevelDataList [i].LevelNumber == Number) {
				return;
			}
		}

		levelData.LevelNumber = Number;
		levelData.LevelName = Name;
		levelData.GoldTime = Gold;
		levelData.SilverTime = Silver;
		levelData.BronzeTime = Bronze;

		LevelDataList.Add (levelData);

		levelData = new LevelData ();
	}
}
