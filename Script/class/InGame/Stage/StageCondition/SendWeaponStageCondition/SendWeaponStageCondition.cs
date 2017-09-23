using UnityEngine;
using System.Collections;

//會把所有武器丟進選單內，如果使用者拿起來就回報
//裡面的選單都要是可以抓起武器的
public class SendWeaponStageCondition : ShowUIStageCondition
{
    //裡面會存放手持武器，
    public WeaponGameObjectSelector _weaponGameObjectSelector;

    //專門用來顯示武器UI的
    public HoldWeaponDialog _showWeaponDialog;

    //武器一定要拿著才會完成這個condition
    public bool _isHeldWeaponToFinishCondition = true;

    //初始化
    //如果沒問題就先顯示 _showResultPanel
    public override void Initialize()
    {
      
    }

    //動作被執行的一開始
    public override void OnConditionEnter()
    {
        Debug.Log("SendWeaponStageCondition_OnConditionEnter");
        _dialogIndex = -1;
        //設定目前顯示
        SetNowShowDialog(_showWeaponDialog);

        //整理出來
        WeaponGameObjectSelector nowInSceneWeapon = new WeaponGameObjectSelector();
        //把prefab裡面的武器複製出來
        _weaponGameObjectSelector.CopyInstantiate(nowInSceneWeapon);
        SetDialogValue(nowInSceneWeapon);
        //顯示
        ShowDialog();
    }

    public override void OnConditionStay()
    {
        //Debug.Log("SendWeaponStageCondition_OnConditionStay");
    }

   

    //設定值，如果要設定武器進來
    public override void SetVaule(object value)
    {
        _weaponGameObjectSelector = (WeaponGameObjectSelector)value;
    }
}
