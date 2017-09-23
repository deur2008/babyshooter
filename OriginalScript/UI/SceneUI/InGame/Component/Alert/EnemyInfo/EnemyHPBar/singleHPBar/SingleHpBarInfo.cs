using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//這邊是顯示單一HP 血條
public class SingleHpBarInfo : MonoBehaviour {

    //設定Boost狀態
    public float _value;
    //最大
    public float _max = 1;
    //最小
    public float _min = 0;
    //設定消耗多少 Boost後閃爍一次?
    public float _howMuchBoostConsumeParOneSparkle = 1;

    //設定Danger警告，目前設計10%以下就代表警告
    public int c = 10;
    //設定Alert警告(黃色)，目前設定30%
    public int _alertPrecentage = 30;

    //OverHeated圖層

    //紅色警告條
    public Image _dangerBar;
    //黃色警告條
    public Image _alertBar;
    //正常boostBar
    public Image _OKBar;

    //上一次的閃爍時的boostValue
    float _lastSparkleValue;

    //條條
    public Scrollbar _scrollBar;

    //初始化
    void Start()
    {
        SetMaxValue(1);
        SetMinValue(0);
        SetValue(1);
    }

    //=================public ======================
    //設定最大
    public void SetMaxValue(float max)
    {
        _max = max;
    }

    //設定最小
    public void SetMinValue(float min)
    {
        _min = min;
    }

    //設定目前Boost
    //boost使用會根據
    public void SetValue(float value)
    {
        _value = value;
        if (_value < _min)
            _value = _min;
        UpdateDisplayValue();
    }

    //顯示值
    void UpdateDisplayValue()
    {
        //0~1
        float value = _value / (_max - _min);
        Debug.Log("Size : " + value + " " + _value + " "+ _max);
        _scrollBar.size = value;
        if (_value - _lastSparkleValue > _howMuchBoostConsumeParOneSparkle || _value - _lastSparkleValue < -_howMuchBoostConsumeParOneSparkle)
        {
            _lastSparkleValue = _value;
        }
        //更新顏色
        UpdateColor(value);
    }

    //更新顏色
    protected void UpdateColor(float value)
    {
        if (value > 0.6)
        {
            ShowOKBar();
        }
        else
        {
            ShowYellowBar();
        }
    }

    //===================private==================

    //背景顏色
    //設定紅色
    private void ShowRedBar()
    {
        _dangerBar.enabled = true;
        _alertBar.enabled = false;
        _OKBar.enabled = false;
    }

    //設定黃
    private void ShowYellowBar()
    {
        _dangerBar.enabled = false;
        _alertBar.enabled = true;
        _OKBar.enabled = false;
    }

    //設定綠
    private void ShowOKBar()
    {
        _dangerBar.enabled = false;
        _alertBar.enabled = false;
        _OKBar.enabled = true;
    }
}
