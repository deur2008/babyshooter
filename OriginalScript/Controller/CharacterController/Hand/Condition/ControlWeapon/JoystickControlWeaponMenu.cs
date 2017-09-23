using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRTK;
using System;

//顯示武器選單
public class JoystickControlWeaponMenu : MonoBehaviour {

    //武器選單間距
    public float _weaponRange;
    public int _index;
    public List<GameObject>_listItem;
    //建立武器選單
    public void ReGenerateMenu(List<GameObject> ListWeapon, int index )
    {
        _listItem = ListWeapon;
        _index = index;
        //把所有東西排好
        UpdateMenu();
    }

    //更新顯示
    void Update()
    {
        //UpdateMenu();
    }

    //更先顯示選單
    public void UpdateMenu()
    {
        if (_listItem.Count > 0)
        {
            for (int i = 0; i < _listItem.Count; i++)
            {
                //先把武器都顯示到上面
                if (true)
                {
                    /*
                    //抓取物件腳本
                    
                    //取得上面的附著點
                    
                    //_listItem[i].transform.rotation = this.transform.rotation * Quaternion.Euler(snapHandle.transform.localEulerAngles);
                    //_listItem[i].transform.position = this.transform.position - (snapHandle.transform.position - _listItem[i].transform.position) + new Vector3(position, 0, 0);
                    */
                    try
                    {
                        var objectScript = _listItem[i].GetComponent<VRTK_InteractableObject>();
                        var snapHandle = GetSnapHandle(objectScript);
                        Debug.Log(snapHandle.name);
                        float position = (i - _index) * _weaponRange;
                        FreezeRigidBody(_listItem[i], true);
                        _listItem[i].transform.parent = this.transform;//先設定到目前目錄下面
                        _listItem[i].transform.rotation = this.transform.rotation * Quaternion.Euler(snapHandle.transform.localEulerAngles);
                        _listItem[i].transform.position = this.transform.position - (snapHandle.transform.position - _listItem[i].transform.position) + new Vector3(position, 0, 0) + new Vector3(position, 0, 0);
                        //_listItem[i].transform.localPosition = new Vector3(position, 0, 0);
                    }
                    catch(Exception ex)
                    {
                        Debug.Log(ex.Message);
                    }

                }
            }
        }
    }

    //要不要把 RigidBody 鎖起來
    void FreezeRigidBody(GameObject item,bool isFreeze)
    {
        try
        {
            if (isFreeze)
            {
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | 
                 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        catch
        {

        }
    }

    //抓取上面的固定點
    private Transform GetSnapHandle(VRTK_InteractableObject objectScript)
    {
        return objectScript.rightSnapHandle;
    }
}
