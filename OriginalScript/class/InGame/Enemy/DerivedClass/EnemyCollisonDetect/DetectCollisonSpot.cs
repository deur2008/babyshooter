using UnityEngine;
using System.Collections;

//只負責偵測碰撞，還有回傳通知
//可以提供事件註冊
//還有可以設定碰撞對象，例如是玩家還是子彈
public class DetectCollisonSpot : MonoBehaviour
{
    //只偵測特定tag對象
    public string DetectTag="";

    //通知，如果物體進入
    public delegate void ObjectEnter(GameObject target);
    public event ObjectEnter _objectEnter;

    //通知，如果物體停留
    public delegate void ObjectStay(GameObject target);
    public event ObjectStay _objectStay;

    //通知，如果物體離開
    public delegate void ObjectExit(GameObject target);
    public event ObjectExit _objectExit;

    //如果有物體近來
    protected void GameObjectEnter(GameObject gameObject)
    {
        _objectEnter(gameObject);
    }

    //如果有物體近來
    protected void GameObjectStay(GameObject gameObject)
    {
        _objectStay(gameObject);
    }

    //如果有物體近來
    protected void GameObjectExit(GameObject gameObject)
    {
        _objectExit(gameObject);
    }

    //碰撞進入
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == DetectTag)
        {
            GameObjectEnter(collision.gameObject);
        }
    }

    //碰撞進入
    void GameObjectStay(Collision collision)
    {
        if (collision.gameObject.tag == DetectTag)
        {
            _objectStay(collision.gameObject);
        }
    }

    //碰撞進入
    void GameObjectExit(Collision collision)
    {
        if (collision.gameObject.tag == DetectTag)
        {
            _objectExit(collision.gameObject);
        }
    }
}
