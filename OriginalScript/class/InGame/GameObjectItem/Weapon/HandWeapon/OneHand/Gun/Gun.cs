using UnityEngine;
using System.Collections;
using VRTK;

//槍枝，基本的Class
//綁定槍枝GameObject，然後對上的物件進行操作
//如果要把植存到baseClass，使用base(C#)

//把腳本附著在武器的跟目錄上
public class Gun : Weapon {
    //子彈數量
    public int _bulletNumber;
    //一發數量
    public int _oneSingleShootNumber=10;
    //連發速度
    public float _turboPeriodTime=0.1f;//代表每秒可以10發

    //範例武器
    public GameObject _demoBullet;
    //
    public GameObject _buttonCreateGameObject;

    //是否按下板機
    bool _isPressTrigger=false;


    //開始
    protected override void Start()
    {
        //取得樣板
        _interact = GetComponent<VRTK_InteractableObject>();
        RegistEvent();
    }

    //註冊事件
    protected override void RegistEvent()
    {
        //壓下板機
        _interact.InteractableObjectUsed += new InteractableObjectEventHandler(DoObjectUse);
        //把版機放開
        _interact.InteractableObjectUnused += new InteractableObjectEventHandler(DoObjectUnuse);
    }

    //如果有按下按鈕就射擊
    void Update()
    {
        if (_isPressTrigger)
        {
            ShootBullet();
        }
    }


    //====================private Class==================
    void OnCollisionEnter(Collision collision)
    {
        /*
        //如果撞到敵人，通知character ? 
        try
        {
            GameObject target = collision.gameObject;
            if (isEnemy(target))//如果打到是敵人
            {
                //通知打到東西
                NotifiedWeaponOnCollisionTarget();
            }
        }
        catch
        {

        }
        */
    }

    //====================override Class==================

    //抓取物件
    protected override void DoObjectUse(object sender, InteractableObjectEventArgs e)
    {
        _isPressTrigger = true;
        _remainShootNumber = _oneSingleShootNumber;
    }

    //把物件放下
    protected override void DoObjectUnuse(object sender, InteractableObjectEventArgs e)
    {
        _isPressTrigger = false;
    }


    float _time;
    int _remainShootNumber = 10;
    //壓下
    //會每一個frame被call依次
    public void ShootBullet()
    {
        
        _time = _time + Time.deltaTime;
        if (_time> _turboPeriodTime)
        {
            
            _time = _time - _turboPeriodTime;
            if (_remainShootNumber>0)
            {
                Debug.Log("OnTriggerPress" + _time + " " + Time.deltaTime);
                _remainShootNumber--;
                if (_bulletNumber > 0)
                {
                    
                    //連發
                    //複製物件
                    GameObject bullet = Instantiate(_demoBullet);
                    //設定在父類別下面
                    //bullet.transform.parent = _buttonCreateGameObject.transform;
                    bullet.transform.localPosition = _buttonCreateGameObject.transform.position;
                    bullet.transform.localRotation = _buttonCreateGameObject.transform.rotation;
                    /*
                    //然後設定通知
                    bullet.GetComponent<Bullet>()._collisonEnemy += new WeaponOnCollisionEnemy(OnBulletShootTarget);
                    //如果有目標
                    if (target != null)
                    {
                        bullet.GetComponent<Bullet>().SetTarget(target);
                    }
                    */
                    bullet.GetComponent<Bullet>().Shoot();
                    _bulletNumber--;
                    
                }
            }
        }
    }

   


}
