using UnityEngine;
using System.Collections;

public class EffectMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	float normalTimer = 0;

	// Update is called once per frame
	void Update () {
		normalTimer += Time.deltaTime;
		if( normalTimer >= 5 )
		{
			Destroy( gameObject);
		}
	}
}
