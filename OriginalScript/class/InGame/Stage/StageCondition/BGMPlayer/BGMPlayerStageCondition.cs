using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用來撥放背景音樂
public class BGMPlayerStageCondition : StageCondition
{

    //播放順序
    public int _playListNumber;
    //BGM清單
    public List<AudioClip> _listBGM;
    //撥放器
    public bool _exitStateStopMusic = false;
    //要不要loop
    public bool _loop=false;

    //設定值
    public override void SetVaule(object value)
    {
        _playListNumber = (int)value;
    }

    //初始化
    public override void Initialize()
    {
        _stageController.GetComponent<AudioSource>().loop=true;
    }

    //動作被執行的一開始
    public override void OnConditionEnter()
    {
        PlayBGM();
    }

    //動作正在被執行
    public override void OnConditionStay()
    {

    }

    //動作離開
    //如果要停止音樂就停止吧
    public override void OnConditionExit()
    {
        if(_exitStateStopMusic)
            StopBGM();
    }

    //取得目前的值
    public override object GetValue()
    {
        return _playListNumber;
    }

    //撥放音樂
    private void PlayBGM()
    {
        if (_listBGM.Count > 0)
        {
            //設定音樂
            _stageController.GetComponent<AudioSource>().clip = _listBGM[_playListNumber];
            _stageController.GetComponent<AudioSource>().loop = _loop;
            //設定撥放
            _stageController.GetComponent<AudioSource>().Play();
        }
    }

    private void StopBGM()
    {
        _stageController.GetComponent<AudioSource>().Stop();
    }
}
