using UnityEngine;
using System.Collections;

//會顯示結果
public class ShowResultUIStageCondition : ShowUIStageCondition
{
    //專門用來顯示結果的
    public ShowWaveResultDialog _showResultPanel;

    //初始化
    //如果沒問題就先顯示 _showResultPanel
    public override void Initialize()
    {
        _dialogIndex = -1;
        SetNowShowDialog(_showResultPanel);
        //設定 _showResultPanel 的相關字
        SetDialogValue();

        ShowDialog();
    }

    //設定Dialog 裡面的值
    void SetDialogValue()
    {
        //int remainHp=

    }

    //如果完成後 _dialogIndex 會==0，然後切換過去
    //base class已經實作
}
