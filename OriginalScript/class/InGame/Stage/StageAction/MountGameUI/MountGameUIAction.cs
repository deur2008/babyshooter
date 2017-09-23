using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//直接把東西載入進來，然後對應相對應的參數
public class MountGameUIAction : StageAction
{
    //要載入上去的UI
    //不會管回報問題，只是用來提醒
    PanelUI _loadToPlayerUI;

    //=========================public virtaul=============
    //把值設定上去
    public override void SetValue(object value)
    {
        _loadToPlayerUI.SetValue(value);
    }

    //初始化
    public override void Initialize()
    {
        //把東西複製好，丟到人物上面
    }

    //開始動作
    public override void StartAction()
    {

    }
}
