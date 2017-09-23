using UnityEngine;
using System.Collections;
using VRTK;
using System;

//放置武器的地方
//如果武器被拿走，會通知這邊
public class GameObjectPlaceLocation : MonoBehaviour {
    //目前有沒有放置武器
    public bool _placeWeapon = false;

    //把武器放在這裡，固定點
    public Transform _placeObject;

    //物件本身
    public GameObject _object;

    //要不要根據 Interactable Object 把物件手部位置掛上去
    public bool _isSnapHandle = true;

    //武器放在這邊了
    public delegate void WeaopnPlaceToHere();
    public event WeaopnPlaceToHere _weaopnPlaceToHere;

    //武器從這邊拿走了
    public delegate void WeaopnTakeOutFromHere();
    public event WeaopnTakeOutFromHere _weaopnTakeOutFromHere;

    //通知武器放在這邊
    public void NotifyObjectPlaceToHere()
    {
        try
        {
            _weaopnPlaceToHere();
        }
        catch
        {

        }
    }

    //通知武器拿走了
    public void NotifyWeaopnTakeOutFromHere()
    {
        //這裡會有bug
        try
        {
            _weaopnTakeOutFromHere();
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    //把武器放在這邊
    //會把RigidBody 鎖住
    public void SetWeapon(GameObject weapon)
    {
        _object = weapon;
       
        NotifyObjectPlaceToHere();
        CloseRigidBody(_object);
        _placeWeapon = true;
        if (_isSnapHandle)
        {
            SnapHandleGameObject(_object);
        }
    }

    //把武器從這邊拿走
    //然後rigidBody 解除
    public GameObject GetWeaponFromHere()
    {
        _placeWeapon = false;
        NotifyWeaopnTakeOutFromHere();
        OpenRigidBody(_object);
        return _object;
    }

    //武器有沒有被拿走
    public bool GetWeaponExist()
    {
        return _placeWeapon;
    }

    //關閉rigid body 相關設定
    //把重力之類的關掉
    public void CloseRigidBody(GameObject gameObject)
    {
        try
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        catch
        {

        }
    }

    //關閉rigid 相關設定
    //打開回來
    public void OpenRigidBody(GameObject gameObject)
    {
        try
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        catch
        {

        }
    }

    //把武器固定在某個位置上面
    void SnapHandleGameObject(GameObject obj)
    {
        var objectScript = obj.GetComponent<VRTK_InteractableObject>();
        if (objectScript != null)
        {
            obj.transform.parent = _placeObject;
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localRotation = Quaternion.Euler(0,0,0);

            //修正武器首部位置
            var snapHandle = GetSnapHandle(objectScript);
            //objectScript.SetGrabbedSnapHandle(snapHandle);
            obj.transform.localRotation = _placeObject.transform.localRotation * Quaternion.Euler(snapHandle.transform.localEulerAngles);
            obj.transform.localPosition = _placeObject.transform.localPosition - (snapHandle.transform.position - obj.transform.position);
        }
        else
        {
            Debug.Log("Object has no component VRTK_InteractableObject");
            
        }


    }

    //找到武器的點
    Transform GetSnapHandle(VRTK_InteractableObject objectScript)
    {
        //回傳右手
        if (objectScript.rightSnapHandle != null)
        {
            return objectScript.rightSnapHandle;
        }
        else
        {
            return objectScript.leftSnapHandle;
        }
        /*
        if (objectScript.rightSnapHandle == null && objectScript.leftSnapHandle != null)
        {
            objectScript.rightSnapHandle = objectScript.leftSnapHandle;
        }

        if (objectScript.leftSnapHandle == null && objectScript.rightSnapHandle != null)
        {
            objectScript.leftSnapHandle = objectScript.rightSnapHandle;
        }

        if (VRTK_DeviceFinder.IsControllerOfHand(gameObject, VRTK_DeviceFinder.ControllerHand.Right))
        {
            return objectScript.rightSnapHandle;
        }

        if (VRTK_DeviceFinder.IsControllerOfHand(gameObject, VRTK_DeviceFinder.ControllerHand.Left))
        {
            return objectScript.leftSnapHandle;
        }

        return null;
        */
    }
}
