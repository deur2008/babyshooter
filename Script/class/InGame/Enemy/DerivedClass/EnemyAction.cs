using UnityEngine;
using System.Collections;

//所有敵人會執行的動作，例如走路，AI 或是攻擊 等等
//base Class
public class EnemyAction : MonoBehaviour {

    //難度
    public DifficultyManager _difficultyManager;
    //目前難度
    public EnemyDifficulty _nowdifficulty;

    //人物動作
    protected Animator _animator;
    //敵人主角本
    public Enemy _enemy;

    public bool _executeAction = false;

    //設定難度
    protected virtual void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = (EnemyDifficulty)difficulty;
    }

    //設定動畫動作
    //有的會把動作大小帶進去
    protected void SetAnimatorTrigger()
    {

    }

    //==================public : called By Enemy.cs================

    //執行動作
    public virtual void ExecAction()
    {
        _executeAction = true;
        //動畫開始
        SetStartAnimation();
        //播放音效
        PlayAudio();
    }

    //取消動作
    public virtual void StopAction()
    {
        _executeAction = false;
        //動畫停止
        SetStopAnimation();
        //停止音效
        StopAudio();
    }

    //設定難度
    public virtual void SetDifficulty(StageController.Difficulty difficulity)
    {
        //如果是簡單
        if (difficulity == StageController.Difficulty.easy)
        {
            SetStageDifficulty(_difficultyManager.Easy);
        }
        else if (difficulity == StageController.Difficulty.normal)
        {
            SetStageDifficulty(_difficultyManager.Normal);
        }
        else if (difficulity == StageController.Difficulty.hard)
        {
            SetStageDifficulty(_difficultyManager.Hard);
        }
        else //if (difficulity == StageController.Difficulty.insame)
        {
            SetStageDifficulty(_difficultyManager.Insame);
        }
    }

    //取得loop大小
    public float GetRemainTime()
    {
        return Random.Range(_nowdifficulty._minSecond, _nowdifficulty._maxSecond);
    }

    //設定人物對象
    public void SetAnimator(Animator animator)
    {
        _animator = animator;
    }

    //設定敵人
    public virtual void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    //設定初始化
    public virtual void Initialize()
    {

    }

    //設定動畫
    public virtual void SetStartAnimation()
    {
        _animator.SetBool("AAA", true);
    }

    //設定動畫
    public virtual void SetStopAnimation()
    {
        _animator.SetBool("AAA", false);
    }

    //播放音效
    protected virtual void PlayAudio()
    {
        try
        {
            if (_difficultyManager.AudioParameter.AudioClip != null)
            {
                if (this.GetComponent<AudioSource>() != null)
                {
                    AudioSource source = this.GetComponent<AudioSource>();
                    //設定來源和相關參數
                    source.clip = _difficultyManager.AudioParameter.AudioClip;
                    source.loop = _difficultyManager.AudioParameter.IsLoop;
                    //然後播放
                    source.Play();
                }
            }
        }
        catch
        {

        }
    }

    //停止音效，如果沒有loop 基本上應該不要撥放
    protected void StopAudio()
    {
        try
        {
            if (this.GetComponent<AudioSource>() != null)
            {
                AudioSource source = this.GetComponent<AudioSource>();
                source.Stop();
            }
        }
        catch
        {

        }
    }

}
