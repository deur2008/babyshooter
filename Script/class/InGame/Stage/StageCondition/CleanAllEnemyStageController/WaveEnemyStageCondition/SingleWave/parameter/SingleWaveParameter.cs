using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//裡面的參數
public class SingleWaveParameter : Difficulty{

    //打敗多少敵人
    public int _defeatEnemyNumber=20;

    //經過多少時間
    public int _processTime=50;
    //如果過關後會有的顯示提醒
    public PanelUI _showWaveFinishUI;
    //如果失敗會顯示失敗
    public PanelUI _showWaveFailUI;

    //如果執行完成後會執行那些Action;
    public List<StageAction> _listAction;

    
}
