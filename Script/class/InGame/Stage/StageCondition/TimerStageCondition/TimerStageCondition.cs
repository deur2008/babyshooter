using UnityEngine;
using System.Collections;

//計時器
public class TimerStageCondition : StageCondition
{

    //關卡開始經過的時間
    public float _nowTime = 0;
    public float _TotalTime=100;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //=============public virtual==============

    //設定值
    public override void SetVaule(object value)
    {
        
    }

    //初始化
    public override void Initialize()
    {
        _nowTime = 0;
    }

    //動作被執行的一開始
    public override void OnConditionEnter()
    {
        UpdateTime();
    }

    //動作正在被執行
    public override void OnConditionStay()
    {
        UpdateTime();
    }

    //動作離開
    public override void OnConditionExit()
    {
        UpdateTime();
    }

    //取得時間
    public override object GetValue()
    {
        return _nowTime;
    }

    //private
    private void UpdateTime()
    {
        _nowTime = _nowTime + Time.deltaTime;
        if (_nowTime > _TotalTime)
        {
            //代表時間到惹，情況達成
            ConditionFinish();
        }
    }

   
}
