using UnityEngine;
using System.Collections;

public class objCreate : MonoBehaviour {

	[SerializeField] GameObject obj;
	[SerializeField] float maxTimer = 0;
	float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( GameOver.GameOverFlag )
		{
			return;
		}
//		if( StageMove.scene >= 4 )
//		{
//
//		}else
//		{
//			return;
//		}

		timer += Time.deltaTime;
		if( timer >= maxTimer )
		{
			timer = 0;

			int roop = 1 + Random.Range( 0 , 3 ); 

			for(int i = 0; i < roop ; i++)
			{

				GameObject objData = (GameObject)Instantiate( obj );
				objData.transform.localPosition = new Vector3( Random.Range(19.0f ,20.0f ) +
				                                              roop * 2f  ,
				                                          Random.Range(2.0f , 9.5f ) ,
				                                         0 );
			}

		}

	}
}
