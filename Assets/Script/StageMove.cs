using UnityEngine;
using System.Collections;

public class StageMove : MonoBehaviour {

	Vector3 CameraPoint = new Vector3(0,2,-8) ;
	Vector3 CameraMovePoint = new Vector3(0,2.3f,-10) ;

	public static int scene = 0;

	float timer = 0;

	float CameraYRotate = 180;

	[SerializeField]GameObject StartText;

	[SerializeField]GameObject ScoreObj;
	[SerializeField]GameObject BGM;

	// Use this for initialization
	void Start () {
		scene = 0;
		transform.localPosition = CameraPoint ; 
		transform.rotation = Quaternion.Euler(0, 180, 0);
		ScoreObj.SetActive( false);
	}

	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		switch( scene )
		{
			//タイトル
			case 0:
			{
				if( Input.GetMouseButton( 0 ))
				{
					scene++;
					timer = 0;
					Invoke( "FirstAnime" , 0.5f );
					Invoke( "Voice" , 1.5f );
					Destroy(StartText);
				}
				break;
			}
			//挨拶
			case 1:
			{
				if( timer >= 2.5f)
				{
					scene++;
					
				}
				break;
			}
			//回転
			case 2:
			{
				CameraYRotate -= Time.deltaTime * 300;
				if( CameraYRotate <= 0 )
				{	
					CameraYRotate = 0;			
					scene++;
				}
				transform.rotation = Quaternion.Euler(0, CameraYRotate, 0);
				
				break;
			}
			case 3:
			{
				Vector3 point = transform.localPosition ;
				bool ok = true;
				if( point.y < CameraMovePoint.y )
				{
 					point.y += Time.deltaTime * 5;
					if( point.y >= CameraMovePoint.y )
					{
						point.y = CameraMovePoint.y;
					}else
					{
						ok = false;
					}
				}
				if( point.z > CameraMovePoint.z )
				{
					point.z -= Time.deltaTime * 5;
					if( point.z <= CameraMovePoint.z )
					{
						point.z = CameraMovePoint.z;
					}else
					{
						ok = false;
					}
				}

				transform.localPosition = point;
				
				if( ok )
				{
					scene++;
					ScoreObj.SetActive( true );
					BGM.SetActive( true);
				}


				break;
			}

			case 4:
			{
				if( GameOver.GameOverFlag )
				{
					scene++;
					BGM.SetActive( false );
				}
				break;
			}

			case 5:
			{
				Vector3 point = transform.localPosition ;
				point.z -= Time.deltaTime * 5;
				if( point.z <= -18 )
				{
					scene++;
				}
				transform.localPosition = point;
				break;
			}


		}
	}

	
	void FirstAnime()
	{
		UnityChanCoin.UnityChanAnime();
	}

	void Voice()
	{
		GetComponent<AudioSource>().Play();
	}

}









