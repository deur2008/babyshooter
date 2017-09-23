using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//用來顯示 數字用的，會綁一個Text用來顯示數字
//在綁一個設定為無限大顯示
//然後可以設定字的顏色，內建有存兩組
public class DigitalViewer : MonoBehaviour {
    //第一組顏色
    public Color _normalColor;
    //警告用顏色
    public Color _alertColor;
    //危險用顏色
    public Color _dangerColor;

    //設定危險數字
    public float _alertNumber = 150;
    //設定警告數字
    public float _dangerNumber = 50;
    //設定警告數字
    public float _infiniteNumber = 9999;

    //數字的text
    public Text _digitalText;
    //無限大的text
    public Text _infiniteText;
    //設定前置文字
    public string _prefixString="";
    //設定數字
    public float _number=100;
    //設定後置文字
    public string _postfixString="";


    //速度
    public float _updateParTime=30;//表示一秒會少掉多少次

    //在不同差距幅度下數字增加或是減少的的數字
    //X=0對應1，X=1對應100
    //Y=0對應0，Y=1對應100
    public AnimationCurve _reduceNumber;

    //上一次動畫時的數字
    float _lastAnimateNumber;

    // 初始
    void Start () {
        //指定 _lastAnimateNumber ，之後都是顯示 _lastAnimateNumber
        _lastAnimateNumber = _number;
        DisplayNumber(_lastAnimateNumber);
    }
	
	// Update is called once per frame
	void Update () {
        //表示該增加了
        if (_lastAnimateNumber != _number)
        {
            if(IsTimeOut())
            {
                UpdateNumber();
            }
            
        }
	}

    //設定數字，帶動話
    public void SetNumber(float number)
    {
        _number = number;
        _lastAnimateNumber = number;
        DisplayNumber(_lastAnimateNumber);
    }

    //如果用這個設定數字，就不會有動畫
    public void SetInitialNumber(float number)
    {
        _number = number;
    }

    //設定AlertNumber
    public void SetAlertNumber(float number)
    {
        _alertNumber = number;
    }

    //設定DangerNumber
    public void SetDangerNumber(float number)
    {
        _dangerNumber = number;
    }

    //設定DangerNumber
    public void SetInfiniteNumber(float number)
    {
        _infiniteNumber = number;
    }

    //設定前置文字
    public void SetPrefixString(string str)
    {
        _prefixString = str;
    }

    //設定後置文字
    public void SetPostfixString(string str)
    {
        _postfixString = str;
    }


    //=====================private ======================

    //檢查是不是該增加
    float timeOut = 0;
    bool IsTimeOut()
    {
        timeOut = timeOut + Time.deltaTime;
        //例如 timeOut =0.21 ，speed=5;
        if (timeOut > 1 / _updateParTime)
        {
            timeOut = 0;
            return true;
        }
        return false;
    }

    //根據不同速度減
    void UpdateNumber()
    {

        if (_lastAnimateNumber - _number > 0)
        {
            //表示數字該減少
            float reduce= (_reduceNumber.Evaluate((_lastAnimateNumber - _number) / 100) * 100);
            if (reduce <= 1)
            {
                reduce=1;
            }
            _lastAnimateNumber = _lastAnimateNumber - (int)reduce;

            if (_lastAnimateNumber < _number)
            {
                _lastAnimateNumber = _number;
            }
            DisplayNumber(_lastAnimateNumber);
        }
        else if (_lastAnimateNumber - _number < 0)
        {
            //表示數字該增加
            float reduce = (_reduceNumber.Evaluate(-(_lastAnimateNumber - _number) / 100) * 100);
            if (reduce <= 1)
            {
                reduce=1;
            }
            _lastAnimateNumber = _lastAnimateNumber + (int)reduce;

            if (_lastAnimateNumber > _number)
            {
                _lastAnimateNumber = _number;
            }
            DisplayNumber(_lastAnimateNumber);
        }
    }

    void SetColor(Color color)
    {
        _digitalText.color = color;
        _infiniteText.color = color;
    }

    void DisplayNumber(float number)
    {
        if (number >= _infiniteNumber)
        {
            _digitalText.enabled = false;
            _infiniteText.enabled = true;
        }
        else
        {
            _digitalText.enabled = true;
            _infiniteText.enabled = false;
            if (number < _dangerNumber)
            {
                //表示危險
                SetColor(_dangerColor);
            }
            else if (number < _alertNumber)
            {
                //表示被提醒
                SetColor(_alertColor);
            }
            else
            {
                SetColor(_normalColor);
            }
            _digitalText.text = _prefixString + number.ToString() + _postfixString;
        }
    }
}
