using UnityEngine;
using System.Collections;

//人物停止
//動畫就會變成"Idol"
public class EnemyStop : EnemyAction
{
    //設定難度
    protected override void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = (StopParameter)difficulty;
    }

    //設定動畫
    public override void SetStartAnimation()
    {
        _animator.SetBool("Move", false);
    }

    //設定動畫
    public override void SetStopAnimation()
    {
        //_animator.SetBool("Move", true);
    }
}
