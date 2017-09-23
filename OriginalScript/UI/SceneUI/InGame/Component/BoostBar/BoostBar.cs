using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//控制BoostBar的Script
public class BoostBar : GameComponentUI
{

    //設定Boost狀態
    public float _value;
    //最大
    public float _max = 100;
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
    //涓流不息的圖層
    public GameObject _flowImage;
    //用來閃爍的圖層
    public GameObject _spatkleImage;

    //上一次的閃爍時的boostValue
    float _lastSparkleValue;

    //條條
    public Scrollbar _scrollBar;

    //初始化?
    void Start()
    {
        //設定要 _flow;
        _flowImage.GetComponent<FlowUI>()._flow = true;
        //_scrollBar = this.GetComponent<Scrollbar>();
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
        UpdateDisplayValue();
    }

    //顯示值
    void UpdateDisplayValue()
    {
        //0~1
        float value = _value / (_max - _min);
        _scrollBar.size = value;
        if (_value - _lastSparkleValue > _howMuchBoostConsumeParOneSparkle || _value - _lastSparkleValue < -_howMuchBoostConsumeParOneSparkle)
        {
            //閃一下
            _spatkleImage.GetComponent<SparkleUI>().Sparkle();
            //
            _lastSparkleValue = _value;
        }

    }

    //===================private==================

    //設定紅色
    private void ShowRedBar()
    {
        _dangerBar.enabled = true;
        _alertBar.enabled = false;
        _OKBar.enabled = false;
    }

    //設定紅色
    private void ShowYellowBar()
    {
        _dangerBar.enabled = false;
        _alertBar.enabled = true;
        _OKBar.enabled = false;
    }

    //設定紅色
    private void ShowOKBar()
    {
        _dangerBar.enabled = false;
        _alertBar.enabled = false;
        _OKBar.enabled = true;
    }
}