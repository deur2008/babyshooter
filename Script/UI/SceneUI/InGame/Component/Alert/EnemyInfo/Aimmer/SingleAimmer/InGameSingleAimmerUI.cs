using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//一個准心切換器
//可以切換各種准心
public class InGameSingleAimmerUI : MonoBehaviour {

    public List<GameObject> _aimmerList;
    public int _nowAimmer=-1;
    int _disable = -1;
    int _cannotAttackMode = 0; //黃色
    int _canAttack = 1; //紅色
    int _aim = 2; //紅色，表示瞄準
    int _weaponAim = 3;

    void Start () {
        //更新，預設是沒有
        UpdateAimmer();
    }
	
	

	void Update () {
	
	}

    

    //更新 Aimmer 樣式
    void UpdateAimmer()
    {
        if (_aimmerList != null)
        {
            if (_aimmerList.Count > 0)
            {
                for (int i = 0; i < _aimmerList.Count; i++)
                {
                    if (i == _nowAimmer)
                    {
                        _aimmerList[i].SetActive(true);
                    }
                    else
                    {
                        _aimmerList[i].SetActive(false);
                    }
                }
            }
        }
    }

    //=======================public =======================
    public Vector3 GetRotation()
    {
        return this.transform.rotation.eulerAngles;
    }

    //取得准心距離
    //准心有可能跟著敵人位置做遠近調整

    //切換到 _cannotAttackMode
    public void SetToCanNotAttackMode()
    {
        if (_nowAimmer != _cannotAttackMode)
        {
            _nowAimmer = _cannotAttackMode;
            UpdateAimmer();
        }
    }

    //切換到 _canAttack
    public void SetToCanAttack()
    {
        if (_nowAimmer != _canAttack)
        {
            _nowAimmer = _canAttack;
            UpdateAimmer();
        }
    }

    //切換到 _aim
    public void SetAimMode()
    {
        if (_nowAimmer != _aim)
        {
            _nowAimmer = _aim;
            UpdateAimmer();
        }
    }

    //切換到 _weaponAim
    public void SetToWeaponAimMode()
    {
        if (_nowAimmer != _weaponAim)
        {
            _nowAimmer = _weaponAim;
            UpdateAimmer();
        }
    }
}
