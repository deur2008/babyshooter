using UnityEngine;
using System.Collections;

//子彈動畫
//如果必要的話就多型吧=A=
//主要動畫有OnStart
//OnChasing
//OnTouchEnemy(如果沒有碰到Enemy，就不會出現這個，然後OnDestroy 是在 Bullet 決定)
//OnDestroy
public class BulletAnimation : MonoBehaviour {
    //動畫狀態機
    Animator _animator;

    //開始發射
    void StartFire()
    {

    }

    //發射中
    void Fireing()
    {

    }

    //如果有撞到東西
    void Collison()
    {

    }

    //如果打到敵人
    void CollisonTarget()
    {

    }
}
