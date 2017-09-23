using UnityEngine;
using System.Collections;
using VRTK;

//雷射槍
//主要是透過其他方式發射
public class laserGun : Weapon
{
    //子彈數量
    public int _bulletNumber;
    //連發速度
    public float _turboPeriodTime = 0.2f;//代表每秒可以10發
    //雷射發射器
    public BulletLaser _laserBullet;
    //如果板機按下
    bool _ispressTrigger;

    //開始
    protected override void Start()
    {
        //取得樣板
        _interact = GetComponent<VRTK_InteractableObject>();
        if (_interact != null)
        {
            RegistEvent();
        }
    }

    //註冊事件
    protected override void RegistEvent()
    {
        //註冊事件
        _interact.InteractableObjectUnused += new InteractableObjectEventHandler(DoObjectUnuse);
        //被使用
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
    }

    float _time;
    int _remainShootNumber = 10;
    void Update()
    {
        if (_ispressTrigger)
        {
            ShootLaserBullet();
        }
    }

    //供外部呼叫使用
    //需要一直呼叫
    public void ShootLaserBullet()
    {
        _time = _time + Time.deltaTime;
        if (_time > _turboPeriodTime)
        {
            _laserBullet.Shoot();
            //然後把時間撿回來
            _time = _time - _turboPeriodTime;
        }
    }

    //====================override Class==================

    //抓取物件
    protected override void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {
        _ispressTrigger = true;
        //_remainShootNumber = _oneSingleShootNumber;
        _laserBullet.Shoot();
        //Debug.Log("Use Gun");
    }

    //把物件放下
    protected override void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {
        _ispressTrigger = false;
        //Debug.Log("Use NotUse");
    }

}
