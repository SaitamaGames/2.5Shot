using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[SerializeField] ParticleSystem DownFire;
	// Use this for initialization
	void Start () {
	
	}

	float down_power =0;

	// Update is called once per frame
	void Update () {
	
		if( GameOver.GameOverFlag)
		{
			return;
		}

		{
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
			// Vector3でマウスがクリックした位置座標を取得する
//			Vector3 clickPosition = Input.mousePosition;
//			// Z軸修正
//			clickPosition.z = 10f;
//
//		  	Vector3 point = Camera.main.ScreenToWorldPoint(clickPosition);
//
			Vector3 MYpoint =	transform.localPosition;
//
//			//距離を調べる
//			{
//				Vector3 Dist = point;
//				Dist.x = 0;
//				Dist.z = 0;
//				Vector3 Dist2 = MYpoint;
//				Dist2.x = 0;
//				Dist2.z = 0;
//
//				if( Vector3.Distance( Dist , Dist2 ) <= 1 )
//				{
//					return;
//				}
//			}




			//押したら上昇
			if( Input.GetMouseButton(0))
			{
				//上昇する力がふえっる
				down_power += Time.deltaTime*2;
				if(down_power >= 1)
				{
					down_power = 1 ;
				}
				if( Input.GetMouseButtonDown(0))
				{
					if( DownFire != null )
					{
						DownFire.Play();
					}
				}
			}else
			{
				//下降する力がふえっる
				down_power -= Time.deltaTime*2;
				if(down_power <= -1)
				{
					down_power = -1 ;
				}
				if( DownFire != null )
				{
					DownFire.Stop();
					//DownFire.SetActive( false );
				}
			}


			//上下に動く
			MYpoint.y += Time.deltaTime*5* down_power;

			//一定以上は行かない
			if( MYpoint.y >= 8 )
			{
				MYpoint.y = 8;
			}
			//一定以下には行かない
			if( MYpoint.y <= 1 )
			{
				MYpoint.y = 1;
			}

			transform.localPosition = MYpoint ;

		}
	}
}










