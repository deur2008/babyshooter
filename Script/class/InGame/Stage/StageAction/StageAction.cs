using UnityEngine;
using System.Collections;

//基本上大部分的動作都會在裡面先設定好，SetValue 只是在必要的時候傳值過去，而不是改變設定
public class StageAction : MonoBehaviour {

    //場景管理器，有這個後會比較好取得東西
    protected StageCondition _stageCondition;

    //=========================public virtaul=============
    //把目前管理器設定上去
    public virtual void SetStageController(StageCondition controller)
    {
        _stageCondition = controller;
    }

    //把值設定上去
    public virtual void SetValue(object value)
    {
    
    }

    //初始化
    public virtual void Initialize()
    {

    }

    //開始動作
    //設定這個情況是有完成
    public virtual void StartAction()
    {

    }

}
