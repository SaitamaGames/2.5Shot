using UnityEngine;
using System.Collections;

public class UnityChanCoin : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
	private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照

	private static bool animeUnity = false;

	// Use this for initialization
	void Start () {
		// 各参照の初期化
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;

	}
	
	// Update is called once per frame
	void Update () {

		if( animeUnity )
		{
//			int rand = Random.Range(0,3);
//			if(rand == 0 )
//			{
//				anim.SetBool ("Coin", true);
//			}else
//			if(rand == 1 )
//			{
//				anim.SetBool ("Coin2", true);
//			}else
//			if(rand == 2 )
//			{
//				anim.SetBool ("Coin3", true);
//			}
			anim.SetBool ("Coin", true);
			animeUnity = false;
			return;
		}
		// "Next"フラグがtrueの時の処理
		if (anim.GetBool ("Coin")) {
			// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			if (previousState.nameHash != currentState.nameHash) {
				anim.SetBool ("Coin", false);
				previousState = currentState;				
			}
		}
		if (anim.GetBool ("Coin2")) {
			// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			if (previousState.nameHash != currentState.nameHash) {
				anim.SetBool ("Coin2", false);
				previousState = currentState;				
			}
		}
		if (anim.GetBool ("Coin3")) {
			// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			if (previousState.nameHash != currentState.nameHash) {
				anim.SetBool ("Coin3", false);
				previousState = currentState;				
			}
		}
	}

	public static void UnityChanAnime()
	{
		animeUnity = true;
	}


}
