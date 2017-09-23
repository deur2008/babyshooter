using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//顯示武器的UI
//要握住武器
public class HoldWeaponDialog : PanelUI
{
    public int _remainWeapon;
    //範例
    public GameObject _exampleWeaponGameObjectSelector;
    //手部武器
    WeaponGameObjectSelector _weaponGameObjectSelector;

    //裡面會有一系列武器
    public List<GameObjectPlaceLocation> _listWeapon;
    //物件放置地點
    public Transform _objectPlace;

    //如果武器被拿走，會有通知 ?

    //設定值
    //裡面設定過的武器是已經被複製過的
    public override void SetValue(object Value)
    {
        _weaponGameObjectSelector = (WeaponGameObjectSelector)Value;
    }

    //初始化
    //把所有 GameObjectPlaceLocation 建立好，裡面塞武器
    public override void Initialize()
    {
        //Debug.Log("INit");
        //左手
        foreach (GameObject item in _weaponGameObjectSelector._leftHand._listHandWeapon)
        {
            //Debug.Log("LeftWeapon");
            AddItemToGrab(item);
        }

        //右手
        foreach (GameObject item in _weaponGameObjectSelector._rightHand._listHandWeapon)
        {
           // Debug.Log("RightWeapon");
            AddItemToGrab(item);
        }
        _remainWeapon = _listWeapon.Count;
    }

    //增加數量
    protected void AddItemToGrab(GameObject add)
    {
        //先複製物件
        GameObject placeLocation = Instantiate(_exampleWeaponGameObjectSelector);
        placeLocation.SetActive(true);
        

        //取得樣本
        GameObjectPlaceLocation _singleGameObjectPlaceLocation = placeLocation.GetComponent<GameObjectPlaceLocation>();
        
        //然後是取得武器放回來
        _singleGameObjectPlaceLocation._weaopnPlaceToHere += new GameObjectPlaceLocation.WeaopnPlaceToHere(WeaponPlaceFromHere);
        //武器被拿走
        _singleGameObjectPlaceLocation._weaopnTakeOutFromHere += new GameObjectPlaceLocation.WeaopnTakeOutFromHere(WeaponGrab);
        //設定武器
        _singleGameObjectPlaceLocation.SetWeapon(add);
        //增加到陣列裡面
        _listWeapon.Add(_singleGameObjectPlaceLocation);

        //設定位置
        placeLocation.transform.parent = _objectPlace;
        placeLocation.transform.localPosition = new Vector3(0, 0, 0);
        placeLocation.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    //
    void CancelEvent(GameObjectPlaceLocation location)
    {
        //然後是取得武器放回來
        location._weaopnPlaceToHere -= new GameObjectPlaceLocation.WeaopnPlaceToHere(WeaponPlaceFromHere);
        //武器被拿走
        location._weaopnTakeOutFromHere -= new GameObjectPlaceLocation.WeaopnTakeOutFromHere(WeaponGrab);
    }

    //更新位置，不然會跑掉
    void Update()
    {
        foreach (GameObjectPlaceLocation place in _listWeapon)
        {
            place.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            place.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void WeaponPlaceFromHere()
    {

    }

    //如果武器少了一個((表示被拿走，重新整理
    void WeaponGrab()
    {
        Debug.Log("WeaponGrab");
        //更新選單
        RefreshWeaponGameObjectSelector();
        //更新選單位置
        RefreshWeaponPosition();
    }

    //重新整理，如果GameObjectPlaceLocation 裡面是空的
    //就代表被拿走了，清理掉
    void RefreshWeaponGameObjectSelector()
    {
        foreach (GameObjectPlaceLocation place in _listWeapon)
        {
            if (place.GetWeaponExist() == false)
            {
                _remainWeapon--;
                /*
                try
                {
                    
                    //下面會出問題
                    CancelEvent(place);
                    _listWeapon.Remove(place);
                }
                catch
                {

                }
                */
            }
        }
        Debug.Log("_listWeapon.Count : "+ _listWeapon.Count +" "+ _remainWeapon);
        //表示所有武器都被拿走
        if (_remainWeapon == 0)
        {
            WeaponAllGone();
        }
    }

    //更新武器位置
    //先暫時都更新在0,0,0的位置
    void RefreshWeaponPosition()
    {
        foreach (GameObjectPlaceLocation place in _listWeapon)
        {
            place.transform.position = new Vector3(0,0,0);
        }
    }

    //如果武器全部被拿走了，通知
    void WeaponAllGone()
    {
        Debug.Log("Notified");
        OnNotifiedSelect();
    }
}
