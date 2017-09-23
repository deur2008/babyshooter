using UnityEngine;
using System.Collections;

//設定目前HP
public class HPViewer : GameComponentUI
{
    public DigitalViewer _viewer;

    //public
    //設定數字，帶動話
    public void SetNumber(float number)
    {
        _viewer.SetNumber(number);
    }

    //如果用這個設定數字，就不會有動畫
    public void SetInitialNumber(float number)
    {
        _viewer.SetInitialNumber(number);
    }

    //設定AlertNumber
    public void SetAlertNumber(float number)
    {
        _viewer.SetAlertNumber(number);
    }

    //設定DangerNumber
    public void SetDangerNumber(float number)
    {
        _viewer.SetDangerNumber(number);
    }

    //設定DangerNumber
    public void SetInfiniteNumber(float number)
    {
        _viewer.SetInfiniteNumber(number);
    }
}
