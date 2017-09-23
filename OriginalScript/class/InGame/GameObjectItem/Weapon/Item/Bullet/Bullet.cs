using UnityEngine;
using System.Collections;
using VRTK;

//子彈的腳本
//主要是負責子彈的行走位置
//目標
public class Bullet : Weapon {
    //子彈動畫
    BulletAnimation _animation;
    //子彈目標
    public GameObject _target=null;
    public float _disposeTime;
    public Vector3 _movePosition;
    //是否射出去
    bool _isfire=false;
    float _time = 0.0f;

    
    //設定目標
    public void SetTarget(GameObject target)
    {
        //設定目標
        _target = target;
    }

    //由gun觸發發射
    public void Shoot()
    {
        _isfire = true;
    }

    //開始
    protected virtual void Start()
    {
        //取得樣板
        _interact = GetComponent<VRTK_InteractableObject>();
        RegistEvent();
    }

    // Update is called once per frame
    void Update () {
        //如果已經射出去
        if (_isfire)
        {
            //計算dislose時間
            CalDisposeTime();
            //移動
            Move();
        }
	}

    //計算消失時間
    void CalDisposeTime()
    {
        _time = _time + Time.deltaTime;
        if (_time > _disposeTime)
        {
            //把自己個給滅掉
            Destroy(this.gameObject);
        }
    }

    //移動
    void Move()
    {
        if (_target != null)
        {
            //對準目標
            this.transform.LookAt(_target.transform);
        }
        //然後移動
        this.transform.Translate(_movePosition*Time.deltaTime);
    }

    //如果有撞到東西
    //例如顯示爆炸動畫之類的 ? 
    void OnCollisionEnter(Collision collision)
    {
        //如果撞到敵人，通知character ? 
        try
        {
            GameObject target = collision.gameObject;
            if (isEnemy(target))//如果打到是敵人
            {
                //通知打到東西
                //NotifiedWeaponOnCollisionTarget();
            }
        }
        catch
        {

        }
    }

    

}
