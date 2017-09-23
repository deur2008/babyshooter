using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//處理准心問題
//把准心瞄準在敵人上面ODO
public class InGameAlertEnemyAimUI : InGameEnemyInfoUI
{
    //目前所有在畫面上的物件
    public List<GameObject> _listTemplate;

    //左右手手手的位置
    //可以取得武器，或是算出瞄準位置
    //public GameObject _leftHandWeapon;
    //public GameObject _rightHandWeaon;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_enable)
        {
            UpdateView();
        }
    }

    //把所有東西都指定上去
    public override void Initialize()
    {
        //把物件從硬碟上面複製下來
        
    }

    //更新一下目前的敵人
    //如果在敵人被更改的時候會做通知
    public override void UpdateEnemy()
    {
        _listTarget = new List<GameObject>();
        foreach (GameObject target in _manager._listEnemy)
        {
            try
            {
                //如果有要顯示瞄準器
                if (((SingleWeakPointParameter)target.GetComponent<SingleWeakPoint>()._nowdifficulty)._showAimmer)
                {
                    _listTarget.Add(target);
                }
            }
            catch //(Exception ex)
            {
                //Debug.Log(ex.Message);
            }
        }
        if (_listTarget.Count != _listTemplate.Count)
        {
            UpdateAimmer();
        }
    }

    void UpdateAimmer()
    {
        //先把所有樣板都清掉
        foreach (GameObject template in _listTemplate)
        {
            Destroy(template);
        }
        _listTemplate = new List<GameObject>();
        //增加到敵人數量
        foreach (GameObject target in _listTarget)
        {
            _listTemplate.Add(CopyAimmer());
        }
    }

    GameObject CopyAimmer()
    {
        GameObject aimmer = GameObject.Instantiate(_template);
        aimmer.SetActive(true);
        aimmer.transform.parent = this.transform;
        aimmer.transform.localScale = new Vector3(1, 1, 1);
        aimmer.transform.localPosition = new Vector3(0, 0, 0);
        return aimmer;
    }

    //更新一下位置
    //每個Frame都要更新一次
    protected override void UpdateView()
    {
        if (_listTarget != null)
        {
            if (_listTarget.Count > 0)
            {
                for (int i = 0; i < _listTarget.Count; i++)
                {
                    _listTemplate[i].transform.LookAt(_listTarget[i].transform);
                    UpdateSingleValue(_listTemplate[i], _listTarget[i]);
                }
            }
        }
    }

    //更新單一元件
    //要被繼承修改
    protected override void UpdateSingleValue(GameObject template, GameObject target)
    {
        //Aimmer 模式
        UpdateAimmerMode(template, target);
        //更新距離
        UpdateDistance(template, target);

    }

    void UpdateAimmerMode(GameObject template, GameObject target)
    {
        //如果是可以攻擊
        if (true)
        {
            template.GetComponent<InGameSingleAimmerUI>().SetToCanAttack();
        }
        else
        {
            template.GetComponent<InGameSingleAimmerUI>().SetToCanNotAttackMode();
        }
    }

    void UpdateDistance(GameObject template, GameObject target)
    {
        //如果距離太近
    }

}
