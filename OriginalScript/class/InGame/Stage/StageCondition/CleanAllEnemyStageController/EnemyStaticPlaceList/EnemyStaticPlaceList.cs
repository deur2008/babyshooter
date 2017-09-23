using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//靜態放置敵人的地方
public class EnemyStaticPlaceList : MonoBehaviour {

    //放置敵人的地方
    public static List<GameObject> _listEnemy;

    //通知，如果敵人被攻擊了
    //匯回傳敵人被攻擊通知
    //還有分數
    public delegate void EnemyHitterd(SingleWeakPointParameter difficulty);
    public static event EnemyHitterd _enemyHitted;

}
