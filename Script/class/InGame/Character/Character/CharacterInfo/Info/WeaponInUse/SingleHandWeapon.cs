using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//單一一隻手
public class SingleHandWeapon : MonoBehaviour {


    public SingleHandWeapon()
    {
        _listHandWeapon = new List<GameObject>();
    }

    //左手上面的武器
    public List<GameObject> _listHandWeapon;//左手武器
    //快速攻擊
    public GameObject _fastAttackWeapon;
    //快速防禦
    public GameObject _fastDefenseWeapon;

    //複製物件
    public SingleHandWeapon CopyInstantiate(SingleHandWeapon singleHandWeapon)
    {
        //SingleHandWeapon singleHandWeapon = new SingleHandWeapon();
        //快速武器
        if (_fastAttackWeapon != null)
            singleHandWeapon._fastAttackWeapon = Instantiate(_fastAttackWeapon);
        if (_fastDefenseWeapon != null)
            singleHandWeapon._fastDefenseWeapon = Instantiate(_fastDefenseWeapon);
        //_listHandWeapon = new List<GameObject>();
        //切換武器
        if (_listHandWeapon != null)
        {
            foreach (GameObject weapon in _listHandWeapon)
            {
                singleHandWeapon._listHandWeapon.Add(Instantiate(weapon));
                /*
                try
                {
                    
                }
                catch(Exception ex)
                {
                    Debug.Log(ex.Message);
                }
                */
            }
        }
        return singleHandWeapon;
    }
}
