using UnityEngine;
using System.Collections;

//裡面提醒的東西
//負責做動畫
public class InGameAlertEnemySligleAlertAnimateUI : MonoBehaviour {

    public bool _display=false;

    //提醒01
    public GameObject _alert00;
    //提醒02
    public GameObject _alert01;
    //提醒_text
    public GameObject _alert_Text;

   

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
        _alert00.SetActive(_display);
        _alert01.SetActive(_display);
        _alert_Text.SetActive(_display);
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
