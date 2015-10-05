using UnityEngine;
using System.Collections;

public class ShotControl : MonoBehaviour {

	[SerializeField] GameObject shot;
	[SerializeField] GameObject UnityChan;
	float shotWait = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( shotWait > 0 )
		{
			shotWait-=Time.deltaTime;
			return;
		}

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

		//if( Input.GetMouseButton(0))
		{
			shotWait = 0.25f;

			GameObject objData = (GameObject)Instantiate( shot );
			Vector3 point =  UnityChan.transform.localPosition;
			point.y += 1.5f;
			point.x += 1.0f;
			objData.transform.localPosition = point;

		}
	}
}









