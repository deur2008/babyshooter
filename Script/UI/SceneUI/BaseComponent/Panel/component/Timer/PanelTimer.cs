using UnityEngine;
using System.Collections;

//計時器，會自動倒數
//如果時間到會自動選擇執行動作
public class PanelTimer : panelComponent
{

    //目前剩餘時間
    public float _nowRemainTime;
    //總共時間
    public float _Time=15;
    //開始計時
    public bool _execute=false;

    public override void Initialize()
    {
        //base.Initialize();
        _nowRemainTime = _Time;
    }

    public override void Execute()
    {
        //base.Execute();
        _execute = true;
    }

    void Update()
    {
        if (_execute)
        {
            _nowRemainTime = _nowRemainTime - Time.deltaTime;
            if (_nowRemainTime < 0)
                TimeOut();
        }
    }

    void TimeOut()
    {
        try
        {
            //強制直接選擇select
            if (GetComponent<PanelUI>() != null)
                GetComponent<PanelUI>().PressTrigger();
        }
        catch
        {

        }
    }
}
