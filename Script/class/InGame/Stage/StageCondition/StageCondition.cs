using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//會負責管理一些狀態，如果符合這些狀態就會執行Action(List)
//如果是這個狀態會直接執行Action
public class StageCondition : MonoBehaviour {

    //要執行的動作
    public List<StageAction> _listAction;

    //目前
    public StageController _stageController;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //=============public virtual==============

    //把主觀卡附加上去
    public virtual void SetStageController(StageController controller)
    {
        _stageController = controller;
    }

    //設定值
    public virtual void SetVaule(object value)
    {

    }

    //初始化
    public virtual void Initialize()
    {

    }

    //動作被執行的一開始
    public virtual void OnConditionEnter()
    {
        //因為是base class，所以條件直接達成
        ConditionFinish();
    }

    //動作正在被執行
    public virtual void OnConditionStay()
    {

    }

    //動作離開
    public virtual void OnConditionExit()
    {

    }

    //取得目前的值
    public virtual object GetValue()
    {
        return new object();
    }

    //============protected void======

    //如果到
    protected virtual void SetBool(bool state)
    {

    }

    //如果到
    protected virtual void SetTrigger()
    {

    }

    //如果到
    protected virtual void SetFloat(float value)
    {

    }

    //如果狀態達到
    protected virtual void ConditionFinish()
    {
        //把所有Action都跑過一次
        foreach (StageAction action in _listAction)
        {
            //初始化，執行
            action.SetStageController(this);
            action.Initialize();
            action.StartAction();
        }
    }

    public StageController StageController
    {
        get
        {
            return _stageController;
        }
        set
        {
            _stageController = value;
        }
    }
}
