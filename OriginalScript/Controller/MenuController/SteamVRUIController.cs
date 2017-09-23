using UnityEngine;
using System.Collections;

//管理左右手的Controller
//主要是控制UI部分
public class SteamVRUIController : MonoBehaviour {
    //控制可不可以
    public bool _enable;

    GameObject _leftHandJoystick;
    GameObject _rightHandJoystick;

    // Use this for initialization
    void Start()
    {
        _leftHandJoystick = this.GetComponent<SteamVR_ControllerManager>().left;
        _rightHandJoystick = this.GetComponent<SteamVR_ControllerManager>().right;
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    //左手的UI是不是可以控制
    public void EnableLeftControll(bool enable)
    {
        //_leftHandJoystick.GetComponent<SteamVR_CharacterHandController>()._UIController;//._enable = enable;
    }

    //右手是不是可以控制
    public void EnableRightControll(bool enable)
    {
        //_rightHandJoystick.GetComponent<SteamVR_CharacterHandController>()._UIController;//._enable = enable;
    }

    public bool Enable
    {
       
        set
        {
            EnableLeftControll(value);
            EnableRightControll(value);
        }
    }
}
