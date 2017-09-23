using UnityEngine;
using System.Collections;

//腳色目前的狀態
//目前血量
//Power 生命值
//目前移動速度，絕對座標
//目前左手手持武器類型(刀，劍，盾牌，槍，)
//右手手持手持武器類型(刀，劍，盾牌，槍，)
//目前動作變化類型(模式)

public class CharacterState : MonoBehaviour {


    //能量
    public CharacterPower Power;
   
    //目前使用者擁有的武器(Objectt)
    public WeaponGameObjectSelector Selector;


}
