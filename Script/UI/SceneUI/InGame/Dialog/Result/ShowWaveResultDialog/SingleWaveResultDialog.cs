using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//單一一個Wave結果
public class SingleWaveResultDialog : MonoBehaviour
{

    //那一場wave有多少時間可以使用
    public Text _WaveTime;

    //經過時間
    public Text _totalPassTime;

    //節省多少時間
    public Text _remainTime;

    //打敗敵人
    public Text _defeatEnemy;

    //分數
    public Text _singleWaveScore;

    //把結果輸入進去
    public void SetInput(SingleWave.SingleWaveResult result)
    {
        _WaveTime.text = ((int)result.SingleWaveTime).ToString();
        _totalPassTime.text = ((int)result.UseTime).ToString();
        int diffTime = (int)(result.SingleWaveTime - result.UseTime);
        //如果有多的時間要加上加號
        _remainTime.text = diffTime > 0 ? "( +" + diffTime + ") " : "( " + diffTime + ") ";
        _defeatEnemy.text = result.DefeatEnemy.ToString();
        _singleWaveScore.text = result.Score.ToString();
    }
}
