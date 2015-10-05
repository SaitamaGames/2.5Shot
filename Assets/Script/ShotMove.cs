using UnityEngine;
using System.Collections;

/// <summary>
/// 射撃の動き
/// </summary>
public class ShotMove : MonoBehaviour {

	//煙エフェクト
	[SerializeField] GameObject SmokeEf;
	//ヒットエフェクト
	[SerializeField] GameObject EffectHit;


	float lifeTimer = 1.0f ;
	bool collisionFlag = false;
	float normalTimer = 0;


	//最初に呼ばれる
	void Start () {

		//煙のエフェクト発生
		if( SmokeEf != null )
		{
			GameObject obj = (GameObject)Instantiate( SmokeEf );
			obj.transform.parent = transform;
			obj.transform.localPosition = Vector3.zero;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
//		if( collisionFlag )
//		{
//			lifeTimer -= Time.deltaTime;
//			if( lifeTimer <= 0 )
//			{
//				Destroy( gameObject );
//			}
//		}

		Vector3 point = transform.localPosition;
		point.x += Time.deltaTime*4;
		//point.y += Time.deltaTime*3;

		transform.localPosition = point;



		normalTimer += Time.deltaTime;
		if( normalTimer >= 5 )
		{
			Destroy( gameObject);
		}
	}

	public void shotHit()
	{
		collisionFlag = true;
		//爆発エフェクト発生
		if( EffectHit != null )
		{
			GameObject obj = (GameObject)Instantiate( EffectHit );
			obj.transform.position = transform.position;
		}

		Destroy( gameObject);
	}


}
