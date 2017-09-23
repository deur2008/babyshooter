using UnityEngine;
using System.Collections;

//如果碰到敵人，就會損血
public class EnemyTouchAttack : EnemyAction {

    float _touchPlayerTime;

    //設定難度
    protected override void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = (TouchPlayerParameter)difficulty;
    }

    //
    public float GetTouchDamage()
    {
        return 0;
    }

    //設定動畫
    //碰到敵人的動畫
    public override void SetStartAnimation()
    {
        _animator.SetTrigger("Attack");  
    }

    //設定動畫
    //就算是被選倒也沒有動畫
    public override void SetStopAnimation()
    {
        
    }

    //如果碰到玩家
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            _touchPlayerTime = 0;
            SetStartAnimation();
        }
    }

    //如果持續碰到
    void OnCollisionStay(Collision collision)
    {
        //Debug.Log("Enemy Attack Player : OnCollisionStay : " + collision.gameObject.name);
        //如果碰到Character
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            _touchPlayerTime = _touchPlayerTime + Time.deltaTime;

            //如果時序間隔一段時間碰到
            if (_touchPlayerTime > ((TouchPlayerParameter)_nowdifficulty).Time)
            {
                _touchPlayerTime = 0;
                //把損傷加到腳色上面
                //玩家也是用singleWeakPoint
                collision.gameObject.GetComponent<WeakPoint>().SetDamage(((TouchPlayerParameter)_nowdifficulty).Damage);
                Debug.Log("Enemy Attack Player");
                SetStartAnimation();
            }
        }
    }

    //離開
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            collision.gameObject.GetComponent<Character>();
            SetStopAnimation();
        }
    }
}
