using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CharacterOwnWeapon : MonoBehaviour {
    /*
    //背部上的武器
    CharacterBackWeapon _backWeapon;
    //左手上面的武器
    CharacterHandOwnWeapon _leftHandWeapon;
    //右手上面的武器
    CharacterHandOwnWeapon _rightHandWeapon;
    //兩隻手使用的武器
    */

    //背部上的武器
    public GameObject _backWeapon;
    //左手上面的武器
    public GameObject _leftHandWeapon;
    //右手上面的武器
    public GameObject _rightHandWeapon;
    //兩隻手使用的武器
    public GameObject _twoHandWeapon;
    
    //==================public==============

    //背部武器
    public GameObject BackWeapon
    {
        get
        {
            return _backWeapon;
        }
        set
        {
            _backWeapon = value;
        }
    }

    //左手武器
    public GameObject LeftHandWeapon
    {
        get
        {
            return _leftHandWeapon;
        }
        set
        {
            _leftHandWeapon = value;
        }
    }

    //右手武器
    public GameObject RightHandWeapon
    {
        get
        {
            return _rightHandWeapon;
        }
        set
        {
            _rightHandWeapon = value;
        }
    }

    //雙手一起的武器
    public GameObject TwoHandWeapon
    {
        get
        {
            return _twoHandWeapon;
        }
        set
        {
            _twoHandWeapon = value;
        }
    }

    public CharacterOwnWeapon()
    {
        _backWeapon = new GameObject();
        _leftHandWeapon = new GameObject();
        _rightHandWeapon = new GameObject();
        _twoHandWeapon=new GameObject();
    }

}
