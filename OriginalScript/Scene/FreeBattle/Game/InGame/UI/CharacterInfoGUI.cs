using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//負責去控制GUI把畫面顯示出來
//如果有空會變成List<GameComponentUI> 來管理
public class CharacterInfoGUI : MonoBehaviour {

    //目前player
    public Character _target;
    
    //血量，目前改成敵人打敗數量，和補血(送武器)的進度條
    //或是顯示目前場上敵人數量，對比HP做調整?
    public TeamEnemyBar TeamEnemyBar;

    //時間，wave那邊強制更新
    public TimeViewer TimeViewer;

    //HP View，從Character 那邊抓過來
    public HPViewer HPViewer;

    //ExBar，距離下一個Wave的進度
    public ExBar EXBar;

    //BoostBar，距離下一個發武器
    public BoostBar BoostBar;

    //地圖，之後會在做出來
    public MapUI Map;

    //有關敵人提醒管理器
    public EnemyAlertManager _InGameAlertEnemyUI;
    //顯示系統UI
    public InGameSystemUI _inGameSystemUI;

    //然後先用這個做測試
    //把所有敵人丟進這個list裡面
    public List<GameObject> _testEnemyList;

    void Start () {
        //把最大的質設定上去
        //目前範圍在0~1之間
        SetMaxTeamProgress(1);
        SetEnemyMaxProgress(1);
        SetMaxEx(1);
        SetMaxBoost(1);
    }

    //更新模式
    public void UpdateMode(SteamVR_CharacterController.ControlMode mode)
    {
        switch (mode)
        {
            case SteamVR_CharacterController.ControlMode.ControlMenu :
                IsShowGameUI(false);
                break;
            case SteamVR_CharacterController.ControlMode.PauseMode:
                IsShowGameUI(true);
                break;
            case SteamVR_CharacterController.ControlMode.PlayGame:
                IsShowGameUI(true);
                break;
        }
    }

    //要不要顯示UI
    void IsShowGameUI(bool show)
    {
        TeamEnemyBar.gameObject.SetActive(show);
        TimeViewer.gameObject.SetActive(show);
        HPViewer.gameObject.SetActive(show);
        //因為wave用不到所藏起來
        EXBar.gameObject.SetActive(false);
        BoostBar.gameObject.SetActive(false);
        _InGameAlertEnemyUI.gameObject.SetActive(show);
        _inGameSystemUI.gameObject.SetActive(show);
    }

	void Update () {
        //只更新玩家
        UpdateCharacterProfile();
    }

    //設定最大值
    public void SetMaxTeamProgress(float value=1)
    {
        
        TeamEnemyBar.SetTeamMaxProgress(value);
    }

    //
    public void SeTeamProgress(float value)
    {
        TeamEnemyBar.SeTeamProgress(value);
    }

    //設定enemy最大值
    public void SetEnemyMaxProgress(float value=1)
    {
        TeamEnemyBar.SetEnemyMaxProgress(value);
    }

    //
    public void SetEnemyProgress(float value)
    {
        TeamEnemyBar.SetEnemyProgress(value);
    }

    //設定時間
    public void SetTime(int time=150)
    {
        TimeViewer.SetNumber(time);
    }

    //設定HP
    public void SetHP(int hp)
    {
        HPViewer.SetNumber(hp);
    }

    //設定EX 量條
    public void SetMaxEx(float ex=1)
    {
        EXBar.SetMaxValue(ex);
    }

    //設定EX 量條
    //目前變成完成進度
    public void SetExValue(float value)
    {
        EXBar.SetValue(value);
    }

    //設定Boost 量條
    
    public void SetMaxBoost(float ex=1)
    {
        BoostBar.SetMaxValue(ex);
    }

    //設定Boost 量條
    //目前變成武器子彈數量(百分比)
    public void SetBoostValue(float value)
    {
        BoostBar.SetValue(value);
    }

    //取得目前人物狀態
    //大概也只有HP
    void UpdateCharacterProfile()
    {
        try
        {
            //設定 HP
            //int num = _target._info.State.Power.HP;
            //SetHP(_target._info.State.Power.HP);
        }
        catch (Exception ex)
        {
            Debug.Log("ex : " + ex.Message);
        }
    }

    //============================public======================

    //更新角色參數
    public void SetCharacter(Character character)
    {
        _target = character;
    }

    //設定目標物
    public void SetTargetList(List<GameObject> _targetList)
    {
        _testEnemyList = _targetList;
        //目標，指所有Stage裡面的敵人
        //_InGameAlertEnemyUI.SetTarget(_testCharacterList);
        //還有地圖
        Map.SetCharacterList(_testEnemyList);
    }


    //更新整體的power
    //基本上是每個frame更新依次
    public void UpdateTeamEnemyPower(float selfFinishPrecentage = 50, float enemyFinishPrecentage = 50)
    {
        try
        {
            //設定時間
            SetMaxTeamProgress(1);
            SeTeamProgress(selfFinishPrecentage);
            SetEnemyMaxProgress(1);
            SeTeamProgress(enemyFinishPrecentage);
        }
        catch
        {
           
        }
    }

    //更新目前打敗敵人數量
    public void DefeatEnemyNumber(int max, int now)
    {
        //設定 EX
        SetMaxEx(max);
        SetExValue(now);
    }

    //切換武器時顯示目前的子彈數量
    public void UpdateBulletNumber(int max,int now)
    {
        // 設定boost
        SetMaxBoost(max);
        SetBoostValue(now);
    }
    
}
