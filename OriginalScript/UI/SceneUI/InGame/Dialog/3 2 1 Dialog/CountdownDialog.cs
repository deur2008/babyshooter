using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//倒數用的Dialog
//會顯示3 2 1 start
public class CountdownDialog : PanelUI
{
    //是否開始計時
    public bool _isStartCountDown;
    public float _time;
    public int _nowIndex=0;
    //顯示
    public List<GameObject> _listCountDownObject;
    //播放音效
    public List<AudioClip> _listAudioClip;
   

    //初始化
    public override void Initialize()
    {
        SetItemVisible(_nowIndex);
        //開始倒數計時
        _isStartCountDown = true;
    }

    //更新
    void Update()
    {
        if (_isStartCountDown)
        {
            _time = _time + Time.deltaTime;
            if (_time > _nowIndex + 1)
            {
                _nowIndex++;
                //如果比陣列還大
                if (_nowIndex >= _listCountDownObject.Count)
                {
                    //全部都不顯示
                    SetItemVisible(-1);
                    _isStartCountDown = false;
                    //通知UI已經被選擇
                    OnNotifiedSelect();
                }
                else
                {
                    SetItemVisible(_nowIndex);
                    PlayCountDownAudioClip(_nowIndex);
                }
            }
        }
    }

    //播放音效
    void PlayCountDownAudioClip(int index)
    {
        try
        {
            this.GetComponent<AudioSource>().Stop();
            this.GetComponent<AudioSource>().clip = _listAudioClip[index];
            this.GetComponent<AudioSource>().Play();
        }
        catch
        {

        }
    }

    //全部藏起來
    void SetItemVisible(int index)
    {
        if (_listCountDownObject.Count > 0)
        {
            for (int i = 0; i < _listCountDownObject.Count; i++)
            {
                if (i == index)
                {
                    _listCountDownObject[i].SetActive(true);
                }
                else
                {
                    _listCountDownObject[i].SetActive(false);
                }
            }
        }
        
    }

    
}
