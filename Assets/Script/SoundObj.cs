using UnityEngine;
using System.Collections;

public class SoundObj : MonoBehaviour {

	float Timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if(Timer >= 3 ) 
		{
			Destroy(gameObject);
		}	
	}
}
