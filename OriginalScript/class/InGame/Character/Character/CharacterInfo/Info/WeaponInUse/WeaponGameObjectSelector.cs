using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//腳色選擇器，用來切換目前的武器
//目前手上的武器
public class WeaponGameObjectSelector : MonoBehaviour {

    public WeaponGameObjectSelector()
    {
        _backGameObject = new List<GameObject>();
        _twoHandGameObject = new List<GameObject>();
        _leftHand = new SingleHandWeapon();
        _rightHand = new SingleHandWeapon();
    }

    //背部上的武器，要對應實體武器，所以要從Weapon改成GameObject
    public List<GameObject> _backGameObject; //背後武器
    //左手
    public SingleHandWeapon _leftHand;
    //右手
    public SingleHandWeapon _rightHand;
    //兩隻手使用的武器
    public List<GameObject> _twoHandGameObject;//雙手

    //複製物件 ，把物件複製到帶入的變數裡面
    public WeaponGameObjectSelector CopyInstantiate(WeaponGameObjectSelector weaponGameObjectSelector)
    {
        //WeaponGameObjectSelector weaponGameObjectSelector = new WeaponGameObjectSelector();
        //開始複製
        //背後武器
        foreach (GameObject weapon in _backGameObject)
        {
            weaponGameObjectSelector._backGameObject.Add(Instantiate(weapon));
        }
        //左右手
        weaponGameObjectSelector._leftHand = _leftHand.CopyInstantiate(weaponGameObjectSelector._leftHand);
        weaponGameObjectSelector._rightHand = _rightHand.CopyInstantiate(weaponGameObjectSelector._rightHand);
        //雙手武器
        foreach (GameObject weapon in _twoHandGameObject)
        {
            weaponGameObjectSelector._twoHandGameObject.Add(Instantiate(weapon));
        }
        //回傳
        return weaponGameObjectSelector;
    }
}
