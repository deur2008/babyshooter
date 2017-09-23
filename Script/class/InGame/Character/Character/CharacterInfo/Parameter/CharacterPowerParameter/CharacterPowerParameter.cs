using UnityEngine;
using System.Collections;

public class CharacterPowerParameter : MonoBehaviour {

    private int _fullHP; //最高HP
    private int _maxPower; //最高集器

    //最高HP
    public int FullHP
    {
        get
        {
            return _fullHP;
        }
        set
        {
            _fullHP = value;
        }
    }

    //最高集器
    public int FullPower
    {
        get
        {
            return _maxPower;
        }
        set
        {
            _maxPower = value;
        }
    }
}
