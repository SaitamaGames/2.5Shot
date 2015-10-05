using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int ScorePoint = 0;
	[SerializeField] GUIText gui;
	// Use this for initialization
	void Start () {
		ScorePoint = 0;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		gui.text = "ScorePoint:"+ ScorePoint;
		Time.timeScale = 1.0f + (float)ScorePoint / 1000 ;
	}

}
