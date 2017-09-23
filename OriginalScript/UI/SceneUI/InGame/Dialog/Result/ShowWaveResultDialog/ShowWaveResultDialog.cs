using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//顯示結果(Wave模式的)
//顯示結果，還有確定的按鈕
//按鈕要過3秒後才能按
public class ShowWaveResultDialog : PanelUI {

    //先顯示所有的wave
    //然後在顯示結果

    int _nowShowIndex = 0;

    //樣板
    public SingleWaveResultDialog _examleSingleWaveTemplate;

    public List<SingleWaveResultDialog> _listSingleWave;

    //顯示結果
    public GameObject _resultCanvas;

    //打敗敵人//list
    public Text _showTotalDefeatEnemy;

    //經過時間
    public Text _totalPassTime;

    //wave
    public Text _processWave;

    //總共分數
    public Text _totalScore;

    //設定顯示來源
    public void SetInput(List<SingleWave.SingleWaveResult> listResult)
    {
        int totalScore=0;
        int processWave=0;
        float totalProcessTime=0;
        int totalDefeatEnemy=0;

        _listSingleWave = new List<SingleWaveResultDialog>();
        //開始計算
        foreach (SingleWave.SingleWaveResult score in listResult)
        {
            totalScore = totalScore + score.Score;
            processWave = processWave +1;
            totalProcessTime = totalProcessTime + score.UseTime;
            totalDefeatEnemy = totalDefeatEnemy + score.DefeatEnemy;
            _listSingleWave.Add(LoadSingleWaveResult(score, _listSingleWave.Count, listResult.Count));
        }

        //然後把資訊更新上去
        _showTotalDefeatEnemy.text = totalDefeatEnemy.ToString();
        _totalPassTime.text = totalProcessTime.ToString();
        _processWave.text = processWave.ToString();
        _totalScore.text = totalScore.ToString();
    }

    //初始化
    public override void Initialize()
    {
        //對所有的 panelComponent 做初始化
        base.Initialize();
        //
        _nowShowIndex = 0;
        //切換顯示選單
        SwitchSceneByIndex(_nowShowIndex);
    }

    //如果在當下選單按選擇
    public override void PressTrigger()
    {
        _nowShowIndex++;
        //切換顯示選單
        SwitchSceneByIndex(_nowShowIndex);
    }

    //目前的index
    //先顯示所有的wave
    //然後在顯示結果
    void SwitchSceneByIndex(int index)
    {
        if (index == 0)
        {
            ShowAllWave(true);
            ShowTotalResult(false);
        }
        else if (index == 1)
        {
            ShowAllWave(false);
            ShowTotalResult(true);
        }
        else
        {
            ShowAllWave(false);
            ShowTotalResult(false);
            OnNotifiedSelect();
        }
    }

    //是否要顯示所有的wave
    void ShowAllWave(bool show)
    {
        //每一個wave 要不要顯示結果
        foreach (SingleWaveResultDialog singleDialog in _listSingleWave)
        {
            singleDialog.gameObject.SetActive(show);
        }
    }

    //要不要顯示所有結果
    void ShowTotalResult(bool show)
    {
        _resultCanvas.SetActive(show);
    }
    


    //把結果丟進去，然後產生一個新的表單
    SingleWaveResultDialog LoadSingleWaveResult(SingleWave.SingleWaveResult score ,int index,int total)
    {
        GameObject singleDialog = Instantiate(_examleSingleWaveTemplate.gameObject);
        singleDialog.SetActive(true);
        singleDialog.transform.parent = this.transform;
        //設定位置
        singleDialog.transform.localPosition = new Vector3(_examleSingleWaveTemplate.transform.localPosition.x, 2f * ((float)(total/2) - (float)index) / 2, _examleSingleWaveTemplate.transform.localPosition.z);
        //設定要顯示啥
        singleDialog.GetComponent<SingleWaveResultDialog>().SetInput(score);
        return singleDialog.GetComponent<SingleWaveResultDialog>();
    }
}


