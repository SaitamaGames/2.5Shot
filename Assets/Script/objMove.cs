using UnityEngine;
using System.Collections;

//的のうごき
public class objMove : MonoBehaviour {

	//エフェクト
	[SerializeField] GameObject Effect;
	//ヒットサウンド
	[SerializeField] AudioSource HitSound;
	//死亡サウンド
	[SerializeField] AudioSource DeadSound;


	//死んでいますか
	bool dead = false;
	//死亡後のタイマー
	float deadTimer = 0;
	//体力
	public int life = 1;

	float lifeTimer =0 ;

	void Start () {
	
	}
	
	void Update () {
	
		//ゲームオーバー中は動きません
		if( GameOver.GameOverFlag )
		{
			return;
		}

		//死んでるときのカウント
		if( dead )
		{
			deadTimer += Time.deltaTime;
			if( deadTimer >= 3.0f || life <= -5)
			{
				Dead();
			}
		}else
		{
			//15秒立ったらけす　念のため
			lifeTimer += Time.deltaTime;
			if( lifeTimer >= 15 )
			{
				Destroy( gameObject);
			}
		}

		//動きの処理
		Vector3 point = transform.localPosition;
		if( dead )
		{
			point.x -= Time.deltaTime * 2 ;
		}else
		{
			point.x -= Time.deltaTime * 5 ;

		}
		transform.localPosition = point ;

	}

	//死んでいるか
	public bool getDead()
	{
		return dead;
	}


	//衝突で呼ばれます
	private void OnCollisionEnter(Collision collision)
	{
		string tag = collision.gameObject.tag;
				
		//射撃　もしくは敵同士でぶつかったら死ぬ
		if( tag == "Shot" || tag == "Enemy" )
		{
			if(HitSound != null)
			{
				Instantiate(HitSound);
			}

			if( tag == "Enemy" )
			{
				if( collision.transform.GetComponent<objMove>().getDead() )
				{
					life = 0;
				}
			}else
			{
				life--;
			}
			if( life <= 0 )
			{
				dead = true;
				//死ぬと周りを巻き込む
				GetComponent<Rigidbody>().useGravity = true;
				GetComponent<Rigidbody>().isKinematic = false;
			}
			Score.ScorePoint++;
			if( tag == "Shot" )
			{
				collision.transform.GetComponent<ShotMove>().shotHit();
			}

		}else
		if( tag == "Player" )
		{
			GameOver.GameOverFlag = true;

		}
		else
		if( tag == "Ground" )
		{
			Dead();
		}
//		else
//		if( tag == "GameOver")
//		{
//			GameOver.GameOverFlag = true;
//		}
	}

	//死んだとき
	void Dead()
	{
		if(DeadSound != null)
		{
			Instantiate(HitSound);
		}
		if( Effect != null )
		{
			GameObject obj = (GameObject)Instantiate( Effect );
			obj.transform.position = transform.position;
		}
		Score.ScorePoint+=10;
		Destroy( gameObject);

	}

}











