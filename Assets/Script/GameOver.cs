using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public static bool GameOverFlag = false; 
	[SerializeField] GameObject text ;
	// Use this for initialization
	void Start()
	{
		GameOverFlag = false;
	}


	void OnGUI()
	{
		if( GameOverFlag )
		{
			text.gameObject.SetActive(true);
			if(GUI.Button(new Rect(Screen.width/2 -75, Screen.height/2  ,150, 90), "Retry"))
			{
				GameOverFlag = false;
				StageMove.scene = 0;
				Application.LoadLevel("main");
			}
		}else
		{
			text.gameObject.SetActive(false);
		}
	}



}
