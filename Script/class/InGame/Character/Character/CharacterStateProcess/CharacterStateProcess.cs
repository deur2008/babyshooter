using UnityEngine;
using System.Collections;

//主要是用來處理一些 Character 裡面的一些參數，例如 ex 增加 消耗等等
//有點像是MVC裡面的 model
public class CharacterStateProcess : MonoBehaviour {

    //取得目前人物(View)
    Character _character;

    public void Initialize () {

        _character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update ()
    {

    }

    //============================Character 呼叫===============================

    //如果被敵人打到，要取得對自己的傷害
    public void GetDamage(CharacterPower getDamage)
    {
       
    }


    //===========================================

  
        /*

    //自動加子彈
    //0.5秒一次?
    //float _addBulletCalTime;
    void AutoAddBullet()
    {
        //雙手使用
        //只有槍需要補
        if (_character._info.State.Selector != null)
        {
                //左手
                if (_character._info.State.Selector._leftHand != null)
                {
                    //左手
                    foreach (GameObject gum in _character._info.State.Selector._leftHand._listHandWeapon)
                    {
                        try
                        {
                            if (gum.GetComponent<Gun>() != null)
                            {
                               // gum.GetComponent<Gun>().AddBullet();
                            }
                        }
                        catch
                        {

                        }
                      
                    }
                }

                //右首
                if (_character._info.State.Selector._rightHand != null)
                {
                    //右手
                    foreach (GameObject gum in _character._info.State.Selector._rightHand._listHandWeapon)
                    {
                        try
                        {
                            if (gum.GetComponent<Gun>() != null)
                            {
                                //gum.GetComponent<Gun>().AddBullet();
                            }
                        }
                        catch
                        {

                        }
                    }
                }

                //雙手
                foreach (GameObject gum in _character._info.State.Selector._twoHandGameObject)
                {
                    if (gum.GetComponent<Gun>() != null)
                    {
                       // gum.GetComponent<Gun>().AddBullet();
                    }
                }
        }

    }

    //目前HP是不是規0
    public bool IsLostAllHP()
    {
        if (_character._info.State.Power.HP <= 0)
        {
            return true;
        }
        return false;
    }

    //取得目前是不是GameOver
    public bool isDead()
    {
        //表示沒有生命了
        if (_character._info.State.Power.HP <= 0 && _character._info.State.Power.Life <= 0)
        {
            return true;
        }
        return false;
    }

    //目前被扣除的血量
    //用來判斷兩隊加起來總消耗血量是否超過總生命點數
    public int GetTotalHp()
    {
        //算出HP差 + 生命差*最大HP
        int hpDiff = _character._info.Parameter.MaxPower.HP - _character._info.State.Power.HP;
        int lifeDiff= _character._info.Parameter.MaxPower.Life - _character._info.State.Power.Life;
        return hpDiff + lifeDiff * _character._info.Parameter.MaxPower.HP;
    }

    */
}
