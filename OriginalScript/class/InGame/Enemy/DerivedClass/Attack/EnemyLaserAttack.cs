using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//使用雷射槍攻擊
//瞄準方式是先讓 _controllerTagert 面對玩家 ，然後看要不要修正 _laserGun 位置
//統一射擊方向都是面對Z軸，然後Y軸潮上

//流程 : 決定射擊 >> 面對方向 >> 延遲 >> 射擊(可能停留一小算時間或是只射一發)
public class EnemyLaserAttack : EnemyAction
{
    //雷射槍，裡面要包含weapon
    public laserGun _laserGun;

    //還有要操作雷射槍的本體
    //如果不是null會對他進行轉動
    public GameObject _controllerTagert;

    //這樣只有Y軸不會轉動
    public Vector3 _faceDirection=new Vector3(1,0,1);

    Character _character;

    //目前設定延遲是一秒，也就是如果是反方向會一秒鐘後面對玩家
    float _delatTime = 1.0f;

    //設定難度
    protected override void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = (GunAttackParameter)difficulty;
    }

    //設定初始化
    public override void Initialize()
    {
        _character = _enemy._target.GetComponent<SteamVR_CharacterController>()._character;
    }

    void Update()
    {
        if (_executeAction)
        {
            Aim(_character.gameObject);
            Shoot();
        }
    }

    //執行動作
    public override void ExecAction()
    {
        _executeAction = true;
        //動畫開始
        SetStartAnimation();
        //播放音效
        PlayAudio();
    }

    //取消動作
    public override void StopAction()
    {
        _executeAction = false;
        //動畫停止
        SetStopAnimation();
        //停止音效
        StopAudio();
    }

    //設定動畫
    public override void SetStartAnimation()
    {
        _animator.SetBool("Shoot", true);
    }

    //設定動畫
    public override void SetStopAnimation()
    {
        _animator.SetBool("Shoot", false);
    }

    //把砲塔移動過去
    //如果沒有砲塔就是自身移過去
    void Aim(GameObject target)
    {
        if (_controllerTagert != null)
        {
            //SlowLookAt(target.transform.position, _delatTime, _controllerTagert);
        }
        else
        {
            //SlowLookAt(target.transform.position, _delatTime, this.gameObject);
        }
    }

    //用比較慢的速度觀看
    void SlowLookAt(Vector3 position,float speed,GameObject target)
    {
        Vector3 direction = position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        target.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
    }

    //準備射擊
    void Shoot()
    {
        _laserGun.ShootLaserBullet();
    }
    
}
