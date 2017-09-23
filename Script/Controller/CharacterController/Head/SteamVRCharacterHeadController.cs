using UnityEngine;
using System.Collections;

//控制頭部顯示和綁訂相關UI
public class SteamVRCharacterHeadController : MonoBehaviour {
    //目前控制模式
    public SteamVR_CharacterController.ControlMode _nowMode;

    //顯示腳色相關設定
    public CharacterInfoGUI _characterInfoGUI;
    //放置UI或是其他顯示相關位置
    public Transform _placeUI;

    //把目前腳色參數設定進去
    public void SetCharacter(Character character)
    {
        _characterInfoGUI.SetCharacter(character);
    }

    //如果要顯示UI
    public void SetUI(GameObject UI)
    {
        //把UI移動到這裡
        UI.transform.parent = _placeUI;
        UI.transform.localPosition = new Vector3(0, 0, 0);
        UI.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    //設定控制模式
    public void SetControlMode(SteamVR_CharacterController.ControlMode mode)
    {
        _nowMode = mode;
        //把GUI內部的東西隱藏掉
        _characterInfoGUI.UpdateMode(_nowMode);
    }
}
