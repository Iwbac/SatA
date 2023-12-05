using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private charadata charadata;
    int HP;
    private Animator animator;
    private AnimatorClipInfo[] animator_clipinfo1;//AnimatorClipInfo型の変数を宣言
    private float state_time01;//float型の変数を宣言　ステートの時間取得用

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

         if (charadata != null)
        {
            //charadataの最大HPを代入。
            HP = charadata.MAXHP;
        }
    }
            

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("FirstHit!!!!");
        Damager damager = other.GetComponent<Damager>();
        if (damager != null )
        {
            if(! isAlreadyHit())
            {
            animator.SetTrigger("GetHitEnemy");
            Debug.Log("Hit!!!!");
            animator_clipinfo1 = animator.GetCurrentAnimatorClipInfo(0);//現在のアニメーションクリップの情報を取得 引数0はレイヤーの番号
            state_time01 = animator_clipinfo1[0].clip.length;
            StartCoroutine("AttackAnimeEnd");
            }
        }  
    }

    private bool one_hit = false;
    private bool isAlreadyHit()
    {
        return one_hit;
    }

    private IEnumerator AttackAnimeEnd()
    { 
        one_hit = true;
        for (var i = 0; i < state_time01; i++)
        {
            yield return null;
        }
        one_hit = false;
    }


     public void Damage(int value)
    {

        // charadataがnullでないかをチェック
        if (charadata != null)
        {
            // PlayerのATKからMazokusoldierのDEFを引いた値をHPから引く
            HP -= value - charadata.DEF;
            Debug.Log(HP);
        }
         // HPが0以下ならDeath()メソッドを呼び出す。
        if (HP <= 0)
        {
            Death();
        }
    }


     public void Death()
    {
        // ゲームオブジェクトを破壊
        Destroy(gameObject);
    }
}