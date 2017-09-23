using UnityEngine;
using System.Collections;

//這種敵人只會直線移動
//但也有可能會飛向人物
//基本上就是設定成在空中移動的
public class MoveStraightEnemy : EnemyAction
{
    //移動方向
    Vector3 _movePosition;
    //移動速度
    float _moveSpeed;
    //在某個距離內就成朝向玩家移動
    float _rumToPlayerDistance;

    //取得敵人
    public Enemy _enemy;

    //延遲初始化
    public override void Initialize()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (_enemy != null)
        {
            MoveStrainght(_moveSpeed);
        }
    }

    //設定難度
    protected  override void SetStageDifficulty(Difficulty difficulty)
    {
        difficulty = (MoveParameter)difficulty;
    }

    //只做直線移動
    //設定沿著某個座標移動
    void MoveStrainght(float speed)
    {
        this.transform.Translate(_movePosition*speed * Time.deltaTime);
    }

    //會朝玩家移動
    void MoveAtPlayer(GameObject Player)
    {
        //面相敵人
        this.transform.LookAt(Player.transform);
        //然後移動
        MoveStrainght(_moveSpeed);
    }
}
