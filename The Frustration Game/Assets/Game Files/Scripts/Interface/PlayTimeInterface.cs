using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayTimeInterface : MonoBehaviour {

	public GameObject Interface;
	private LevelData levelData;

	private PlayerInfo playerInfo;

	private Text LevelNumberText;
	private Text LevelNameText;

	private Text RoundTimeText;
	private float RoundTime;

	private Text BestTimeText;

	private Text GoldTimeText;
	private Text SilverTimeText;
	private Text BronzeTimeText;

	void Start () {
		
		levelData = LevelDataHandler.dataHandler.GetData ();

		playerInfo = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInfo> ();

		LevelNumberText = Interface.transform.Find ("Level Number").GetComponent<Text> ();
		LevelNameText = Interface.transform.Find ("Level Name").GetComponent<Text> ();

		RoundTimeText = Interface.transform.Find ("RoundTime").GetComponent<Text> ();

		BestTimeText = Interface.transform.Find ("BestTime").GetComponent<Text> ();

		GoldTimeText = Interface.transform.Find ("GoldTimer").GetComponent<Text> ();
		SilverTimeText = Interface.transform.Find ("SilverTimer").GetComponent<Text> ();
		BronzeTimeText = Interface.transform.Find ("BronzeTimer").GetComponent<Text> ();



		LevelNumberText.text = levelData.LevelNumber;
		LevelNameText.text = levelData.LevelName;

		if (PlayerPrefs.HasKey (levelData.LevelName)) {
			BestTimeText.text = (Mathf.Round (PlayerPrefs.GetFloat (levelData.LevelName) * 100) / 100).ToString ("00.00"); 
		} else {
			BestTimeText.text = "00.00";
		}

		GoldTimeText.text = (Mathf.Round (levelData.GoldTime * 100) / 100).ToString ("00.00");
		SilverTimeText.text = (Mathf.Round (levelData.SilverTime * 100) / 100).ToString ("00.00");
		BronzeTimeText.text = (Mathf.Round (levelData.BronzeTime * 100) / 100).ToString ("00.00");
	}

	void Update()	{

		RoundTimeText.text = (Mathf.Round (playerInfo.GameTime * 100) / 100).ToString("00.00");
			
	}
}