using UnityEngine;
using System.Collections;

public class InGameAlertEnemySligleDangerAnimateUI : MonoBehaviour {

    public bool _display = false;

    //警告01
    public GameObject _danger00;
    //警告02
    public GameObject _danger01;
    //警告03
    public GameObject _danger02;
    //警告04
    public GameObject _danger03;
    //警告_text
    public GameObject _danger_text;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_display)
        {
            RunAnimate();
        }
	}

    //跑動畫ww
    void RunAnimate()
    {

    }

    //重新開始整理顯示順序UI
    void Refresh()
    {

    }

    //根據true 還是 false 去選擇要顯示還是隱藏
    void UpdateDisplayMode()
    {
        _danger00.SetActive(_display);
        _danger01.SetActive(_display);
        _danger02.SetActive(_display);
        _danger03.SetActive(_display);
        _danger_text.SetActive(_display);
    }

    //==========================public ========================
    public void Display(bool display)
    {
        if (_display == false)
        {
            if (display)
            {
                Refresh();
            }
        }
        _display = display;
        UpdateDisplayMode();
    }
}
