using UnityEngine;
using System.Collections;

//主要是套用在地面行走的敵人
//會控制AI，只會一直朝著敵人走
public class MoveAIEnemy : EnemyAction
{
    //目前設定移動速度介於1~10
    //大於5以上就算是用跑的

    //速度
    float _maxSpeed;
    //速度
    float _minSpeed;
    //目前速度
    public float _nowSpeed;
    //靠近玩家的距離
    public float _rumToPlayerDistance;

    //取得難度
    DifficultyManager _manager;

    //導航系統
    public NavMeshAgent _agent;

    //初始化
    public override void Initialize()
    {
        //抓取AI
        _agent = this.GetComponent<NavMeshAgent>();
        //抓取敵人
        _enemy = this.GetComponent<Enemy>();
        //設定目前難度
        SetStageDifficulty(_enemy._nowEnemyDifficulty);
    }

    //更新
    void Update()
    {
        if (_enemy != null)
        {
            if (_executeAction)
            {
                MoveToPlayer();
            }
        }
    }

    //執行動作
    public override void ExecAction()
    {
        base.ExecAction();
        //移動人物
        MoveToPlayer();
    }

    //執行動作
    public override void StopAction()
    {
        base.StopAction();
        //移動人物
        MoveToPlayer();
    }

    //設定難度
    protected override void SetStageDifficulty(Difficulty difficulty)
    {
        //轉型
        _nowdifficulty = ((MoveAIParameter)difficulty);
        //然後把速度指定過來
        _maxSpeed = ((MoveAIParameter)_nowdifficulty)._maxSpeed;
        _minSpeed = ((MoveAIParameter)_nowdifficulty)._minSpeed;
        _nowSpeed = _minSpeed;

    }

    //0.5秒選擇一次
    float _selectTime = 0.5f;
    float _nowTime=1;
    
    float rand = 0;

    //選擇速度
    public void SelectSpeed()
    {
        _nowSpeed= Random.Range(_minSpeed, _maxSpeed);
    }

    //透過AI移動
    //還有更新目標物位置
    void MoveToPlayer()
    {
        try
        {
            //設定速度
            _agent.speed = _nowSpeed / 2;
            //設定要走過去的位置
            //設定成朝向CameraRig 裡面的 character
            Vector3 targetposition = _enemy._target.GetComponent<SteamVR_CharacterController>()._character.transform.position;

            //修正Y軸，避免和自己位置相差太高
            //Debug.Log("EnemyPosition : " + this.transform.position.y + targetposition.y);
            targetposition.y = this.transform.position.y;
            
            //剛開始落下時有可能產生錯誤
            try
            {
                _agent.SetDestination(targetposition);
            }
            catch
            {

            }
        }
        catch
        {

        }
    }

    //停止
    void StopPlayer()
    {
        //設定速度
        _agent.speed = 0;
    }

    //設定動畫
    public override void SetStartAnimation()
    {
        _animator.SetBool("Move", true);
    }

    //設定動畫
    public override void SetStopAnimation()
    {
        _animator.SetBool("Move", false);
    }

    //更新速度
    //如果到某個速度以上就算是用跑的
    void UpdateSpeed()
    {
        _animator.SetFloat("Move_Y", _nowSpeed/5);
    }
}
